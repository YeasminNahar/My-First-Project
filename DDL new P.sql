Use Restaurant_Management
Go
-------Create Customer_info 
Create table Customer_Info
(
Customer_ID int primary key,
CustomerName Nvarchar (30),
Email varchar (30),
Mobile_NO varchar (20),
Address varchar (20),
Cardno Nvarchar (50),
IsMember int ,
NoOfperson int
)

Go
Select * from Customer_Info
Go
-------Create Employees
Create table Employees
(
Emp_ID int primary key,
EmpName nvarchar (30),
Emp_Address varchar (30),
Age int,
Designation varchar (30),
Joining date,
Emp_Salary money
)

Go
Select * from Employees
Go
--------Create Menu_Item
Create table Menu_ITem
(
Item_ID int primary key,
Itemcode uniqueidentifier default newid(),
ItemName Nvarchar (50),
Description text,
Price decimal (18,2),
Category Nvarchar (50)
)

Select * from Menu_ITem
Go
-------Create Orders
Create table Orders
(
OrderID INT PRIMARY KEY IDENTITY(1,1),
Item_ID INT,
Quantity INT,
Price DECIMAL(10, 2),
FOREIGN KEY (Item_ID) REFERENCES Menu_Item(Item_ID)
)

Select * from Orders
Go
-----Create Orders_Details
Create table Orders_Details
(
Order_DetailsID int primary key,
Order_date Date,
Total_Amount decimal (20,2),
Customer_ID int references Customer_Info(Customer_ID),
OrderID int references Orders (OrderID)
)
Go


-- View for Order Details with Customer Information
Create View vw_Order_Details AS
Select
   Order_DetailsID,
   Order_date,
   Total_Amount
    
FRom Orders_Details
Join Customer_Info  ON Orders_Details.Order_DetailsID = Customer_Info.Customer_ID
Go
Select * from vw_Order_Details
----------Index on Orders_Details
Create index ix_order
on Orders_Details(Order_DetailsID)
Go
Exec sp_helpindex 'Orders_Details'
Go

--------Create Sclar Function to calculate Year of service---------
Create  Function CalculateYearsOfService
(
    @JoiningDate DATE
)
RETURNS INT
AS
BEGIN
    Declare @YearsOfService INT;
    Set @YearsOfService = DATEDIFF(YEAR, @JoiningDate, GETDATE());
    Return @YearsOfService;
END;
------Testing-----------
Select 
    Emp_ID,
    EmpName,
    Designation,
    Joining,
    dbo.CalculateYearsOfService(Joining) AS YearsOfService,
    Emp_Salary
From 
    Employees;

Go
---------Create Procedure------
Create or alter proc SPCustomerdetails
@cusId int
AS

Begin
Select Cus.CustomerName,M.ItemName,O.Quantity,O.Price,(O.Quantity * O.Price) AS PriceAmount,OD.Order_date from Orders_Details OD
inner join Customer_Info Cus on Cus.Customer_ID=OD.Customer_ID
inner join  Orders O on O.OrderID=OD.OrderID
inner join Menu_ITem M on M.Item_ID=O.Item_ID where Cus.Customer_ID=@cusId
End
Exec SPCustomerdetails 2

----Create Trigger if employee salary updated 
Create table Salary_Audit
(
    Audit_ID INT PRIMARY KEY IDENTITY(1,1),
    Emp_ID INT,
    Old_Salary MONEY,
    New_Salary MONEY,
    Change_Date DATETIME
)
Go
Create  trigger trg_SalaryUpdate
On Employees
After UPDATE
AS
Begin
 -- Only trigger if the salary has been updated
IF UPDATE(Emp_Salary)
Begin
Insert into Salary_Audit (Emp_ID, Old_Salary, New_Salary, Change_Date)
Select
i.Emp_ID,
d.Emp_Salary AS Old_Salary,
i.Emp_Salary AS New_Salary,
GETDATE() AS Change_Date
            
From
inserted i
JOIN
deleted d ON i.Emp_ID = d.Emp_ID;
end
end
GO
-----Testing
Update Employees
Set Emp_Salary = 50000
Where Emp_ID = 1
-----Check in Salry_Audit table
Select * from Salary_Audit


