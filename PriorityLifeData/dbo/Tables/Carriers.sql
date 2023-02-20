CREATE TABLE [dbo].[Carriers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(MAX) NOT NULL, 
    [ShortName] VARCHAR(MAX) NULL, 
    [URL] VARCHAR(MAX) NULL, 
    [Username] VARCHAR(MAX) NULL, 
    [Password] VARCHAR(MAX) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL 
)
