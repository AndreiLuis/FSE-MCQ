DECLARE @i INT;
SET @i = 1;

WHILE (@i <= 20)
BEGIN
    INSERT INTO Policy (Id, Name, StartDate, Duration, Company, InitialDeposit, Type, UserType, TermsPerYear, TermAmount, Interest)
    VALUES (
        CAST(@i AS NVARCHAR(10)), -- Id
        'Nome' + CAST(@i AS NVARCHAR(50)), -- Name
        DATEADD(DAY, (@i * 10) % 365, '2023-01-01'), -- StartDate
        (@i % 10) + 1, -- Duration
        'Empresa' + CAST((@i % 10) + 1 AS NVARCHAR(50)), -- Company
        CAST((@i * 1000) AS NVARCHAR(50)), -- InitialDeposit
        @i % 2, -- Type
        @i % 3, -- UserType
        (@i % 4) + 1, -- TermsPerYear
        CAST((@i * 100) AS DECIMAL(18, 2)), -- TermAmount
        CAST((@i % 2) AS BIT) -- Interest
    );

    SET @i = @i + 1;
END;