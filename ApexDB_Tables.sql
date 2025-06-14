CREATE DATABASE ApexAutos_DB;
GO
USE ApexAutos_DB;
GO

-- BRANCHES TABLE
CREATE TABLE Branches (
    BranchID INT PRIMARY KEY IDENTITY(1,1),
    BranchName NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100),
    Contact NVARCHAR(20)
);

-- EMPLOYEES TABLE
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(20),
    Position NVARCHAR(50),
    BranchID INT,
    FOREIGN KEY (BranchID) REFERENCES Branches(BranchID) ON DELETE SET NULL
);

-- USERS TABLE
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    EmployeeID INT NOT NULL UNIQUE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);

-- CUSTOMERS TABLE
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(20),
    Email NVARCHAR(100),
    CNIC NVARCHAR(20)
);

-- SUPPLIERS TABLE
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(20),
    Email NVARCHAR(100)
);

-- CARS TABLE
CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50),
    Model NVARCHAR(50),
    Year INT,
    Color NVARCHAR(30),
    Price DECIMAL(18,2),
    Status NVARCHAR(20) CHECK (Status IN ('Available', 'Sold')),
    BranchID INT,
    SupplierID INT,
    FOREIGN KEY (BranchID) REFERENCES Branches(BranchID) ON DELETE SET NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE SET NULL
);

-- SALES TABLE
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CarID INT,
    CustomerID INT,
    EmployeeID INT,
    SaleDate DATE,
    Price DECIMAL(18,2),
    FOREIGN KEY (CarID) REFERENCES Cars(CarID) ON DELETE SET NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE SET NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);

-- PURCHASES TABLE
CREATE TABLE Purchases (
    PurchaseID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT,
    CarID INT,
    PurchaseDate DATE,
    Cost DECIMAL(18,2),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE SET NULL,
    FOREIGN KEY (CarID) REFERENCES Cars(CarID) ON DELETE SET NULL
);

-- FEEDBACK TABLE
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    Message NVARCHAR(MAX),
    FeedbackDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE
);

INSERT INTO Branches (BranchName, Location, Contact) VALUES
('Apex Autos Lahore',      'Lahore',     '042‑1111111'),
('Apex Autos Karachi',     'Karachi',    '021‑2222222'),
('Apex Autos Islamabad',   'Islamabad',  '051‑3333333'),
('Apex Autos Peshawar',    'Peshawar',   '091‑4444444');

INSERT INTO Suppliers (Name, Contact, Email) VALUES
('Pak Motors',          '042‑5550101', 'info@pakmotors.pk'),
('Auto World',          '021‑5550202', 'sales@autoworld.pk'),
('Metro Cars',          '051‑5550303', 'contact@metrocars.pk'),
('Speedy Suppliers',    '041‑5550404', 'hello@speedy.pk'),
('Prime Auto Deals',    '091‑5550505', 'prime@autodeals.pk'),
('Elite Motors',        '061‑5550606', 'support@elitemotors.pk'),
('Car Import Hub',      '081‑5550707', 'hub@carimport.pk'),
('Galaxy Wheels',       '042‑5550808', 'info@galaxywheels.pk'),
('Sunrise Autos',       '021‑5550909', 'team@sunrise.pk'),
('Legend Suppliers',    '051‑5551010', 'legend@suppliers.pk');


INSERT INTO Employees (Name, Contact, Position, BranchID) VALUES
('Ali Raza',        '0300‑7000001', 'Sales Executive', 1),
('Hina Malik',      '0301‑7000002', 'Manager',         1),
('Usman Tariq',     '0302‑7000003', 'Technician',      2),
('Sara Ahmed',      '0303‑7000004', 'Sales Executive', 2),
('Bilal Shah',      '0304‑7000005', 'Accountant',      3),
('Nida Khan',       '0305‑7000006', 'Receptionist',    3),
('Farhan Akbar',    '0306‑7000007', 'HR Manager',      4),
('Tariq Mehmood',   '0307‑7000008', 'Cleaner',         4),
('Areeba Yousaf',   '0308‑7000009', 'Inventory Clerk', 1),
('Hassan Rauf',     '0309‑7000010', 'IT Support',      2),
('Muhammad Bilal', '0304-7000011',	'Manager',         2),
('Muhammad Talha', '0304-7000012',	'Manager',         3);

INSERT INTO Users (Username, Password, EmployeeID) VALUES
('admin', 'admin', 2),
('bilal', '241914', 11),
('talha', '241890', 12);

INSERT INTO Customers (Name, Contact, Email, CNIC) VALUES
('Zain Ali',        '0321‑8000001', 'zain.ali@example.com',        '35201‑1111111‑1'),
('Mehwish Fatima',  '0321‑8000002', 'mehwish.fatima@example.com',  '35202‑2222222‑2'),
('Ahmed Raza',      '0321‑8000003', 'ahmed.raza@example.com',      '35203‑3333333‑3'),
('Nimra Shah',      '0321‑8000004', 'nimra.shah@example.com',      '35204‑4444444‑4'),
('Talha Tariq',     '0321‑8000005', 'talha.tariq@example.com',     '35205‑5555555‑5'),
('Hassan Bilal',    '0321‑8000006', 'hassan.bilal@example.com',    '35206‑6666666‑6'),
('Areeba Khan',     '0321‑8000007', 'areeba.khan@example.com',     '35207‑7777777‑7'),
('Kashif Iqbal',    '0321‑8000008', 'kashif.iqbal@example.com',    '35208‑8888888‑8'),
('Sadia Munir',     '0321‑8000009', 'sadia.munir@example.com',     '35209‑9999999‑9'),
('Furqan Latif',    '0321‑8000010', 'furqan.latif@example.com',    '35210‑0000000‑0');


