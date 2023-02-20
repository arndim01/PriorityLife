﻿/*
Deployment script for PriorityLifeDataLocal

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "PriorityLifeDataLocal"
:setvar DefaultFilePrefix "PriorityLifeDataLocal"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[__EFMigrationsHistory]...';


GO
CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetRoleClaims]...';


GO
CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetRoleClaims].[IX_AspNetRoleClaims_RoleId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([RoleId] ASC);


GO
PRINT N'Creating [dbo].[AspNetRoles]...';


GO
CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetRoles].[RoleNameIndex]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);


GO
PRINT N'Creating [dbo].[AspNetUserClaims]...';


GO
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetUserClaims].[IX_AspNetUserClaims_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([UserId] ASC);


GO
PRINT N'Creating [dbo].[AspNetUserLogins]...';


GO
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (128) NOT NULL,
    [ProviderKey]         NVARCHAR (128) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetUserLogins].[IX_AspNetUserLogins_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([UserId] ASC);


GO
PRINT N'Creating [dbo].[AspNetUserRoles]...';


GO
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetUserRoles].[IX_AspNetUserRoles_RoleId]...';


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([RoleId] ASC);


GO
PRINT N'Creating [dbo].[AspNetUsers]...';


GO
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [FirstName]            NVARCHAR (MAX)     NULL,
    [LastName]             NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[AspNetUsers].[UserNameIndex]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);


GO
PRINT N'Creating [dbo].[AspNetUsers].[EmailIndex]...';


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
PRINT N'Creating [dbo].[AspNetUserTokens]...';


GO
CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId]        NVARCHAR (450) NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [Value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [Name] ASC)
);


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
PRINT N'Creating [dbo].[CommissionsFile]...';


GO
CREATE TABLE [dbo].[CommissionsFile] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [CarrierId]     INT           NOT NULL,
    [ExtractedDate] DATETIME2 (7) NOT NULL,
    [FileUrl]       VARCHAR (MAX) NOT NULL,
    [LogsUrl]       VARCHAR (MAX) NOT NULL,
    [Active]        BIT           NOT NULL,
    [AddedBy]       VARCHAR (MAX) NOT NULL,
    [AddedDate]     DATETIME2 (7) NOT NULL,
    [UpdatedBy]     VARCHAR (MAX) NULL,
    [UpdatedDate]   DATETIME2 (7) NULL,
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
PRINT N'Creating [dbo].[Team]...';


GO
CREATE TABLE [dbo].[Team] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [TeamManager] INT           NOT NULL,
    [TeamName]    VARCHAR (MAX) NOT NULL,
    [Active]      BIT           NOT NULL,
    [AddedBy]     VARCHAR (MAX) NOT NULL,
    [AddedDate]   DATETIME2 (7) NOT NULL,
    [UpdatedBy]   VARCHAR (MAX) NULL,
    [UpdatedDate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TeamDetails]...';


GO
CREATE TABLE [dbo].[TeamDetails] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [TeamId]       INT           NOT NULL,
    [TeamMemberId] INT           NOT NULL,
    [Activate]     BIT           NOT NULL,
    [AddedBy]      VARCHAR (MAX) NOT NULL,
    [AddedDate]    DATETIME2 (7) NOT NULL,
    [UpdatedBy]    VARCHAR (MAX) NULL,
    [UpdatedDate]  DATETIME2 (7) NULL,
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
PRINT N'Creating unnamed constraint on [dbo].[CommissionsFile]...';


GO
ALTER TABLE [dbo].[CommissionsFile]
    ADD DEFAULT (getutcdate()) FOR [ExtractedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[CommissionsFile]...';


GO
ALTER TABLE [dbo].[CommissionsFile]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [dbo].[CommissionsFile]...';


GO
ALTER TABLE [dbo].[CommissionsFile]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[CommissionsFile]...';


GO
ALTER TABLE [dbo].[CommissionsFile]
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
PRINT N'Creating unnamed constraint on [dbo].[Team]...';


GO
ALTER TABLE [dbo].[Team]
    ADD DEFAULT 1 FOR [Active];


GO
PRINT N'Creating unnamed constraint on [dbo].[Team]...';


GO
ALTER TABLE [dbo].[Team]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[Team]...';


GO
ALTER TABLE [dbo].[Team]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[TeamDetails]...';


GO
ALTER TABLE [dbo].[TeamDetails]
    ADD DEFAULT 1 FOR [Activate];


GO
PRINT N'Creating unnamed constraint on [dbo].[TeamDetails]...';


GO
ALTER TABLE [dbo].[TeamDetails]
    ADD DEFAULT (getutcdate()) FOR [AddedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[TeamDetails]...';


GO
ALTER TABLE [dbo].[TeamDetails]
    ADD DEFAULT (getutcdate()) FOR [UpdatedDate];


GO
PRINT N'Creating [dbo].[FK_AspNetRoleClaims_AspNetRoles_RoleId]...';


GO
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserClaims_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserLogins_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserRoles_AspNetRoles_RoleId]...';


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserRoles_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_AspNetUserTokens_AspNetUsers_UserId]...';


GO
ALTER TABLE [dbo].[AspNetUserTokens]
    ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE;


GO
PRINT N'Creating [dbo].[FK_CarrierId]...';


GO
ALTER TABLE [dbo].[CommissionsFile]
    ADD CONSTRAINT [FK_CarrierId] FOREIGN KEY ([CarrierId]) REFERENCES [dbo].[Carriers] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonId]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonId] FOREIGN KEY ([SalesPersonId]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline1Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline1Id] FOREIGN KEY ([Upline1Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline2Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline2Id] FOREIGN KEY ([Upline2Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline3Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline3Id] FOREIGN KEY ([Upline3Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline4Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline4Id] FOREIGN KEY ([Upline4Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline5Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline5Id] FOREIGN KEY ([Upline5Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline6Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline6Id] FOREIGN KEY ([Upline6Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline7Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline7Id] FOREIGN KEY ([Upline7Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline8Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline8Id] FOREIGN KEY ([Upline8Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline9Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline9Id] FOREIGN KEY ([Upline9Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_SalespersonUpline10Id]...';


GO
ALTER TABLE [dbo].[Hierarchy]
    ADD CONSTRAINT [FK_SalespersonUpline10Id] FOREIGN KEY ([Upline10Id]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_TeamManagerSalespersonId]...';


GO
ALTER TABLE [dbo].[Team]
    ADD CONSTRAINT [FK_TeamManagerSalespersonId] FOREIGN KEY ([TeamManager]) REFERENCES [dbo].[Salesperson] ([Id]);


GO
PRINT N'Creating [dbo].[FK_TeamId]...';


GO
ALTER TABLE [dbo].[TeamDetails]
    ADD CONSTRAINT [FK_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id]);


GO
PRINT N'Creating [dbo].[FK_TeamMemberId]...';


GO
ALTER TABLE [dbo].[TeamDetails]
    ADD CONSTRAINT [FK_TeamMemberId] FOREIGN KEY ([TeamMemberId]) REFERENCES [dbo].[Salesperson] ([Id]);


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
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
