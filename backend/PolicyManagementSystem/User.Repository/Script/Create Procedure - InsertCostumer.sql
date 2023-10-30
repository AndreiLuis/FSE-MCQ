CREATE PROCEDURE InsertCostumer
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DateBirth DATETIME,
    @Address NVARCHAR(100),
    @ContactNumber NVARCHAR(20),
    @Email NVARCHAR(50),
    @Salary DECIMAL(18, 2),
    @PanNumber INT,
    @EmployerType NVARCHAR(50),
    @EmployerName NVARCHAR(50)
AS
BEGIN
    INSERT INTO Costumer (FirstName, LastName, DateBirth, Address, ContactNumber, Email, Salary, PanNumber, EmployerType, EmployerName) 
    VALUES (@FirstName, @LastName, @DateBirth, @Address, @ContactNumber, @Email, @Salary, @PanNumber, @EmployerType, @EmployerName)
END
