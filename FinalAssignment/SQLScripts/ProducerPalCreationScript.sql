/*
 * Title: ProducerPal
 * Name: Brady Inglis (100926284)
 * Date: 2024-12-11
 * Purpose: Creation script for the producer pal application.
 * 
 * AI Used:      Yes
 * AI Prompt:    "Generate the creation script in sql server. Call the database "ProducerPal":
 *					1. Create Project model in the database. A project will contain a ProjectID int, UserID int, and
 *					ProjectData string (base64).
 *					2. Create User model in the database. A user will contain a UserID int, UserName string, email string."
 * 
 * Changes Made: Removed identity keywords from primary keys.
*/

-- Create the ProducerPal database
CREATE DATABASE ProducerPal;
GO

-- Switch to the ProducerPal database
USE ProducerPal;
GO

-- Create the User table
CREATE TABLE [User] (
    UserID INT PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE
);

-- Create the Project table
CREATE TABLE Project (
    ProjectID INT PRIMARY KEY,
    UserID INT NOT NULL,
    ProjectData NVARCHAR(MAX) NOT NULL, -- Base64-encoded string
    FOREIGN KEY (UserID) REFERENCES [User](UserID) ON DELETE CASCADE
);
