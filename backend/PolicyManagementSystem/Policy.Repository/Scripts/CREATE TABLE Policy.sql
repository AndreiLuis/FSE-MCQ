CREATE TABLE Policy
(
    Id NVARCHAR(10),
    Name NVARCHAR(50),
    StartDate DATETIME,
    Duration INT,
    Company NVARCHAR(50),
    InitialDeposit NVARCHAR(50),
    Type INT, 
    UserType INT, 
    TermsPerYear INT,
    TermAmount DECIMAL(18, 2),
    Interest BIT
)