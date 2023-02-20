CREATE TABLE [dbo].[CommissionsExtracted]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Carrier] VARCHAR(MAX) NOT NULL, 
    [FirstName] VARCHAR(MAX) NOT NULL, 
    [LastName] VARCHAR(MAX) NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [UCode] VARCHAR(MAX) NOT NULL, 
    [DownloadType] VARCHAR(MAX) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1,
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL, 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL
)
