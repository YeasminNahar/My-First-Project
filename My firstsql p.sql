--Database create
Create Database My
on(
Name='Myproject',
Filename='F:\ISDB.mdf',
Size=1mb,
Maxsize=1mb,
Filegrowth=10%
)
log on (
Name='Myproject1',
Filename='F:\ISDB.ldf',
Size=1mb,
Maxsize=1mb,
Filegrowth=10%
)
Go
Use My
Go
--we can create a database more way 
/*Create Database Project  -------Multiline comments
Go
Use Project
Go*/
Create table Student  --Create a table
(
StudentId int primary key identity,
Name Varchar (20),
Age Varchar (10),
Section varchar (20)
)
Go
Select * From Student  --Read a table
Go
Insert into Student--Insert data in a table
Values
('Yeasmin','21','A'),
('Fariha','22','B'),
('Mim','23','C'),
('Sweety','24','D'),
('Nilay','25','E')
Go
Alter Table Student--we can add a column using alter 
Add Department varchar (30)
Go
Update Student   --update department values
Set department='CSE'
Go
ALTER TABLE Student--Column delete
DROP COLUMN Section;
Go
Delete --Delete a record in table
from Student
Where StudentId=8
Go
ExEC Sp_Help 'Student' --Details a table
Go
Select top 5* from student--Top
Go
Select * from Student--order by
order by Age DESC
Go
Select * from Student
Where Name like'%y%'--Using  Like Query
Go
--------------------- using Conconnected----------------------------- 

Select name + ' '+ age as Stuinfo
from Student
Go
---------------------------Using get date function----------------------
SELECT GETDATE() AS current_datetime;
go
Select Trim ('  Name   ')--------------using Blank space remove
Go
------------------ Create a Table 2-----------------------------
Create table Admissions
(
AdmitId Int primary key,
Addmissionfee varchar(20),
Batch varchar(30),
studentid Int references Student(StudentId)
)
Go
Insert into Admissions
values
(1,'2000','31A',1),
(2,'3000','31B',2),
(3,'4000','31C',3)
Go

Select * from Admissions--------Read Table 2

Select *        -----------------------------Inner Join------------------
from Student
inner join Admissions
on Student.StudentId=Admissions.AdmitId
Go
Select Datediff (Day,'2003-09-02','2024-07-05')As day----Date Difference calculation------
Select Datediff (Year,'2003-09-02','2024-07-05')As Year
Select Datediff (MONTH,'2003-09-02','2024-07-05')As Month









