﻿/*
Deployment script for PriorityLife

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "PriorityLife"
:setvar DefaultFilePrefix "PriorityLife"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
PRINT N'Rename refactoring operation with key 106f30ff-c4e2-4640-92a4-d0e68c633492 is skipped, element [dbo].[Carriers].[Short] (SqlSimpleColumn) will not be renamed to ShortName';


GO
PRINT N'Creating [dbo].[Carriers]...';


GO
CREATE TABLE [dbo].[Carriers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (MAX) NOT NULL,
    [ShortName]   VARCHAR (MAX) NULL,
    [URL]         VARCHAR (MAX) NULL,
    [Username]    VARCHAR (MAX) NULL,
    [Password]    VARCHAR (MAX) NULL,
    [Active]      BIT           NOT NULL,
    [AddedBy]     VARCHAR (MAX) NOT NULL,
    [AddedDate]   DATETIME2 (7) NOT NULL,
    [UpdatedBy]   VARCHAR (MAX) NULL,
    [UpdatedDate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Commissions]...';


GO
CREATE TABLE [dbo].[Commissions] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [SalespersonId]  INT           NOT NULL,
    [CarrierId]      INT           NOT NULL,
    [CommissionDate] DATETIME2 (7) NOT NULL,
    [Amount]         MONEY         NOT NULL,
    [AddedBy]        VARCHAR (MAX) NOT NULL,
    [AddedDate]      DATETIME2 (7) NOT NULL,
    [UpdatedBy]      VARCHAR (MAX) NULL,
    [UpdatedDate]    DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Hierarchy]...';


GO
CREATE TABLE [dbo].[Hierarchy] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [SalesPersonId] INT           NOT NULL,
    [Upline1Id]     INT           NULL,
    [Upline2Id]     INT           NULL,
    [Upline3Id]     INT           NULL,
    [Upline4Id]     INT           NULL,
    [Upline5Id]     INT           NULL,
    [Upline6Id]     INT           NULL,
    [Upline7Id]     INT           NULL,
    [Upline8Id]     INT           NULL,
    [Upline9Id]     INT           NULL,
    [Upline10Id]    INT           NULL,
    [Active]        BIT           NOT NULL,
    [AddedBy]       VARCHAR (MAX) NOT NULL,
    [AddedDate]     DATETIME2 (7) NOT NULL,
    [UpdatedBy]     VARCHAR (MAX) NULL,
    [UpdatedDate]   DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Salesperson]...';


GO
CREATE TABLE [dbo].[Salesperson] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (MAX) NOT NULL,
    [MiddleName]  VARCHAR (MAX) NOT NULL,
    [LastName]    VARCHAR (MAX) NOT NULL,
    [Initials]    VARCHAR (MAX) NOT NULL,
    [Email]       VARCHAR (MAX) NOT NULL,
    [Phone]       VARCHAR (MAX) NOT NULL,
    [Active]      BIT           NOT NULL,
    [AddedBy]     VARCHAR (MAX) NOT NULL,
    [AddedDate]   DATETIME2 (7) NOT NULL,
    [UpdatedBy]   VARCHAR (MAX) NULL,
    [UpdatedDate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Carriers]...';


GO
ALTER TABLE [dbo].[Carriers]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [dbo].[Carriers]...';


GO
ALTER TABLE [dbo].[Carriers]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Carriers]...';


GO
ALTER TABLE [dbo].[Carriers]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Commissions]...';


GO
ALTER TABLE [dbo].[Commissions]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Commissions]...';


GO
ALTER TABLE [dbo].[Commissions]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Hierarchy]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [dbo].[Hierarchy]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Hierarchy]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Salesperson]...';


GO
ALTER TABLE [dbo].[Salesperson]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [dbo].[Salesperson]...';


GO
ALTER TABLE [dbo].[Salesperson]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Salesperson]...';


GO
ALTER TABLE [dbo].[Salesperson]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating [dbo].[FK_SalespersonId]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonId] FOREIGN KEY ([SalesPersonId]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline1Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline1Id] FOREIGN KEY ([Upline1Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline2Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline2Id] FOREIGN KEY ([Upline2Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline3Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline3Id] FOREIGN KEY ([Upline3Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline4Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline4Id] FOREIGN KEY ([Upline4Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline5Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline5Id] FOREIGN KEY ([Upline5Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline6Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline6Id] FOREIGN KEY ([Upline6Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline7Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline7Id] FOREIGN KEY ([Upline7Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline8Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline8Id] FOREIGN KEY ([Upline8Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline9Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline9Id] FOREIGN KEY ([Upline9Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline10Id]...';


GO
ALTER TABLE [dbo].[Hierarchy] WITH NOCHECK
    ADD CONSTRAINT [FK_SalespersonUpline10Id] FOREIGN KEY ([Upline10Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '106f30ff-c4e2-4640-92a4-d0e68c633492')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('106f30ff-c4e2-4640-92a4-d0e68c633492')

GO

GO
