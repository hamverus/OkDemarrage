
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/06/2016 03:30:24
-- Generated from EDMX file: C:\Users\GsrMed\Documents\Visual Studio 2015\Projects\OKDemarrageIntegration\Repositories\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Pilote Fini_LigneDem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pilote Fini] DROP CONSTRAINT [FK_Pilote Fini_LigneDem];
GO
IF OBJECT_ID(N'[dbo].[FK_ValOKdIntegrt_LigneDem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValOKdIntegrtion] DROP CONSTRAINT [FK_ValOKdIntegrt_LigneDem];
GO
IF OBJECT_ID(N'[dbo].[FK_ValOKdIntegrt_OKDesription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValOKdIntegrtion] DROP CONSTRAINT [FK_ValOKdIntegrt_OKDesription];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LigneDem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LigneDem];
GO
IF OBJECT_ID(N'[dbo].[OKDesription]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OKDesription];
GO
IF OBJECT_ID(N'[dbo].[Pilote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pilote];
GO
IF OBJECT_ID(N'[dbo].[Pilote Fini]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pilote Fini];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[ValOKdIntegrtion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValOKdIntegrtion];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LigneDems'
CREATE TABLE [dbo].[LigneDems] (
    [id] int IDENTITY(1,1) NOT NULL,
    [description] varchar(max)  NULL
);
GO

-- Creating table 'OKDesriptions'
CREATE TABLE [dbo].[OKDesriptions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Postes] varchar(max)  NULL,
    [description] varchar(max)  NULL,
    [Module] varchar(max)  NULL
);
GO

-- Creating table 'Pilotes'
CREATE TABLE [dbo].[Pilotes] (
    [Matricule] nvarchar(50)  NOT NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL,
    [Poste] nvarchar(50)  NULL
);
GO

-- Creating table 'Pilote_Finis'
CREATE TABLE [dbo].[Pilote_Finis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Matricule] nvarchar(50)  NOT NULL,
    [Date] datetime  NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL,
    [UF] nvarchar(50)  NULL,
    [Fonction] nvarchar(50)  NULL,
    [Poste] nvarchar(50)  NULL,
    [idLigne] int  NULL
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

-- Creating table 'ValOKdIntegrtions'
CREATE TABLE [dbo].[ValOKdIntegrtions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [ok] bit  NULL,
    [nok] bit  NULL,
    [na] bit  NULL,
    [idDescription] int  NULL,
    [idLigne] int  NULL,
    [commentaire] varchar(max)  NULL
);
GO

-- Creating table 'PiloteIntegs'
CREATE TABLE [dbo].[PiloteIntegs] (
    [matricule] nvarchar(50)  NOT NULL,
    [nom] nvarchar(50)  NULL,
    [prenom] nvarchar(50)  NULL,
    [pwd] nvarchar(50)  NULL,
    [poste] nvarchar(50)  NULL
);
GO

-- Creating table 'PiloteFiniIntegs'
CREATE TABLE [dbo].[PiloteFiniIntegs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [matricule] nvarchar(50)  NOT NULL,
    [nom] nvarchar(50)  NULL,
    [Fonction] nvarchar(50)  NULL,
    [UF] nvarchar(50)  NULL,
    [Poste] nvarchar(50)  NULL,
    [Module] nvarchar(50)  NULL,
    [date] datetime  NULL,
    [idLigne] int  NULL,
    [prenom] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'LigneDems'
ALTER TABLE [dbo].[LigneDems]
ADD CONSTRAINT [PK_LigneDems]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'OKDesriptions'
ALTER TABLE [dbo].[OKDesriptions]
ADD CONSTRAINT [PK_OKDesriptions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Matricule] in table 'Pilotes'
ALTER TABLE [dbo].[Pilotes]
ADD CONSTRAINT [PK_Pilotes]
    PRIMARY KEY CLUSTERED ([Matricule] ASC);
GO

-- Creating primary key on [id] in table 'Pilote_Finis'
ALTER TABLE [dbo].[Pilote_Finis]
ADD CONSTRAINT [PK_Pilote_Finis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'ValOKdIntegrtions'
ALTER TABLE [dbo].[ValOKdIntegrtions]
ADD CONSTRAINT [PK_ValOKdIntegrtions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [matricule] in table 'PiloteIntegs'
ALTER TABLE [dbo].[PiloteIntegs]
ADD CONSTRAINT [PK_PiloteIntegs]
    PRIMARY KEY CLUSTERED ([matricule] ASC);
GO

-- Creating primary key on [id] in table 'PiloteFiniIntegs'
ALTER TABLE [dbo].[PiloteFiniIntegs]
ADD CONSTRAINT [PK_PiloteFiniIntegs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idLigne] in table 'Pilote_Finis'
ALTER TABLE [dbo].[Pilote_Finis]
ADD CONSTRAINT [FK_Pilote_Fini_LigneDem]
    FOREIGN KEY ([idLigne])
    REFERENCES [dbo].[LigneDems]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pilote_Fini_LigneDem'
CREATE INDEX [IX_FK_Pilote_Fini_LigneDem]
ON [dbo].[Pilote_Finis]
    ([idLigne]);
GO

-- Creating foreign key on [idLigne] in table 'ValOKdIntegrtions'
ALTER TABLE [dbo].[ValOKdIntegrtions]
ADD CONSTRAINT [FK_ValOKdIntegrt_LigneDem]
    FOREIGN KEY ([idLigne])
    REFERENCES [dbo].[LigneDems]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValOKdIntegrt_LigneDem'
CREATE INDEX [IX_FK_ValOKdIntegrt_LigneDem]
ON [dbo].[ValOKdIntegrtions]
    ([idLigne]);
GO

-- Creating foreign key on [idDescription] in table 'ValOKdIntegrtions'
ALTER TABLE [dbo].[ValOKdIntegrtions]
ADD CONSTRAINT [FK_ValOKdIntegrt_OKDesription]
    FOREIGN KEY ([idDescription])
    REFERENCES [dbo].[OKDesriptions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ValOKdIntegrt_OKDesription'
CREATE INDEX [IX_FK_ValOKdIntegrt_OKDesription]
ON [dbo].[ValOKdIntegrtions]
    ([idDescription]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------