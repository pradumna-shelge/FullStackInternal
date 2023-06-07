create database donationSystem;

use donationSystem;


-- Table: Roles
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY,
    RoleName Nvarchar(50) 
);

-- Insert sample data into Roles table
INSERT INTO Roles (RoleId, RoleName)
VALUES (1, 'Admin'), (2, 'Devotee');



CREATE TABLE UserData (
    userId Nvarchar(100) primary key,
	userPassword Nvarchar(100),
    FirstName Nvarchar(50) ,
    MiddleName Nvarchar(50),
    LastName Nvarchar(50) ,
    PhotoURL Nvarchar(MAX),
    FlatNumber Nvarchar(50),
    AddressLine Nvarchar(100),
    StateId INT,
    CityId INT,
    PinCode Nvarchar(6),
    Email Nvarchar(100) ,
    InitiationDate DATE ,
	RoleID int REFERENCES Roles(RoleId),
    FOREIGN KEY (StateId) REFERENCES Cities(CityId),
    FOREIGN KEY (CityId) REFERENCES Cities(CityId)
);
--drop table UserData

CREATE TABLE Cities (
    CityId INT PRIMARY KEY,
    CityName VARCHAR(50) ,
    StateId INT FOREIGN KEY REFERENCES Cities(CityId)
);


