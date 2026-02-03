CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(100)
);

CREATE TABLE Sales (
    SaleId INT PRIMARY KEY,
    ProductId INT,
    Quantity INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

INSERT INTO Products (ProductId, ProductName) VALUES
(1, 'Laptop'),
(2, 'Mobile'),
(3, 'Tablet'),
(4, 'Headphones'),
(5, 'Smartwatch');

INSERT INTO Sales (SaleId, ProductId, Quantity) VALUES
(101, 1, 2),
(102, 2, 5),
(103, 1, 1),
(104, 4, 3);


select p.ProductId, p.ProductName 
from products p  
left join sales s 
on p.ProductId  =  s.ProductId
where s.ProductId is null;

