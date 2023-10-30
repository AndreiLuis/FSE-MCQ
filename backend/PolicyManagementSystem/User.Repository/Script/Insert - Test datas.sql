DECLARE @i INT = 1;
WHILE @i <= 20
BEGIN
    INSERT INTO Costumer (FirstName, LastName, DateBirth, Address, ContactNumber, Email, Salary, PanNumber, EmployerType, EmployerName)
    VALUES (
        'FirstName' + CAST(@i AS NVARCHAR),
        'LastName' + CAST(@i AS NVARCHAR),
        DATEADD(YEAR, -(@i % 50), GETDATE()), -- Date of birth
        'Address' + CAST(@i AS NVARCHAR),
        'ContactNumber' + CAST(@i AS NVARCHAR),
        'Email' + CAST(@i AS NVARCHAR) + '@example.com',
        (@i * 1000.0), -- Salary
        @i * 10000, -- PanNumber
        CASE WHEN @i % 2 = 0 THEN 'EmployerType1' ELSE 'EmployerType2' END,
        'EmployerName' + CAST(@i AS NVARCHAR)
    );
    SET @i = @i + 1;
END
