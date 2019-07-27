--指向当前要使用的数据库

use master
go
--判断当前数据库是否存在
if exists (select * from sysdatabases where name='AdvancedEFDB')
drop database AdvancedEFDB --删除数据库
go
--创建数据库
create database AdvancedEFDB
on primary
(
	--数据库文件的逻辑名
    name='AdvancedEFDB_data',
    --数据库物理文件名（绝对路径）
    filename='D:\DB\AdvancedEFDB_data.mdf',
    --数据库文件初始大小
    size=10MB,
    --数据文件增长量
    filegrowth=1MB
)
--创建日志文件
log on
(
    name='AdvancedEFDB_log',
    filename='D:\DB\AdvancedEFDB_log.ldf',
    size=2MB,
    filegrowth=1MB
)
go
--创建学员信息数据表
use AdvancedEFDB
go
--创建班级表
if exists(select * from sysobjects where name='StudentClass')
drop table StudentClass
go
create table StudentClass
(
	ClassId int primary key,
    ClassName varchar(20) not null
)
go
--学员信息表
if exists (select * from sysobjects where name='Student')
drop table Student
go
create table Student
(
    StudentId int identity(100000,1) primary key,
    StudentName varchar(20) not null,
    Gender char(2)  not null,
    Dateofbirth datetime  not null default(getdate()),
    PhoneNumber varchar(50),
    StudentAddress varchar(500) default('地址不详'),
    ClassId int references StudentClass(ClassId)  --班级外键
)
go
-- 一卡通表
if exists(select * from sysobjects where name='StudentCard')
drop table StudentCard
go
create table StudentCard
(
	StudentId  int primary key references Student(StudentId), --学号(一对一的关系)
	CardType varchar(20) not null    --卡类型
    --FailureTime datetime not null  --失效时间(其他列自己根据需要添加)
)
go
--创建成绩表
if exists(select * from sysobjects where name='ScoreList')
drop table ScoreList
go
create table ScoreList
(
    SocreId int identity(1,1) primary key,
    StudentId int not null,
    CSharp int null,
    SQLDB int null
)
go
--创建管理员用户表
if exists(select * from sysobjects where name='SysAdmin')
drop table SysAdmin
create table SysAdmin
(
	LoginId int identity(1000,1) primary key,
    LoginPwd varchar(20) not null check(len(LoginPwd)>=6),
    AdminName varchar(20) not null
)
go


-------------------------------------------插入数据--------------------------------------
use AdvancedEFDB
go

--插入班级数据
insert into StudentClass(ClassId,ClassName) values(1,'软件1班')
insert into StudentClass(ClassId,ClassName) values(2,'软件2班')
insert into StudentClass(ClassId,ClassName) values(3,'计算机1班')
insert into StudentClass(ClassId,ClassName) values(4,'计算机2班')
insert into StudentClass(ClassId,ClassName) values(5,'网络1班')
insert into StudentClass(ClassId,ClassName) values(6,'网络2班')

--插入学员信息
insert into Student (StudentName,Gender,Dateofbirth,PhoneNumber,StudentAddress,ClassId)
         values('王小虎','男','1989-08-07','022-22222222','天津市南开区红磡公寓5-5-102',1)
,('贺小张','女','1989-05-06','022-33333333','天津市河北区王串场58号',2)
,('张好礼','男','1990-02-07','022-44444444','天津市红桥区丁字沽曙光路79号',4)
,('冯小强','女','1987-05-12','022-55555555',default,2)

--插入卡号
insert into StudentCard (StudentId,CardType)  values(100000,'全日制卡'),(100001,'全日制卡'),(100002,'全日制卡'),(100003,'全日制卡')
         
--插入成绩信息
insert into ScoreList (StudentId,CSharp,SQLDB)values(100000,60,78),(100001,55,88),(100002,90,58),(100003,88,75)

--插入管理员信息
insert into SysAdmin (LoginPwd,AdminName) values(123456,'王晓军'),(123456,'张丽丽')


--显示学员信息和班级信息
select * from Student
select * from StudentClass
select * from ScoreList
select * from SysAdmin
select * from StudentCard





