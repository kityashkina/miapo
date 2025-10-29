CREATE TABLE Users (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Login nvarchar(50),
    Password nvarchar(50)
);

INSERT INTO Users (Login, Password) VALUES (N'ИванЗоло', N'12345');

CREATE TABLE Drivers (
    Id int IDENTITY(1,1) PRIMARY KEY,
    LastName nvarchar(100),
    FirstName nvarchar(100),
    MiddleName nvarchar(100),
    Passport nvarchar(50),
    Phone nvarchar(20),
    Email nvarchar(100),
    City nvarchar(100),
    Address nvarchar(200)
);

CREATE TABLE Fines (
    Id int IDENTITY(1,1) PRIMARY KEY,
    DriverId int FOREIGN KEY REFERENCES Drivers(Id),
    FineDate date,
    FineType nvarchar(100),
    FineAmount decimal(10,2),
    FineStatus nvarchar(50)
);

CREATE TABLE Exports (
    Id int IDENTITY(1,1) PRIMARY KEY,
    DriverId int FOREIGN KEY REFERENCES Drivers(Id),
    ExportDate date,
    ExportStatus nvarchar(50)
);