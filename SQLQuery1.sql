CREATE DATABASE Ramand
GO

USE Ramand

CREATE TABLE [User]
(
Id INT IDENTITY PRIMARY KEY ,
UserName NVARCHAR(50) NOT NULL UNIQUE ,
[Password] NVARCHAR(50) NOT NULL
)

GO
CREATE PROC sp_Add 
@UserName NVARCHAR(50) , @Password NVARCHAR(50)
AS 
BEGIN
    INSERT INTO [User] (UserName, [Password])
    VALUES (@UserName, @Password);
END;
GO;

CREATE PROC sp_GetByUserNameAndPassword
@UserName NVARCHAR(50) , @Password NVARCHAR(50)
AS 
BEGIN
SELECT * FROM [User] WHERE UserName = @UserName AND Password = @Password
END;
GO;

CREATE PROC sp_GetAll
AS 
BEGIN
SELECT * FROM [User] 
END;
GO;