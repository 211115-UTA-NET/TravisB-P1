CREATE TABLE Locations
(
    StoreID TINYINT PRIMARY KEY,
    City NVARCHAR(25) NOT NULL
)

CREATE TABLE Inventory
(
    ItemID TINYINT,
    StoreID TINYINT FOREIGN KEY REFERENCES Locations(StoreID) NOT NULL, 
    Quantity SMALLINT,
    PRIMARY KEY (ItemID, StoreID),
)

CREATE TABLE Items
(
    ItemID TINYINT PRIMARY KEY,
    ItemName NVARCHAR(30) NOT NULL,
    ItemDescrip NVARCHAR(300),
)
ALTER TABLE Inventory ADD FOREIGN KEY (ItemID) REFERENCES Items(ItemID)



INSERT INTO Inventory
(ItemID, StoreID, Quantity)
VALUES
    (1, 1, 500),
    (2, 1, 500),
    (3, 1, 150),
    (4, 1, 150),
    (5, 1, 150);

INSERT INTO Locations
(StoreID, City)
VALUES
(1, 'Minneapolis'),
(2, 'Robbinsdale'),
(3, 'Plymouth'),
(4, 'Maple Grove');

INSERT INTO Items
(ItemID, ItemName, ItemDescrip)
VALUES
(1, 'Cheese', 'A delicious mix of provolone and mozzarella cheeses.'),
(2, 'Pepperoni', 'Delicious cheese pizza with an extra friend, the pepperoni slice.'),
(3, 'Hawaiian', 'A contentious pizza with many detractors. Pineapple and Canadian bacon on mozzarella cheese.'),
(4, 'Alfredo', 'Grilled chicken slices and onion atop a bed of mozzarella and feta cheeses and white alfredo sauce.'),
(5, 'Deluxe', 'A delicious mix of mozzarella cheese layered on top with green peppers, black olives and onions.');


CREATE TABLE Customers
(
    CustomerID SMALLINT IDENTITY PRIMARY KEY,
    CustomerName NVARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Orders
(
    OrderID INT IDENTITY,
    CustomerName NVARCHAR(200) FOREIGN KEY REFERENCES Customers(CustomerName) NOT NULL,
    LocationID TINYINT NOT NULL,
    ItemID INT NOT NULL,
    QuantityOrdered SMALLINT NOT NULL,
    PRIMARY KEY (OrderID, ItemID)
);

INSERT INTO Inventory
(ItemID, StoreID, Quantity)
VALUES
    (1, 2, 500),
    (2, 2, 500),
    (3, 2, 150),
    (4, 2, 150),
    (5, 2, 150),
    (1, 3, 500),
    (2, 3, 500),
    (3, 3, 150),
    (4, 3, 150),
    (5, 3, 150),
    (1, 4, 500),
    (2, 4, 500),
    (3, 4, 150),
    (4, 4, 150),
    (5, 4, 150);

SELECT ItemName, ItemDescrip, ItemPrice FROM Items;