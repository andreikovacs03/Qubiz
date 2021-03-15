--setup data

CREATE TABLE Manufacturers (
        Code INT PRIMARY KEY NOT NULL,
        Name VARCHAR(100) NOT NULL 
);

CREATE TABLE Products (
        Code INT PRIMARY KEY NOT NULL,
        Name VARCHAR(100) NOT NULL ,
        Price REAL NOT NULL ,
        Manufacturer INTEGER NOT NULL 
                CONSTRAINT fk_Manufacturers_Code REFERENCES MANUFACTURERS(Code)
);
INSERT INTO Manufacturers(Code,Name) VALUES(1,'Sony');
INSERT INTO Manufacturers(Code,Name) VALUES(2,'Creative Labs');
INSERT INTO Manufacturers(Code,Name) VALUES(3,'Hewlett-Packard');
INSERT INTO Manufacturers(Code,Name) VALUES(4,'Iomega');
INSERT INTO Manufacturers(Code,Name) VALUES(5,'Fujitsu');
INSERT INTO Manufacturers(Code,Name) VALUES(6,'Winchester');

INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(1,'Hard drive',240,5);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(2,'Memory',120,6);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(3,'ZIP drive',150,4);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(4,'Floppy disk',5,6);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(5,'Monitor',240,1);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(6,'DVD drive',180,2);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(7,'CD drive',90,2);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(8,'Printer',270,3);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(9,'Toner cartridge',66,3);
INSERT INTO Products(Code,Name,Price,Manufacturer) VALUES(10,'DVD burner',180,2);

GO

--1. Select the names of all the products in the store.
SELECT Name FROM Products;

--2. Select the names and the prices of all the products in the store.
SELECT Name, Price FROM Products;

--3. Select the name of the products with a price less than or equal to $200.
SELECT Name FROM Products WHERE Price <= 200;

--4. Select all the products with a price between $60 and $120.
SELECT * FROM Products WHERE Price >= 60 AND Price <= 120;

--5. Select the name and price in cents (i.e., the price must be multiplied by 100).
SELECT Name,Price*100 FROM Products;

--6. Compute the average price of all the products.
SELECT AVG(Price) AS [Average Price] FROM Products;

--7. Compute the average price of all products with manufacturer code equal to 2.
SELECT AVG(Price) AS [Average Price Manufacturer = 2] FROM Products WHERE Manufacturer = 2;

--8. Compute the number of products with a price larger than or equal to $180.
SELECT COUNT(Price) AS [Number of Producs >= 180] FROM Products WHERE Price >= 180;

--9. Select the name and price of all products with a price larger than or equal to $180, and sort first by price (in descending order), and then by name (in ascending order).
SELECT Name, Price FROM Products WHERE Price >= 180 ORDER BY Price DESC, Name ASC

--10. Select all the data from the products, including all the data for each product's manufacturer.
SELECT * FROM Products INNER JOIN Manufacturers ON Products.Manufacturer = Manufacturers.Code

--11. Select the product name, price, and manufacturer name of all the products.
SELECT Products.Name, Products.Price, Manufacturers.Name FROM Products LEFT JOIN Manufacturers ON Products.Manufacturer = Manufacturers.Code;

--12. Select the average price of each manufacturer's products, showing only the manufacturer's code.
SELECT AVG(Products.Price) AS [Average Price], Manufacturer FROM Products GROUP BY Manufacturer;

--13. Select the average price of each manufacturer's products, showing the manufacturer's name.
SELECT AVG(Products.Price) AS [Average Price], Manufacturers.Name 
FROM Products LEFT JOIN Manufacturers 
ON Products.Manufacturer = Manufacturers.Code 
GROUP BY Manufacturers.Name;

--14. Select the names of manufacturer whose products have an average price larger than or equal to $150.
SELECT AVG(Products.Price) AS [Average Price], Manufacturers.Name 
FROM Products LEFT JOIN Manufacturers 
ON Products.Manufacturer = Manufacturers.Code 
WHERE Products.Price >= 150 
GROUP BY Manufacturers.Name;

--15. Select the name and price of the cheapest product.
SELECT Name, Price FROM Products WHERE Price = (SELECT MIN(Price) FROM Products);

--16. Select the name of each manufacturer along with the name and price of its most expensive product.
SELECT Manufacturers.Name, Products.Name 
FROM Products LEFT JOIN Manufacturers 
ON Products.Manufacturer = Manufacturers.Code 
WHERE Products.Price = (SELECT MAX(Price) FROM Products);

--17. Add a new product: Loudspeakers, $70, manufacturer 2.
INSERT INTO Products(Code, Name, Price, Manufacturer) VALUES(11, 'Loudspeakers', 70, 2);
SELECT * FROM Products;
DELETE FROM Products WHERE Code = 11;

--18. Update the name of product 8 to "Laser Printer".
UPDATE Products SET Name = 'Laser Printer' WHERE Code = 8;
SELECT * FROM Products;
UPDATE Products SET Name = 'Printer' WHERE Code = 8;

--19. Apply a 10% discount to all products.
UPDATE Products SET Price *= 0.9;
SELECT * FROM Products;
UPDATE Products SET Price /= 0.9;

--20. Apply a 10% discount to all products with a price larger than or equal to $120.
UPDATE Products SET Price *= 0.9 WHERE Price >= 120;
SELECT * FROM Products;
UPDATE Products SET Price /= 0.9 WHERE Price >= 120;
