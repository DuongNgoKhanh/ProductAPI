CREATE DATABASE ProductDB;
GO
USE ProductDB;

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL
);
INSERT INTO Products (ProductName, Price, StockQuantity) VALUES 
('Laptop Dell XPS 15', 2000.00, 10),
('Apple iPhone 15 Pro', 1200.00, 15),
('Samsung Galaxy S24 Ultra', 1100.00, 20),
('Sony WH-1000XM5 Headphones', 350.00, 25),
('Logitech MX Master 3 Mouse', 100.00, 50);


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductId, ProductName, Price, StockQuantity FROM Products;
END;

CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ProductId, ProductName, Price, StockQuantity 
    FROM Products 
    WHERE ProductId = @ProductId;
END;


EXEC sp_GetAllProducts;
EXEC sp_GetProductById @ProductId = 2;

