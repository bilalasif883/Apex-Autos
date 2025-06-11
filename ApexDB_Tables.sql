-- Create Database as Following
Create Database ApexAutos_DB;
Use ApexAutos_DB;

-- These Tables Are Normalised to the 3NF Each Consisting Primary an Foriegn keys

-- Tables --

-- Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL
);

-- Branches
CREATE TABLE Branches (
    BranchID INT PRIMARY KEY IDENTITY(1,1),
    BranchName NVARCHAR(100),
    Location NVARCHAR(100),
    Contact NVARCHAR(20)
);

-- Employees
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Contact NVARCHAR(20),
    Position NVARCHAR(50),
    BranchID INT,
    FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

-- Cars
CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50),
    Model NVARCHAR(50),
    Year INT,
    Color NVARCHAR(30),
    Price DECIMAL(18,2),
    Status NVARCHAR(20) CHECK (Status IN ('Available', 'Sold')),
    BranchID INT,
    FOREIGN KEY (BranchID) REFERENCES Branches(BranchID)
);

-- Customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Contact NVARCHAR(20),
    Email NVARCHAR(100),
    CNIC NVARCHAR(20)
);

-- Sales
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CarID INT UNIQUE,
    CustomerID INT,
    EmployeeID INT,
    SaleDate DATE,
    Price DECIMAL(18,2),
    FOREIGN KEY (CarID) REFERENCES Cars(CarID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Suppliers
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Contact NVARCHAR(20),
    Email NVARCHAR(100)
);

-- Purchases
CREATE TABLE Purchases (
    PurchaseID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT,
    CarID INT UNIQUE,
    PurchaseDate DATE,
    Cost DECIMAL(18,2),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (CarID) REFERENCES Cars(CarID)
);

-- Feedback
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    Message NVARCHAR(MAX),
    FeedbackDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

--Car Sales Audit
CREATE TABLE CarSalesAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    CarName VARCHAR(100),
    Make VARCHAR(100),
    Model VARCHAR(100),
    RecordedAt DATETIME DEFAULT GETDATE()
);

--Employee Audit
CREATE TABLE EmployeeAudit (
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT,
    Name NVARCHAR(100),
    Contact NVARCHAR(20),
    Position NVARCHAR(50),
    BranchID INT,
    ActionType NVARCHAR(10),        
    ActionDate DATETIME DEFAULT GETDATE()
);


-- Sample Data --

-- Users
INSERT INTO Users (Username, Password) VALUES
('Muhammad Bilal', '241914'),
('Muhammad Talha', '241890');

-- Branches
INSERT INTO Branches (BranchName, Location, Contact) VALUES
('Apex Autos', 'Lahore', '042-1234567'),
('Apex Motors', 'Karachi', '021-2345678'),
('Apex Automotive', 'Islamabad', '051-3456789'),
('Apex Autos Peshawar', 'Peshawar', '091-4567890'),
('Apex Autos Multan', 'Multan', '061-5678901');

-- Employees
INSERT INTO Employees (Name, Contact, Position, BranchID) VALUES
('Ali Raza', '03001234567', 'Sales Rep', 1),
('Fatima Khan', '03111234567', 'Manager', 2),
('Usman Tariq', '03211234567', 'Technician', 3),
('Sara Ahmed', '03331234567', 'Sales Rep', 1),
('Imran Shah', '03451234567', 'Accountant', 4);

-- Cars
INSERT INTO Cars (Make, Model, Year, Color, Price, Status, BranchID) VALUES
('Toyota', 'Corolla', 2022, 'White', 4000000, 'Available', 1),
('Honda', 'Civic', 2023, 'Black', 5000000, 'Sold', 1),
('Suzuki', 'Alto', 2021, 'Silver', 2200000, 'Available', 2),
('KIA', 'Sportage', 2022, 'Red', 5800000, 'Available', 3),
('Hyundai', 'Elantra', 2022, 'Blue', 5100000, 'Available', 2);

-- Customers
INSERT INTO Customers (Name, Contact, Email, CNIC) VALUES
('Zain Ali', '03011234567', 'zain@example.com', '35201-1234567-1'),
('Hina Malik', '03111234567', 'hina@example.com', '35202-2345678-2'),
('Ahmed Raza', '03211234567', 'ahmed@example.com', '35203-3456789-3'),
('Mehak Shah', '03311234567', 'mehak@example.com', '35204-4567890-4'),
('Bilal Tariq', '03411234567', 'bilal@example.com', '35205-5678901-5');

-- Sales
INSERT INTO Sales (CarID, CustomerID, EmployeeID, SaleDate, Price) VALUES
(2, 1, 1, '2024-04-15', 4900000);

-- Suppliers
INSERT INTO Suppliers (Name, Contact, Email) VALUES
('Auto Imports', '04212345678', 'auto@imports.com'),
('Pak Traders', '04123456789', 'contact@paktraders.com'),
('Speed Motors', '03122334455', 'sales@speedmotors.com'),
('Elite Autos', '02133445566', 'info@eliteautos.com'),
('Toyota pvt LTD', '05155667788', 'support@metro.com');

-- Purchases
INSERT INTO Purchases (SupplierID, CarID, PurchaseDate, Cost) VALUES
(1, 1, '2023-11-20', 3900000),
(2, 2, '2023-12-01', 4700000),
(3, 3, '2024-01-10', 2100000),
(4, 4, '2024-02-05', 5700000),
(5, 5, '2024-03-01', 5000000);

-- Feedback
INSERT INTO Feedback (CustomerID, Message, FeedbackDate) VALUES
(1, 'Great service, friendly staff!', '2024-04-16'),
(2, 'I love my new car!', '2024-04-17'),
(3, 'Helpful team and fast delivery.', '2024-04-18'),
(4, 'Smooth purchase process.', '2024-04-19'),
(5, 'Highly recommended dealership.', '2024-04-20');
