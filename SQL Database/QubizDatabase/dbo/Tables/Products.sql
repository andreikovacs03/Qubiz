CREATE TABLE Products (
        Code INT PRIMARY KEY NOT NULL,
        Name VARCHAR(100) NOT NULL ,
        Price REAL NOT NULL ,
        Manufacturer INTEGER NOT NULL 
                CONSTRAINT fk_Manufacturers_Code REFERENCES MANUFACTURERS(Code)
);

