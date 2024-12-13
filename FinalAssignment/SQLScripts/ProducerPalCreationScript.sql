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
 *					2. Create User model in the database. A user will contain a UserID int, UserName string, password string, email string."
                    3. Create an insert stored procedure for User and Project.
 * 
 * Changes Made: Removed identity keywords from primary keys, changed from User to [User]. Switched from using base64 to storing json strings for project
				 data, where each element has a millisecond where a note should be played, and a note. So a ProjectData string would look like:
				 {
					Header:
							{
								ProjectName: projectName,
								ProjectLength: projectLength
							}
					Timeline:
							{
								{
									NoteName: noteName
									NoteLocation: locationInMillisecond
								},
								{
									NoteName: noteName2
									NoteLocation: locationInMillisecond2
								}
							}
				 
				 }

				 
*/

-- Create the database
USE Master;
	DROP DATABASE IF EXISTS ProducerPal;
	CREATE DATABASE ProducerPal;
	GO

-- Switch to the ProducerPal database
USE ProducerPal;

-- Drop all
DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS Project;
DROP PROCEDURE IF EXISTS spInsertUser

-- Create the User table
CREATE TABLE [User] (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
	Password NVARCHAR(100) NOT NULL
);

-- Create the Project table
CREATE TABLE Project (
    ProjectID INT PRIMARY KEY,
    UserID INT NOT NULL,
    ProjectData NVARCHAR(MAX) NOT NULL, -- Base64-encoded string
    FOREIGN KEY (UserID) REFERENCES [User](UserID) ON DELETE CASCADE
);

-- Create the InsertUser sp | had to add password, as ai failed to do so
GO 
CREATE PROCEDURE spInsertUser
    @UserID INT,
    @Username NVARCHAR(100),
    @Email NVARCHAR(255),
	@Password NVARCHAR(100) 
AS
BEGIN
    SET NOCOUNT ON;
    -- Insert user data into the Users table | Had to change User to [User].
    INSERT INTO [User] (UserID, Username, Email, Password)
    VALUES (@UserID, @Username, @Email, @Password);

END;
GO

