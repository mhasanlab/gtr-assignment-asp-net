USE master
GO

DROP DATABASE IF EXISTS AssignmentGTRDB
GO

-- Create Database [AssignmentGTRDB]

CREATE DATABASE AssignmentGTRDB
ON
(
    NAME='AssignmentGTRDB_Data',
    FILENAME='E:\GTRBD ASSIGNMENT\Evidence\AssignmentGTRDB_Data.mdf',
    SIZE= 100MB,
    MAXSIZE=200MB,
    FILEGROWTH=10%
)
LOG ON
(
    NAME='AssignmentGTRDB_Log',
    FILENAME='E:\GTRBD ASSIGNMENT\Evidence\AssignmentGTRDB_Log.ldf',
    SIZE= 50MB,
    MAXSIZE=100MB,
    FILEGROWTH= 1MB
)
GO

-- Use Database

USE AssignmentGTRDB
GO

CREATE TABLE Category
(
    CategoryId INT PRIMARY KEY IDENTITY NOT NULL,
    CategoryName NVARCHAR(75) NOT NULL
)
GO

CREATE TABLE Supplier
(
    SupplierId INT PRIMARY KEY IDENTITY NOT NULL,
    SupplierName NVARCHAR(75) NOT NULL
)
GO

CREATE TABLE Product
(
    ProductId INT PRIMARY KEY IDENTITY NOT NULL,
    ProductName NVARCHAR(75) NOT NULL,
    CategoryId INT REFERENCES Category(CategoryId),
    SupplierId INT REFERENCES Supplier(SupplierId),
    PurchaseDate DATETIME NOT NULL,
    UnitePrice DECIMAL NOT NULL,
    CurrentStock DECIMAL NOT NULL
)
GO

---Stored Procedures

-- Select All Product

CREATE PROCEDURE SpProductSelectAll
AS
BEGIN
SET NOCOUNT ON
SELECT 
    p.ProductId,
    p.ProductName,
    c.CategoryName,
    s.SupplierName,
    p.PurchaseDate,
    p.UnitePrice,
    p.CurrentStock
FROM Product p
JOIN Category c ON p.CategoryId = c.CategoryId
JOIN Supplier s ON p.SupplierId = s.SupplierId
ORDER BY p.ProductId

END
GO

--- Product Select By Id

CREATE PROCEDURE SpProductSelectById
            @ProductId INT
AS
BEGIN
SET NOCOUNT ON
SELECT 
    p.ProductId,
    p.ProductName,
    c.CategoryName,
    s.SupplierName,
    p.PurchaseDate,
    p.UnitePrice,
    p.CurrentStock
FROM Product p
JOIN Category c ON p.CategoryId = c.CategoryId
JOIN Supplier s ON p.SupplierId = s.SupplierId
WHERE ProductId = @ProductId
END
GO

--- Product Insert

CREATE PROCEDURE SpInsertProduct
            @ProductName NVARCHAR(75),
            @CategoryId INT,
            @SupplierId INT,
            @PurchaseDate DATETIME,
            @UnitePrice DECIMAL,
            @CurrentStock DECIMAL
AS
BEGIN
SET NOCOUNT ON
        INSERT INTO Product (ProductName, CategoryId, SupplierId, PurchaseDate, UnitePrice, CurrentStock)
        VALUES(@ProductName, @CategoryId, @SupplierId, @PurchaseDate, @UnitePrice, @CurrentStock)

END
GO


--- Update Product
CREATE PROCEDURE SpUpdateProduct
            @ProductId INT,
            @ProductName NVARCHAR(75),
            @CategoryId INT,
            @SupplierId INT,
            @PurchaseDate DATETIME,
            @UnitePrice DECIMAL,
            @CurrentStock DECIMAL
AS
BEGIN
SET NOCOUNT ON
        UPDATE Product
        SET ProductName = @ProductName,
            CategoryId = @CategoryId,
            SupplierId = @SupplierId,
            PurchaseDate = @PurchaseDate,
            UnitePrice = @UnitePrice,
            CurrentStock = @CurrentStock
        WHERE ProductId = @ProductId

END
GO

--- DELETE Product

CREATE PROCEDURE SpDeleteProduct
            @ProductId INT
AS

BEGIN
SET NOCOUNT ON
        DELETE FROM Product
    WHERE ProductId = @ProductId
END
GO


-- Create an AFTER TRIGGER for  Prevent update or delete

CREATE TRIGGER trPreventUnexectedCategoryUpdateDelete
ON Category
AFTER UPDATE,DELETE
AS
BEGIN
    PRINT 'Update Or delete sells is not possible'
    ROLLBACK TRANSACTION
END
GO



-- Single Statement Table Valued Function Created

CREATE FUNCTION fnFindProductUnitPrice (
    @ProductName NVARCHAR (75)
)
RETURNS TABLE
AS
RETURN
    SELECT 
        ProductName,
        UnitePrice
    FROM
        Product
    WHERE
        ProductName = @ProductName;
GO

