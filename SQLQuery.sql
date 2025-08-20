CREATE DATABASE ProductManagementDB;
USE ProductManagementDB;

-- Categories Table
CREATE TABLE Categories (
    CategoryId INT identity PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL)


-- Attributes Table (each category can have multiple attributes)
CREATE TABLE Attributes (
    AttributeId INT identity PRIMARY KEY,
    CategoryId INT,
    AttributeName VARCHAR(100),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId))


-- Products Table
CREATE TABLE Products (
    ProductId INT identity PRIMARY KEY,
    ProductName VARCHAR(200) NOT NULL,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId))


-- Product Attribute Values (Dynamic values for each product)
CREATE TABLE ProductAttributeValues (
    ProductId INT,
    AttributeId INT,
    AttributeValue VARCHAR(200),
    PRIMARY KEY (ProductId, AttributeId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (AttributeId) REFERENCES Attributes(AttributeId))

    -- Categories Table
INSERT INTO Categories (CategoryName) VALUES
('Dresses'),
('Shoes'),
('Watches'),
('Smartphones')

-- Category Attributes Table
INSERT INTO Attributes (CategoryId, AttributeName) VALUES
(1, 'Size'),       -- Dresses
(1, 'Color'),
(2, 'ShoeSize'),   -- Shoes
(2, 'Material'),
(3, 'DialColor'),  -- Watches
(3, 'StrapType'),
(4, 'OS'),         -- Smartphones
(4, 'RAM'),
(4, 'BatterySize')

-- Products Table
INSERT INTO Products (CategoryId, ProductName) VALUES
(1, 'Summer Dress'),
(2, 'Running Shoes'),
(3, 'Classic Watch'),
(4, 'Android Phone')

-- Product Attribute Values
INSERT INTO ProductAttributeValues (ProductId, AttributeId, AttributeValue) VALUES
(1, 1, 'M'),                 -- Dress Size
(1, 2, 'Red'),               -- Dress Color
(2, 3, '42'),                -- Shoe Size
(2, 4, 'Leather'),           -- Shoe Material
(3, 5, 'Black'),             -- Watch DialColor
(3, 6, 'Metal Strap'),       -- Watch StrapType
(4, 7, 'Android 13'),        -- Smartphone OS
(4, 8, '8GB'),               -- Smartphone RAM
(4, 9, '5000mAh')          -- Smartphone Battery
