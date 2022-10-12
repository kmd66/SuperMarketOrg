USE [Kama.Sm.Organization]
GO

---------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sys.schemas WHERE [Name] = 'cnt')
	DROP SCHEMA cnt
GO

CREATE SCHEMA cnt
GO


---------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sys.schemas WHERE [Name] = 'org')
	DROP SCHEMA org
GO

CREATE SCHEMA org
GO

---------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sys.schemas WHERE [Name] = 'pbl')
	DROP SCHEMA pbl
GO

CREATE SCHEMA pbl
GO
---------------------------------------------------------------
IF EXISTS(SELECT 1 FROM sys.schemas WHERE [Name] = 'app')
	DROP SCHEMA app
GO

CREATE SCHEMA app
GO

