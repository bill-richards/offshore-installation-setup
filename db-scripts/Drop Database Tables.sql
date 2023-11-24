USE [Offshore-Configuration]
GO

DECLARE @sql nvarchar(MAX) 

IterationStart:
SET @sql = '' 

SELECT TOP 5 @sql = @sql + 'ALTER TABLE ' + QUOTENAME(RC.CONSTRAINT_SCHEMA) 
    + '.' + QUOTENAME(KCU1.TABLE_NAME) 
    + ' DROP CONSTRAINT ' + QUOTENAME(rc.CONSTRAINT_NAME) + '; ' 
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC 

INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU1 
    ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  
    AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
    AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME 

IF @SQL <> ''
BEGIN
  EXEC(@SQL)
  GOTO IterationStart
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE dbo.__EFMigrationsHistory
GO

-- lang schema

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lang].[Languages]') AND type in (N'U'))
DROP TABLE lang.Languages
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lang].[Translatables]') AND type in (N'U'))
DROP TABLE lang.Translatables
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[lang].[Translations]') AND type in (N'U'))
DROP TABLE lang.Translations
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[LanguageUser]') AND type in (N'U'))
DROP TABLE config.LanguageUser
GO

-- users schema

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[users].[Permissions]') AND type in (N'U'))
DROP TABLE users.Permissions
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[users].[Roles]') AND type in (N'U'))
DROP TABLE users.Roles
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[users].[RoleUser]') AND type in (N'U'))
DROP TABLE users.RoleUser
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[users].[Users]') AND type in (N'U'))
DROP TABLE users.Users
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[SiteUser]') AND type in (N'U'))
DROP TABLE config.SiteUser
GO


-- biz schema

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[Addresses]') AND type in (N'U'))
DROP TABLE [biz].Addresses
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[Countries]') AND type in (N'U'))
DROP TABLE [biz].Countries
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[Locations]') AND type in (N'U'))
DROP TABLE [biz].Locations
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[Companies]') AND type in (N'U'))
DROP TABLE [biz].Companies
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[ContactLocation]') AND type in (N'U'))
DROP TABLE [biz].ContactLocation
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[Contacts]') AND type in (N'U'))
DROP TABLE [biz].Contacts
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[CountryCodes]') AND type in (N'U'))
DROP TABLE [biz].CountryCodes
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[TelephoneNumbers]') AND type in (N'U'))
DROP TABLE [biz].TelephoneNumbers
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[TelephoneTypes]') AND type in (N'U'))
DROP TABLE [biz].TelephoneTypes
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[biz].[ContactTelephoneNumber]') AND type in (N'U'))
DROP TABLE [biz].ContactTelephoneNumber
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[TelephoneNumberUser]') AND type in (N'U'))
DROP TABLE config.TelephoneNumberUser
GO

-- config schema

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Alarms]') AND type in (N'U'))
DROP TABLE config.Alarms
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Calibrations]') AND type in (N'U'))
DROP TABLE config.Calibrations
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[ChangeLogs]') AND type in (N'U'))
DROP TABLE config.ChangeLogs
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Consignments]') AND type in (N'U'))
DROP TABLE config.Consignments
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[LiveData]') AND type in (N'U'))
DROP TABLE config.LiveData
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[MeasurementTypes]') AND type in (N'U'))
DROP TABLE config.MeasurementTypes
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[MeasurementUnits]') AND type in (N'U'))
DROP TABLE config.MeasurementUnits
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Modules]') AND type in (N'U'))
DROP TABLE config.Modules
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[ModuleSensor]') AND type in (N'U'))
DROP TABLE config.ModuleSensor
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[ReceivedData]') AND type in (N'U'))
DROP TABLE config.ReceivedData
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Receivers]') AND type in (N'U'))
DROP TABLE config.Receivers
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Sensors]') AND type in (N'U'))
DROP TABLE config.Sensors
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[SinglePointMoorings]') AND type in (N'U'))
DROP TABLE config.SinglePointMoorings
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[SiteConfigurations]') AND type in (N'U'))
DROP TABLE config.SiteConfigurations
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[SiteMeasurementUnits]') AND type in (N'U'))
DROP TABLE config.SiteMeasurementUnits
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[Sites]') AND type in (N'U'))
DROP TABLE config.Sites
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[ModuleSinglePointMooring]') AND type in (N'U'))
DROP TABLE config.ModuleSinglePointMooring
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[config].[TelemetryData]') AND type in (N'U'))
DROP TABLE config.TelemetryData
GO

