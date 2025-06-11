
# ApexAutos - Car Dealership Management System - Database

## 👥 Group Members

| Name              | Student ID     |
|-------------------|----------------|
| Muhammad Bilal       | 241914       |
| Muhammad Talha     | 241890      |

---

## 📘 Description

ApexAutos is a relational database system built using Microsoft SQL Server to manage a car dealership's operations. It covers various entities like customers, employees, suppliers, cars, sales, payments, feedback, and service records.

The project demonstrates:

- Entity-Relationship modeling
- Normalized schema (3NF)
- SQL-based CRUD operations
- A functional frontend using **C# Windows Forms**

---

## 🛠 Setup Instructions

### 1. 📦 Restore the Database

You can restore the database using following method:

#### 💻 Using `.sql` Script

1. Open the `.sql` script file in SSMS.
2. Execute the script to:
   - Create the `ApexAutosDB` database
   - Create all tables with relationships
   - Insert sample data

### 2. 🧪 Run Sample Queries

You can try these test queries to check your setup:

```sql
-- List all available cars
SELECT * FROM Cars WHERE Status = 'Available';

-- Show total sales by each employee
SELECT EmployeeID, SUM(AmountPaid) AS TotalSales FROM Sales GROUP BY EmployeeID;

-- Fetch all customer feedback
SELECT * FROM Feedback;

