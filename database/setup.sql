-- Reconstructed setup for local demonstration, not an original database backup.
-- Registration columns follow the supplied XSD; Logins is inferred from Login.cs.
IF DB_ID(N'SkillsInternational') IS NULL
    EXEC(N'CREATE DATABASE SkillsInternational');
GO
USE SkillsInternational;
GO
IF OBJECT_ID(N'dbo.Registration', N'U') IS NULL
BEGIN
CREATE TABLE dbo.Registration (
    [regNo] INT NOT NULL PRIMARY KEY,
    [firstName] NVARCHAR(50) NULL,
    [lastName] NVARCHAR(50) NULL,
    [dateOfBirth] DATETIME NULL,
    [gender] NVARCHAR(50) NULL,
    [address] NVARCHAR(50) NULL,
    [email] NVARCHAR(50) NULL,
    [mobilePhone] INT NULL,
    [homePhone] INT NULL,
    [parentName] NVARCHAR(50) NULL,
    [nic] NVARCHAR(50) NULL,
    [contactNo] INT NULL
);
END;
GO
IF OBJECT_ID(N'dbo.Logins', N'U') IS NULL
BEGIN
CREATE TABLE dbo.Logins (
    username NVARCHAR(100) NOT NULL PRIMARY KEY,
    password NVARCHAR(255) NOT NULL
);
END;
GO
-- No accounts or student records are seeded.
-- For an isolated local demo, insert your own throwaway username/password.
-- The original application compares plaintext passwords; never reuse a real password.
