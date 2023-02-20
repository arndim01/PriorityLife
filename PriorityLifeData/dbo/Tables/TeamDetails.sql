CREATE TABLE [dbo].[TeamDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TeamId] INT NOT NULL, 
    [TeamMemberId] INT NOT NULL, 
    [Activate] BIT NOT NULL DEFAULT 1, 
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL , 
    CONSTRAINT FK_TeamId FOREIGN KEY (TeamId) REFERENCES Team(Id), 
    CONSTRAINT FK_TeamMemberId FOREIGN KEY (TeamMemberId) REFERENCES Salesperson(Id)
)
