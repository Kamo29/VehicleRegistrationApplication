-- Create the database
CREATE DATABASE VehicleManagementDB;
GO

USE VehicleManagementDB;
GO

-- Create the Vehicles table
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Outstanding DECIMAL(18, 2) NOT NULL,
    ServiceDate DATE NOT NULL,
    Milage INT NOT NULL,
    VehicleType NVARCHAR(50) NOT NULL -- 'Car' or 'Bus'
);
GO

-- Optional: Create separate tables for Cars and Busses if you want subclass details
CREATE TABLE Cars (
    CarID INT PRIMARY KEY FOREIGN KEY REFERENCES Vehicles(VehicleID),
    -- Add Car-specific properties here if needed
    Discount DECIMAL(5,2) DEFAULT 0
);
GO

CREATE TABLE Busses (
    BusID INT PRIMARY KEY FOREIGN KEY REFERENCES Vehicles(VehicleID),
    -- Add Bus-specific properties here if needed
    Discount DECIMAL(5,2) DEFAULT 0
);
GO

-- Insert sample data
INSERT INTO Vehicles (Name, Price, Outstanding, ServiceDate, Milage, VehicleType)
VALUES 
('Toyota Camry', 50000, 30000, '2023-05-05', 100000, 'Car'),
('Toyota Corolla', 60000, 35000, '2023-06-05', 110000, 'Car'),
('Mercedes Benz', 750000, 550000, '2022-02-02', 150000, 'Bus'),
('Scania', 700000, 500000, '2022-02-05', 160000, 'Bus');
GO
