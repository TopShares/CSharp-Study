use EFDB
go
if exists(select * from sysobjects where name='usp_updateStu')
drop procedure usp_updateStu
go
create procedure usp_updateStu
@StudentName varchar(20),
@StudentId int
as
	update Students set StudentName=@StudentName where StudentId=@StudentId
go

if exists(select * from sysobjects where name='usp_selectStu')
drop procedure usp_selectStu
go
create procedure usp_selectStu
@ClassId int
as
	select * from Students where ClassId=@ClassId
go



 

use EFDB
go
if exists(select * from sysobjects where name='usp_updateStu')
drop procedure usp_updateStu
go
create procedure usp_updateStu
@StudentName varchar(20),
@StudentId int 
as
      update Students set StudentName=@StudentName where StudentId=@StudentId
go
if exists(select * from sysobjects where name='usp_selectStu')
drop procedure usp_selectStu
go
create procedure usp_selectStu
@ClassId int
as
    select * from Students where ClassId=@ClassId
go
