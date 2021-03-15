--setup data
 CREATE TABLE Movies (
   Code INT PRIMARY KEY NOT NULL,
   Title VARCHAR(100) NOT NULL,
   Rating VARCHAR(100) 
 );
  
 CREATE TABLE MovieTheaters (
   Code INT PRIMARY KEY NOT NULL,
   Name VARCHAR(100) NOT NULL,
   Movie INTEGER  
     CONSTRAINT fk_Movies_Code REFERENCES Movies(Code)
 );

 INSERT INTO Movies(Code,Title,Rating) VALUES(1,'Citizen Kane','PG');
 INSERT INTO Movies(Code,Title,Rating) VALUES(2,'Singin'' in the Rain','G');
 INSERT INTO Movies(Code,Title,Rating) VALUES(3,'The Wizard of Oz','G');
 INSERT INTO Movies(Code,Title,Rating) VALUES(4,'The Quiet Man',NULL);
 INSERT INTO Movies(Code,Title,Rating) VALUES(5,'North by Northwest',NULL);
 INSERT INTO Movies(Code,Title,Rating) VALUES(6,'The Last Tango in Paris','NC-17');
 INSERT INTO Movies(Code,Title,Rating) VALUES(7,'Some Like it Hot','PG-13');
 INSERT INTO Movies(Code,Title,Rating) VALUES(8,'A Night at the Opera',NULL);
 
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(1,'Odeon',5);
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(2,'Imperial',1);
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(3,'Majestic',NULL);
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(4,'Royale',6);
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(5,'Paraiso',3);
 INSERT INTO MovieTheaters(Code,Name,Movie) VALUES(6,'Nickelodeon',NULL);

GO

--1. Select the title of all movies.
SELECT Title FROM Movies;

--2. Show all the distinct ratings in the database.
SELECT DISTINCT Rating FROM Movies;

--3. Show all unrated movies.
SELECT * FROM Movies WHERE Rating IS NULL;

--4. Select all movie theaters that are not currently showing a movie.
SELECT Name FROM MovieTheaters WHERE Movie IS NULL;

--5. Select all data from all movie theaters and, additionally, the data from the movie that is being shown in the theater (if one is being shown).
SELECT * FROM MovieTheaters LEFT JOIN Movies ON MovieTheaters.Movie = Movies.Code WHERE MovieTheaters.Movie IS NOT NULL;

--6. Select all data from all movies and, if that movie is being shown in a theater, show the data from the theater.
 SELECT * FROM Movies LEFT JOIN MovieTheaters ON MovieTheaters.Movie = Movies.Code

--7. Show the titles of movies not currently being shown in any theaters.
SELECT * FROM Movies WHERE Movies.Code != ALL (SELECT Movie FROM MovieTheaters )  --??

--8. Add the unrated movie "One, Two, Three".
 INSERT INTO Movies(Code, Title, Rating) VALUES(9, 'One, Two, Three', NULL);

--9. Set the rating of all unrated movies to "G".
UPDATE Movies SET Rating = 'G' WHERE Rating = NULL;

--10. Remove movie theaters projecting movies rated "NC-17".
DELETE FROM Movies 

--setup data

CREATE TABLE Departments (
   Code INT PRIMARY KEY NOT NULL,
   Name VARCHAR(100) NOT NULL ,
   Budget REAL NOT NULL 
 );
 
 CREATE TABLE Employees (
   SSN INT PRIMARY KEY NOT NULL,
   Name VARCHAR(100) NOT NULL ,
   LastName VARCHAR(100) NOT NULL ,
   Department INT NOT NULL , 
   CONSTRAINT fk_Departments_Code FOREIGN KEY(Department) 
   REFERENCES Departments(Code)
 );

INSERT INTO Departments(Code,Name,Budget) VALUES(14,'IT',65000);
INSERT INTO Departments(Code,Name,Budget) VALUES(37,'Accounting',15000);
INSERT INTO Departments(Code,Name,Budget) VALUES(59,'Human Resources',240000);
INSERT INTO Departments(Code,Name,Budget) VALUES(77,'Research',55000);

INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('123234877','Michael','Rogers',14);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('152934485','Anand','Manikutty',14);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('222364883','Carol','Smith',37);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('326587417','Joe','Stevens',37);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('332154719','Mary-Anne','Foster',14);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('332569843','George','ODonnell',77);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('546523478','John','Doe',59);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('631231482','David','Smith',77);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('654873219','Zacary','Efron',59);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('745685214','Eric','Goldsmith',59);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('845657245','Elizabeth','Doe',14);
INSERT INTO Employees(SSN,Name,LastName,Department) VALUES('845657246','Kumar','Swamy',14);

GO

--1. Select the last name of all employees.
SELECT LastName FROM Employees;

--2. Select the last name of all employees, without duplicates.
SELECT DISTINCT LastName FROM Employees;

--3. Select all the data of employees whose last name is "Smith".
SELECT * FROM Employees WHERE LastName = 'Smith';

--4. Select all the data of employees whose last name is "Smith" or "Doe".
SELECT * FROM Employees WHERE LastName = 'Smith' OR LastName = 'Doe';

--5. Select all the data of employees that work in department 14.
SELECT * FROM Employees WHERE Department = 14;

--6. Select all the data of employees that work in department 37 or department 77.
SELECT * FROM Employees WHERE Department = 37 OR Department = 77;

--7. Select all the data of employees whose last name begins with an "S".
SELECT * FROM Employees WHERE LastName LIKE 'S%';

--8. Select the sum of all the departments budgets.
SELECT SUM(Budget) AS [Total Budget] FROM Departments;

--9. Select the number of employees in each department (you only need to show the department code and the number of employees).
SELECT Department, COUNT(Name) AS [Number of Employees] FROM Employees GROUP BY Department;

--10. Select all the data of employees, including each employee's department's data.
SELECT * FROM Employees LEFT JOIN Departments ON Employees.Department = Departments.Code;

--11. Select the name and last name of each employee, along with the name and budget of the employee's department.
SELECT Employees.Name, LastName, Budget FROM Employees LEFT JOIN Departments ON Employees.Department = Departments.Code;

--12. Select the name and last name of employees working for departments with a budget greater than $60,000.
SELECT Employees.Name, LastName, Budget FROM Employees LEFT JOIN Departments ON Employees.Department = Departments.Code WHERE Budget >= 60000;

--13. Select the departments with a budget larger than the average budget of all the departments.

--14. Select the names of departments with more than two employees.
SELECT * FROM Employees LEFT JOIN Departments ON Employees.Department = Departments.Code GROUP BY Department;

--15. Select the name and last name of employees working for departments with second lowest budget.

--16. Add a new department called "Quality Assurance", with a budget of $40,000 and departmental code 11. Add an employee called "Mary Moore" in that department, with SSN 847-21-9811.

--17. Reduce the budget of all departments by 10%.
UPDATE Departments SET Budget *= 1.1;

--18. Reassign all employees from the Research department (code 77) to the IT department (code 14).
UPDATE Employees SET Department = 14 WHERE Department = 77;

--19. Delete from the table all employees in the IT department (code 14).'
DELETE FROM Employees WHERE Department = 14;

--20. Delete from the table all employees who work in departments with a budget greater than or equal to $60,000.
DELETE FROM Employees 

--21. Delete from the table all employees.
--TRUNCATE TABLE Employees;