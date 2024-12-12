Use Restaurant_Management
Go
-----Insert Customer
Insert into Customer_Info
Values
(1,'Fariha Khan','fariha@gmail.com','0187582552','123-Dhaka','01225122saasd',0,2),
(2,'Yeasmin','y@gmail.com','01875852552','80-Dhaka','01225122saasd',1,5),
(3,'Md.Jamil','','','80-Dhaka','01225122saasd',1,5)

Go
Select * from Customer_Info
------Insert employees
Insert into Employees
Values
(1,'Fariha Khan','123-Dhaka',20,'Manager','2016-01-02',25000),
(2,'Khan','80-Dhaka',18,'Waiter','2016-01-02',10000),
(3,'MD.Arafat','123-Dhaka',22,'Manager','2017-01-02',20000)

Go
Select * from Employees
-----insert menu_item
Insert into Menu_ITem
Values
(1,newid(),'Rice','Rice with chicken',500,'Rice'),
(2,newid(),'Burger','Mini-Burger',260,'Burger')
Go
Select * from Menu_ITem
---insert orders
Insert into Orders
Values
(1,2,500),
(2,3,260),

Select * from Orders
-----insert orderdetails
Insert into Orders_Details
Values
(1,'2024-07-07',1000,1,1),
(2,'2024-07-07',1000,2,2)
Go
Select * from Orders_Details;
go

--------Marge table 
Merge into Customer_Info As Source
Using Menu_ITem As terget
On Source.Customer_Id=terget.Item_ID
when not  matched then
Insert (Customer_Id,CustomerName)
values (terget.Item_ID,terget.ItemName);
Go
-------- Group by  & Having clause
Select Designation, Sum(Emp_Salary) As Desi_wise_total
from Employees
Group by (Designation)
Having Sum(Emp_Salary)>20000
Go
------Rollup
Select 
    Designation, Sum(Emp_Salary) AS Total
From 
    Employees
Group by rollup (Designation)
GO
-------Top
Select top 2* 
from Employees
Go
------Cast,Covert
Select CAST('2016-01-02' as datetime2) As convertdate
Select CONVERT(Varchar,CONVERT(Date,'2016-01-02'),101) As FormattedDate
Go
--------DateDifferent Calculation
Select Datediff(Year,'2016-01-02','2024-08-03') As Differentyear
Select Datediff(MONTH,'2016-01-02','2024-08-03') As DifferentMonth
Select Datediff(Day,'2016-01-02','2024-08-03') As Differentday
-----------Ranking functions ------
 Select Row_Number() over(order by Emp_id) As Row_count from employees
 Select Ntile(2) over(order by Emp_id) As Row_Ntile from employees
 Select Empname,emp_salary, Rank() over(order by Emp_Salary) As Ranking from employees
 ----------- -----------Subquery------
Select  
   EmpName, 
   Emp_Salary
From 
   Employees
Where 
   Emp_Salary > (Select AVG(Emp_Salary) From Employees);

------Using In operator------
Select * from Menu_ITem
Where ItemName in ('Burger');
GO
----------Write a this  script and see the servername------
Select @@SERVERNAME 'Server'
-------Using Order by clause-----
Select * from Customer_Info--
order by CustomerName DESC
Go
--Using  Like Query
Select * from Employees
Where EmpName like'%k%'--Using  Like Query
Go
----- Using Choose Function Show the MembershipStatus
Select  
    Customer_ID,
    CustomerName,
    Email,
    Mobile_NO,
    Address,
    Cardno,
    IsMember,
    CHOOSE(IsMember + 1, 'Non-Member', 'Member') AS MembershipStatus,
    NoOfperson
From 
    Customer_Info;
------Using between oprator
SELECT 
    OrderID,
    Item_ID,
    Quantity,
    Price
FROM 
    Orders
WHERE 
    Price BETWEEN 100 AND 400;
/*If Email is not NULL, it returns the email address.
 If Email is NULL and Mobile_NO is not NULL, it returns the mobile number.
 If both Email and Mobile_NO are NULL, it returns 'Contact info not available'.*/
SELECT 
    Customer_ID,
    CustomerName,
    COALESCE(Email, Mobile_NO, 'Contact info not available') AS ContactInfo
FROM 
    Customer_Info;






