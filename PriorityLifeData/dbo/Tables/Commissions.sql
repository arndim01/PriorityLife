CREATE TABLE [dbo].[Commissions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [SalespersonId] INT NOT NULL, 
    [CarrierId] INT NOT NULL, 
    [CommissionDate] DATETIME2 NOT NULL, 
    [CommissionStartDate] DATETIME2 NULL,
    [CommissionEndDate] DATETIME2 NULL,
    [Amount] MONEY NOT NULL, 
    [AddedBy] VARCHAR(MAX) NOT NULL, 
    [AddedDate] DATETIME2 NOT NULL DEFAULT (getutcdate()), 
    [UpdatedBy] VARCHAR(MAX) NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    CONSTRAINT FK_Commissions_Salesperson FOREIGN KEY (SalespersonId) REFERENCES Salesperson(Id), 
    CONSTRAINT FK_Commissions_Carriers FOREIGN KEY (CarrierId) REFERENCES Carriers(Id) 
)