INSERT INTO Cars (Make, Model, Year, Color, Price, Status, BranchID, SupplierID) VALUES
-- ===== Branch 1  =========================================================
('Toyota',  'Corolla SE',        2024, 'White',  4650000.00, 'Available', 1, 1),
('Honda',   'City Aspire',       2023, 'Silver', 3450000.00, 'Available', 1, 2),
('Suzuki',  'Cultus VXL',        2022, 'Red',    2850000.00, 'Sold',      1, 3),
('KIA',     'Sportage Alpha',    2024, 'Blue',   6800000.00, 'Available', 1, 4),
('Hyundai', 'Elantra GLS',       2023, 'Grey',   5150000.00, 'Available', 1, 5),

-- ===== Branch 2  =========================================================
('Toyota',  'Yaris ATIV',        2024, 'White',  3750000.00, 'Sold',      2, 2),
('Honda',   'Civic RS',          2024, 'Black',  7250000.00, 'Available', 2, 6),
('Suzuki',  'Swift GLX',         2023, 'Red',    3450000.00, 'Available', 2, 7),
('MG',      'HS Essence',        2023, 'Silver', 8500000.00, 'Available', 2, 8),
('Changan', 'Alsvin Lumiere',    2023, 'Blue',   3550000.00, 'Sold',      2, 2),

-- ===== Branch 3  =========================================================
('Proton',  'Saga Ace',          2022, 'Maroon', 2800000.00, 'Available', 3, 7),
('KIA',     'Picanto AT',        2023, 'Yellow', 2950000.00, 'Available', 3, 4),
('Hyundai', 'Tucson AWD',        2024, 'Grey',   7200000.00, 'Sold',      3, 5),
('DFSK',    'Glory 580 Pro',     2024, 'White',  4650000.00, 'Available', 3, 8),
('Haval',   'H6 HEV',            2024, 'Green',  8350000.00, 'Available', 3, 9),

-- ===== Branch 4  =========================================================
('Peugeot', '2008 Allure',       2024, 'Orange', 5500000.00, 'Available', 4, 9),
('KIA',     'Sorento 3.5 FWD',   2023, 'Black',  8300000.00, 'Sold',      4, 4),
('Toyota',  'Fortuner G',        2024, 'White', 10300000.00, 'Available', 4, 1),
('Honda',   'BR‑V i‑VTEC S',     2023, 'Silver', 4450000.00, 'Available', 4, 6),
('Suzuki',  'Jimny',             2023, 'Green',  4800000.00, 'Available', 4, 3);

INSERT INTO Purchases (SupplierID, CarID, PurchaseDate, Cost) VALUES
(1,  1, '2023‑12‑10', 4600000),
(2,  2, '2023‑12‑15', 5400000),
(3,  3, '2024‑02‑05', 3300000),
(4,  4, '2024‑02‑20', 6500000),
(5,  5, '2024‑03‑01', 6900000),
(6,  6, '2024‑03‑15', 8100000),
(7,  7, '2024‑04‑01', 2600000),
(2,  8, '2024‑04‑10', 3400000),
(8,  9, '2024‑05‑05', 4400000),
(9, 10, '2024‑05‑20', 5300000);

INSERT INTO Sales (CarID, CustomerID, EmployeeID, SaleDate, Price) VALUES
(2,  1, 1, '2024‑06‑01', 5500000),
(4,  2, 2, '2024‑06‑05', 6700000),
(7,  3, 3, '2024‑06‑07', 2800000),
(8,  4, 4, '2024‑06‑10', 3450000),
(10, 5, 5, '2024‑06‑12', 5600000),
(2,  6, 6, '2025‑03‑01', 5300000),
(4,  7, 7, '2025‑03‑10', 6400000),
(7,  8, 8, '2025‑03‑15', 2650000),
(8,  9, 9, '2025‑03‑20', 3300000),
(10,10,10,'2025‑03‑25', 5400000);

INSERT INTO Feedback (CustomerID, Message, FeedbackDate) VALUES
(1,  'Smooth buying experience!',               '2024‑06‑02'),
(2,  'Helpful staff and quick process.',        '2024‑06‑06'),
(3,  'Loved the variety of cars.',              '2024‑06‑08'),
(4,  'Satisfied with after‑sales service.',     '2024‑06‑11'),
(5,  'Paperwork was well organized.',           '2024‑06‑13'),
(6,  'Great trade‑in value offered.',           '2025‑03‑02'),
(7,  'Salesperson was very friendly.',          '2025‑03‑11'),
(8,  'Need more color options in stock.',       '2025‑03‑16'),
(9,  'Appreciated transparent pricing.',        '2025‑03‑21'),
(10, 'Will recommend ApexAutos to friends.',    '2025‑03‑26');