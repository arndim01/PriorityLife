CREATE TABLE [dbo].[Team]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TeamManager] INT NOT NULL,
    [TeamName] VARCHAR(MAX) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL , 
    CONSTRAINT FK_TeamManagerSalespersonId FOREIGN KEY (TeamManager) REFERENCES Salesperson(Id) 
    
)
