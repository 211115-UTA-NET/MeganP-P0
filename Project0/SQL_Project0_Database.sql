
--Create tables
CREATE TABLE People (
    PersonID INT IDENTITY(1, 1) NOT NULL,
    FirstName VARCHAR(1000) NOT NULL,
    LastName VARCHAR(1000) NOT NULL,
    Username VARCHAR(1000) NOT NULL,
    [Password] VARCHAR(2000) NOT NULL,
    [Role] VARCHAR(600) NOT NULL,
    Balance MONEY NOT NULL,
    StoreID  INT NULL,
    PRIMARY KEY(PersonID)
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1, 1) NOT NULL,
    StoreID INT NOT NULL,
    PersonID INT NOT NULL,
    Total MONEY NOT NULL,
    [TimeStamp] DATETIME NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
    PRIMARY KEY(OrderID)
);

CREATE TABLE PurchasedItems (
    PurchaseID INT IDENTITY(1, 1) NOT NULL,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price MONEY NOT NULL,
    PRIMARY KEY(PurchaseID)
);

CREATE TABLE Inventories (
    ProductID INT NOT NULL,
    StoreID INT NOT NULL,
    Quantity INT NOT NULL,
    PRIMARY KEY(ProductID, StoreID)
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1, 1) NOT NULL,
    [Name] VARCHAR(1000) NOT NULL,
    SalePrice MONEY NOT NULL,
    PurchasePrice MONEY NOT NULL,
    PRIMARY KEY(ProductID)
);

CREATE TABLE Stores (
    StoreID INT IDENTITY(1, 1) NOT NULL,
    PersonID INT NOT NULL,
    [Location] VARCHAR(1000) NOT NULL,
    PRIMARY KEY(StoreID)
);

--Add foreign keys
--Foreign key for People
ALTER TABLE People ADD CONSTRAINT FK_People_StoreID FOREIGN KEY(StoreID) REFERENCES Stores(StoreID);

--Foreign keys for Orders
ALTER TABLE Orders ADD CONSTRAINT FK_Orders_StoreID FOREIGN KEY(StoreID) REFERENCES Stores(StoreID);
ALTER TABLE Orders ADD CONSTRAINT FK_Orders_PersonID FOREIGN KEY(PersonID) REFERENCES People(PersonID);

--Foreign keys for PurchasedItems
ALTER TABLE PurchasedItems ADD CONSTRAINT FK_PurchasedItems_OrderID FOREIGN KEY(OrderID) REFERENCES Orders(OrderID);
ALTER TABLE PurchasedItems ADD CONSTRAINT FK_PurchasedItems_ProductID FOREIGN KEY(ProductID) REFERENCES Products(ProductID);

--Foreign keys for Inventories
ALTER TABLE Inventories ADD CONSTRAINT FK_Inventories_ProductID FOREIGN KEY(ProductID) REFERENCES Products(ProductID);
ALTER TABLE Inventories ADD CONSTRAINT FK_Inventories_StoreID FOREIGN KEY(StoreID) REFERENCES Stores(StoreID);

--Foreign key for Stores
ALTER TABLE Stores ADD CONSTRAINT FK_Store_PersonID FOREIGN KEY(PersonID) REFERENCES People(PersonID);


--Insert initial data

INSERT INTO People(FirstName, LastName, Username, [Password], [Role], Balance) VALUES
('Megan', 'Postlewait', 'meganpostlewait', 'testpassword', 'Owner', 1000000); --1

INSERT INTO Stores(PersonID, [Location]) VALUES
(1, 'Rochester'), --1
(1, 'Astoria'); --2

INSERT INTO People(FirstName, LastName, Username, [Password], [Role], Balance, StoreID) VALUES
('Myra', 'Gold', 'myragold', 'testtesttest', 'Customer', 12000, 1);

INSERT INTO Products([Name], SalePrice, PurchasePrice) VALUES
('Poisoned Apple', 1100, 110), --1
('Dark Curse', 5000, 500), --2
('Magic Bean', 10000, 1000), --3
('Forgetting Potion', 100, 10), --4
('Locator Potion', 100, 10), --5
('Sleeping Curse', 1100, 110), --6
('Mermaid Legs Bracelet', 2000, 200), --7
('Flying Carpet', 7500, 750), --8
('Water from the River of Lost Souls', 3000, 300), --9
('Squid Ink', 300, 30); --10

INSERT INTO Inventories(ProductID, StoreID, Quantity) VALUES
(1, 1, 100),
(2, 1, 5),
(3, 1, 2),
(4, 1, 5000),
(5, 1, 5000),
(6, 1, 400),
(7, 1, 6),
(8, 1, 1),
(9, 1, 10),
(10, 1, 30),
(1, 2, 100),
(2, 2, 5),
(3, 2, 2),
(4, 2, 5000),
(5, 2, 5000),
(6, 2, 400),
(7, 2, 6),
(8, 2, 1),
(9, 2, 10),
(10, 2, 30);

SELECT * FROM People;
SELECT * FROM Products;
SELECT * FROM Stores;
SELECT * FROM Inventories;

--Get recent order id number
SELECT MAX(ProductID) FROM Products

SELECT * FROM Orders;
SELECT * FROM  PurchasedItems;
SELECT * FROM Inventories;

--UPDATE product inventory
UPDATE Inventories
SET
Quantity = 30
WHERE ProductID = 10 AND StoreID = 1;

--store get all orders
SELECT Orders.*, PurchasedItems.PurchaseID, PurchasedItems.Quantity, PurchasedItems.Price, Products.ProductID, Products.Name
FROM Orders 
INNER JOIN PurchasedItems 
ON Orders.OrderID = PurchasedItems.OrderID
INNER JOIN Products
ON PurchasedItems.ProductID = Products.ProductID
WHERE Orders.PersonID = 1

--load products
SELECT Products.*, Inventories.Quantity
FROM Products
INNER JOIN Inventories
ON Products.ProductID = Inventories.ProductID
WHERE Inventories.StoreID = 1

--load person
SELECT * FROM People
WHERE Username = 'myragold';

SELECT * FROM Stores
WHERE StoreID = 1;


SELECT Stores.StoreID 
FROM Stores 
INNER JOIN People 
ON Stores.PersonID = People.PersonID 
WHERE People.Username = 'meganpostlewait';






