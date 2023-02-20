CREATE TABLE [dbo].[CommissionsFile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CarrierId] INT NOT NULL, 
    [ExtractedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [FileUrl] VARCHAR(MAX) NULL, 
    [Extension] VARCHAR(50) NULL, 
    [Active] BIT NOT NULL DEFAULT 1,
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL 
    CONSTRAINT FK_CarrierId FOREIGN KEY (CarrierId) REFERENCES Carriers(Id)
    
)
