Use ApexAutos_DB;

-- These are Manual Sample SQL Quries

-- Add a new customer
INSERT INTO Customers (Name, Contact, Email, CNIC)
VALUES ('Adeel Khan', '03009998888', 'adeel@example.com', '35206-1234567-1');

-- Add a new car
INSERT INTO Cars (Make, Model, Year, Color, Price, Status, BranchID)
VALUES ('Toyota', 'Yaris', 2023, 'Red', 3500000, 'Available', 2);

-- List all available cars
SELECT * FROM Cars WHERE Status = 'Available';

-- View all sales with customer and car details
SELECT S.SaleID, C.Make, C.Model, CU.Name AS CustomerName, S.SaleDate, S.Price
FROM Sales S
JOIN Cars C ON S.CarID = C.CarID
JOIN Customers CU ON S.CustomerID = CU.CustomerID;

-- Mark a car as sold
UPDATE Cars SET Status = 'Sold' WHERE CarID = 3;

-- Update customer contact info
UPDATE Customers SET Contact = '03118887766' WHERE CustomerID = 1;

-- Delete a feedback record
DELETE FROM Feedback WHERE FeedbackID = 2;


-- Group Cars by Branch
SELECT B.BranchName, COUNT(C.CarID) AS TotalCars
FROM Cars C
JOIN Branches B ON C.BranchID = B.BranchID
GROUP BY B.BranchName;

-- Group Employess by Branch
SELECT B.BranchName, COUNT(E.EmployeeID) AS TotalEmployees
FROM Employees E
JOIN Branches B ON E.BranchID = B.BranchID
GROUP BY B.BranchName;

--trigger for employee audit
CREATE TRIGGER dlt_emp
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeAudit (EmployeeID, Name, Contact, Position, ActionType)
    SELECT 
        EmployeeID,
        Name,
        Contact,
        Position,
        'DELETE'
    FROM deleted;
END;

--trigger for car audit
CREATE TRIGGER dlt_car
ON Cars
AFTER DELETE
AS
BEGIN
    INSERT INTO CarSalesAudit (CarName, Make, Model)
    SELECT 
        Make + ' ' + Model AS CarName,
        Make,
        Model
    FROM deleted;
END;


