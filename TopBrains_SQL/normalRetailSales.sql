CREATE DATABASE RetailSalesDB;


USE RetailSalesDB;


CREATE TABLE Customers
(
    CustomerID INT IDENTITY PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    CustomerPhone VARCHAR(20) UNIQUE,
    CustomerCity VARCHAR(50)
);

CREATE TABLE SalesPersons
(
    SalesPersonID INT IDENTITY PRIMARY KEY,
    SalesPersonName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Products
(
    ProductID INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    OrderDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    SalesPersonID INT NOT NULL,

    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY(SalesPersonID) REFERENCES SalesPersons(SalesPersonID)
);

CREATE TABLE OrderDetails
(
    OrderDetailID INT IDENTITY PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,

    FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
);


INSERT INTO Customers(CustomerName, CustomerPhone, CustomerCity)
VALUES 
('Arjun','9876543210','Hyderabad'),
('Mari','9123456789','Bangalore'),
('Navneet','463432323','Delhi'),
('Raman','3435364433','Pune'),
('Pavan','5436325335','Mumbai');

INSERT INTO SalesPersons(SalesPersonName)
VALUES ('Anitha'), ('Suresh');

INSERT INTO Products(ProductName)
VALUES ('Laptop'), ('Watch'), ('Keyboard'), ('Mobile');

INSERT INTO Orders(OrderID, OrderDate, CustomerID, SalesPersonID)
VALUES
(101,'2026-01-05',1,1),
(102,'2026-01-06',2,1),
(103,'2025-01-10',1,2),
(104,'2025-02-01',3,1),
(105,'2024-02-10',2,2);

INSERT INTO OrderDetails(OrderID, ProductID, Quantity, UnitPrice)
VALUES
(101,1,1,55000),
(101,2,2,500),

(102,3,1,1500),
(102,2,1,500),

(103,1,1,54000),

(104,4,1,12000),
(104,2,1,500),

(105,1,1,56000),
(105,3,1,1500);

-- Q1 Order Report

SELECT 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    p.ProductName,
    od.Quantity,
    od.UnitPrice,
    (od.Quantity * od.UnitPrice) AS TotalAmount
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID;

-- Q2 THIRD HIGHEST TOTAL SALES ORDER
WITH OrderTotals AS
(
    SELECT 
        o.OrderID,
        SUM(od.Quantity * od.UnitPrice) AS TotalSales
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY o.OrderID
),
RankedOrders AS
(
    SELECT *,
           DENSE_RANK() OVER (ORDER BY TotalSales DESC) AS SalesRank
    FROM OrderTotals
)
SELECT OrderID, TotalSales
FROM RankedOrders
WHERE SalesRank = 3;

-- Q3 SALESPERSONS WITH SALES > 60000
SELECT 
    sp.SalesPersonName,
    SUM(od.Quantity * od.UnitPrice) AS TotalRevenue
FROM SalesPersons sp
JOIN Orders o ON sp.SalesPersonID = o.SalesPersonID
JOIN OrderDetails od ON o.OrderID = od.OrderID
GROUP BY sp.SalesPersonName
HAVING SUM(od.Quantity * od.UnitPrice) > 60000;

-- Q4 CUSTOMERS WHO SPENT ABOVE AVERAGE (Fixed)
SELECT CustomerName, TotalSpent
FROM
(
    SELECT 
        c.CustomerName,
        SUM(od.Quantity * od.UnitPrice) AS TotalSpent
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY c.CustomerName
) AS CustomerTotals
WHERE TotalSpent >
(
    SELECT AVG(TotalSpent)
    FROM
    (
        SELECT SUM(od.Quantity * od.UnitPrice) AS TotalSpent
        FROM Customers c
        JOIN Orders o ON c.CustomerID = o.CustomerID
        JOIN OrderDetails od ON o.OrderID = od.OrderID
        GROUP BY c.CustomerName
    ) AS AvgTable
);

-- Q5 STRING + DATE FUNCTIONS

SELECT 
    UPPER(c.CustomerName) AS CustomerUpper,
    DATENAME(MONTH, o.OrderDate) AS OrderMonth,
    o.OrderID,
    o.OrderDate
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE MONTH(o.OrderDate) = 1
  AND YEAR(o.OrderDate) = 2026;
