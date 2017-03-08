
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2017 15:46:10
-- Generated from EDMX file: C:\User\Omri\Desktop\AfekaTorrent\FreeFilesServerConsole\EF\FilesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FreeFiles];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files] DROP CONSTRAINT [FK_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_Files_Peers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files] DROP CONSTRAINT [FK_Files_Peers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Peers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Peers];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [FileID] uniqueidentifier  NOT NULL,
    [FileName] varchar(500)  NOT NULL,
    [PeerID] uniqueidentifier  NOT NULL,
    [FileSize] int  NOT NULL,
    [FileType] varchar(10)  NOT NULL,
    [PeerHostName] varchar(100)  NULL,
    [UserID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Peers'
CREATE TABLE [dbo].[Peers] (
    [PeerID] uniqueidentifier  NOT NULL,
    [PeerHostName] varchar(100)  NULL,
    [Comments] varchar(max)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserID] uniqueidentifier  NOT NULL,
    [UserName] varchar(500)  NOT NULL,
    [Password] varchar(500)  NOT NULL,
    [SharedFolder] varchar(500)  NOT NULL,
    [DownloadFolder] varchar(500)  NOT NULL,
    [IsEnabled] bit  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FileID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([FileID] ASC);
GO

-- Creating primary key on [PeerID] in table 'Peers'
ALTER TABLE [dbo].[Peers]
ADD CONSTRAINT [PK_Peers]
    PRIMARY KEY CLUSTERED ([PeerID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UserID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PeerID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_Files_Peers]
    FOREIGN KEY ([PeerID])
    REFERENCES [dbo].[Peers]
        ([PeerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Files_Peers'
CREATE INDEX [IX_FK_Files_Peers]
ON [dbo].[Files]
    ([PeerID]);
GO

-- Creating foreign key on [UserID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_fk]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_fk'
CREATE INDEX [IX_FK_fk]
ON [dbo].[Files]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------