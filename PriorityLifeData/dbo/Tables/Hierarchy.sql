﻿CREATE TABLE [dbo].[Hierarchy]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [SalesPersonId] INT NOT NULL UNIQUE, 
    [Upline1Id] INT NULL, 
    [Upline2Id] INT NULL, 
    [Upline3Id] INT NULL, 
    [Upline4Id] INT NULL, 
    [Upline5Id] INT NULL, 
    [Upline6Id] INT NULL, 
    [Upline7Id] INT NULL, 
    [Upline8Id] INT NULL, 
    [Upline9Id] INT NULL, 
    [Upline10Id] INT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL , 
    CONSTRAINT FK_SalespersonId FOREIGN KEY (SalesPersonId) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline1Id FOREIGN KEY (Upline1Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline2Id FOREIGN KEY (Upline2Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline3Id FOREIGN KEY (Upline3Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline4Id FOREIGN KEY (Upline4Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline5Id FOREIGN KEY (Upline5Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline6Id FOREIGN KEY (Upline6Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline7Id FOREIGN KEY (Upline7Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline8Id FOREIGN KEY (Upline8Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline9Id FOREIGN KEY (Upline9Id) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_SalespersonUpline10Id FOREIGN KEY (Upline10Id) REFERENCES Salesperson(Id) 
)