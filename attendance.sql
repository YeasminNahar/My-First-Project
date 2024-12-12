Create database Attendance

Go
Use Attendance

Create table employee
(
Empid int primary key,
Empname varchar (30),
joining date,
Department varchar (50),
Designation varchar (40)
)
Create table Working_Type
(
Workingid int primary key,
Workingtypename varchar (50)
)
Create table Attendance_Type
(
Attendance_Typeid int primary key,
Attendancename varchar(30)
)
Create table In_ReasonType
(
Reason_Inid int primary key,
Reasoninname varchar (50)
)
Create table Out_ReasonType
(
Reason_Outid int primary key,
Reasonoutname varchar (50)
)
Create table Office_Schedule
(
Scheduleid int primary key,
Office_Working date,
Start_Time time,
End_Time time,
Workingid int references Working_Type(Workingid),
Attendance_Typeid int references Attendance_Type(Attendance_Typeid),
Consider_Start time,
Consider_End time
)
Create table office_In_Out_details
(
Employee_In datetime,
Employee_out datetime,
Empid int references employee(Empid),
Reason_Inid int references In_ReasonType(Reason_Inid),
Reason_Outid int references Out_ReasonType(Reason_Outid),
In_Remark varchar (50),
Out_Remark varchar (50),
Duration As
CONVERT(VARCHAR, DATEADD(SECOND, DATEDIFF(SECOND, Employee_In, Employee_Out), 0), 108) 
)
-------
Drop table office_In_Out_details;
Go
----======-Index-----------=========----------
Create Index idx_Office_Working 
ON Office_Schedule(Office_Working)
Go
------Testing
EXEC sp_helpindex 'Office_Schedule';
go
-------
Create  Proc InsertOfficeSchedule
    @Scheduleid int,
    @Office_Working date,
    @Start_Time time,
    @End_Time time,
    @Workingid int,
    @Attendance_Typeid int,
    @Consider_Start time,
    @Consider_End time
AS
Begin
-------- -- Insert the record into the Office_Schedule table
Insert into Office_Schedule (Scheduleid, Office_Working, Start_Time, End_Time, Workingid, Attendance_Typeid, Consider_Start, Consider_End)
Values (@Scheduleid, @Office_Working, @Start_Time, @End_Time, @Workingid, @Attendance_Typeid, @Consider_Start, @Consider_End)

--------=============-- Optionally, you can include error handling
IF @@ERROR <> 0
begin
Print 'Error occurred during insertion.'
ROLLBACK TRANSACTION;
End
Else
begin
Print 'Record inserted successfully.'
End
End;
--------Testing 
EXEC InsertOfficeSchedule 
    @Scheduleid = 1, 
    @Office_Working = '2024-08-17', 
    @Start_Time = '09:00', 
    @End_Time = '17:00', 
    @Workingid = 1, 
    @Attendance_Typeid = 2, 
    @Consider_Start = '08:45', 
    @Consider_End = '17:15';
Go
-----Create Trigger -- Set a default department if it's not provided
Create Trigger trg_default_department
ON employee
After insert
AS
Begin
update employee
Set Department = 'General'
Where Empid IN (SELECT Empid FROM inserted) AND Department IS NULL;
End;
----------Testing
Select * from employee
where Empid=4
