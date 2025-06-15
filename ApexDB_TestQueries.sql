USE ApexAutos_DB;

---- Sample "CRUD" Quries -----

-- Add a new customer
INSERT INTO Customers (Name, Contact, Email, CNIC)
VALUES ('Adeel Khan', '03009998888', 'adeel@example.com', '35206-1234567-1');

-- Add a new car (Ensure SupplierID 1 and BranchID 2 exist)
INSERT INTO Cars (Make, Model, Year, Color, Price, Status, BranchID, SupplierID)
VALUES ('Toyota', 'Yaris', 2023, 'Red', 3500000, 'Available', 2, 1);

-- List all available cars
SELECT * FROM Cars
WHERE Status = 'Available';

-- View all sales with customer and car details
SELECT 
    S.SaleID, 
    C.Make, 
    C.Model, 
    CU.Name AS CustomerName, 
    S.SaleDate, 
    S.Price
FROM Sales S
JOIN Cars C ON S.CarID = C.CarID
JOIN Customers CU ON S.CustomerID = CU.CustomerID;

-- Mark a car as sold
UPDATE Cars
SET Status = 'Sold'
WHERE CarID = 3;

-- Update customer contact info
UPDATE Customers
SET Contact = '03118887766'
WHERE CustomerID = 1;

-- Delete a feedback record
DELETE FROM Feedback
WHERE FeedbackID = 2;

-- Group Cars by Branch
SELECT 
    B.BranchName, 
    COUNT(C.CarID) AS TotalCars
FROM Cars C
JOIN Branches B ON C.BranchID = B.BranchID
GROUP BY B.BranchName;

-- Group Employees by Branch
SELECT 
    B.BranchName, 
    COUNT(E.EmployeeID) AS TotalEmployees
FROM Employees E
JOIN Branches B ON E.BranchID = B.BranchID
GROUP BY B.BranchName;