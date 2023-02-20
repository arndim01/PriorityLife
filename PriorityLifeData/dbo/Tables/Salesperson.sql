CREATE TABLE [dbo].[Salesperson]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] VARCHAR(MAX) NOT NULL, 
    [MiddleName] VARCHAR(MAX) NULL, 
    [LastName] VARCHAR(MAX) NOT NULL, 
    [Initials] VARCHAR(MAX) NOT NULL,
    [Email] VARCHAR(MAX) NULL, 
    [Phone] VARCHAR(MAX) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [AddedBy] VARCHAR(MAX) NOT NULL,
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()) , 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL   
)
