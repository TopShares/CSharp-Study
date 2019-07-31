--ָ��ǰҪʹ�õ����ݿ�

use master
go
--�жϵ�ǰ���ݿ��Ƿ����
if exists (select * from sysdatabases where name='AdvancedEFDB')
drop database AdvancedEFDB --ɾ�����ݿ�
go
--�������ݿ�
create database AdvancedEFDB
on primary
(
	--���ݿ��ļ����߼���
    name='AdvancedEFDB_data',
    --���ݿ������ļ���������·����
    filename='D:\DB\AdvancedEFDB_data.mdf',
    --���ݿ��ļ���ʼ��С
    size=10MB,
    --�����ļ�������
    filegrowth=1MB
)
--������־�ļ�
log on
(
    name='AdvancedEFDB_log',
    filename='D:\DB\AdvancedEFDB_log.ldf',
    size=2MB,
    filegrowth=1MB
)
go
--����ѧԱ��Ϣ���ݱ�
use AdvancedEFDB
go
--�����༶��
if exists(select * from sysobjects where name='StudentClass')
drop table StudentClass
go
create table StudentClass
(
	ClassId int primary key,
    ClassName varchar(20) not null
)
go
--ѧԱ��Ϣ��
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
    StudentAddress varchar(500) default('��ַ����'),
    ClassId int references StudentClass(ClassId)  --�༶���
)
go
-- һ��ͨ��
if exists(select * from sysobjects where name='StudentCard')
drop table StudentCard
go
create table StudentCard
(
	StudentId  int primary key references Student(StudentId), --ѧ��(һ��һ�Ĺ�ϵ)
	CardType varchar(20) not null    --������
    --FailureTime datetime not null  --ʧЧʱ��(�������Լ�������Ҫ���)
)
go
--�����ɼ���
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
--��������Ա�û���
if exists(select * from sysobjects where name='SysAdmin')
drop table SysAdmin
create table SysAdmin
(
	LoginId int identity(1000,1) primary key,
    LoginPwd varchar(20) not null check(len(LoginPwd)>=6),
    AdminName varchar(20) not null
)
go


-------------------------------------------��������--------------------------------------
use AdvancedEFDB
go

--����༶����
insert into StudentClass(ClassId,ClassName) values(1,'���1��')
insert into StudentClass(ClassId,ClassName) values(2,'���2��')
insert into StudentClass(ClassId,ClassName) values(3,'�����1��')
insert into StudentClass(ClassId,ClassName) values(4,'�����2��')
insert into StudentClass(ClassId,ClassName) values(5,'����1��')
insert into StudentClass(ClassId,ClassName) values(6,'����2��')

--����ѧԱ��Ϣ
insert into Student (StudentName,Gender,Dateofbirth,PhoneNumber,StudentAddress,ClassId)
         values('��С��','��','1989-08-07','022-22222222','������Ͽ�����|��Ԣ5-5-102',1)
,('��С��','Ů','1989-05-06','022-33333333','����кӱ���������58��',2)
,('�ź���','��','1990-02-07','022-44444444','����к��������ֹ����·79��',4)
,('��Сǿ','Ů','1987-05-12','022-55555555',default,2)

--���뿨��
insert into StudentCard (StudentId,CardType)  values(100000,'ȫ���ƿ�'),(100001,'ȫ���ƿ�'),(100002,'ȫ���ƿ�'),(100003,'ȫ���ƿ�')
         
--����ɼ���Ϣ
insert into ScoreList (StudentId,CSharp,SQLDB)values(100000,60,78),(100001,55,88),(100002,90,58),(100003,88,75)

--�������Ա��Ϣ
insert into SysAdmin (LoginPwd,AdminName) values(123456,'������'),(123456,'������')


--��ʾѧԱ��Ϣ�Ͱ༶��Ϣ
select * from Student
select * from StudentClass
select * from ScoreList
select * from SysAdmin
select * from StudentCard





