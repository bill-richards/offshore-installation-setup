USE [Offshore-Configuration]
GO

---
--- Default data
---
--/*
select top(10) * from biz.Locations
select top(10) * from biz.Companies
select top(10) * from biz.Addresses

select top(50) * from biz.Countries
select top(50) * from biz.TelephoneTypes
select top(50) * from biz.CountryCodes
select top(50) * from biz.Contacts
select top(50) * from lang.Languages
select top(50) * from lang.Translatables
select top(50) * from lang.Translations
select top(50) * from users.Permissions
select top(50) * from users.Roles
select top(50) * from biz.TelephoneNumbers
select top(50) * from config.LanguageUser
select top(50) * from users.RoleUser
select top(50) * from users.Users
select top(50) * from config.Sites
select top(50) * from config.SiteUsers
select top(50) * from config.Receivers

select top(50) * from config.MeasurementTypes
select top(50) * from config.MeasurementUnits
select top(50) * from config.Modules
select top(50) * from config.Sensors
select top(50) * from config.ModuleSensor
select top(50) * from config.TelemetryData
select top(50) * from config.SinglePointMoorings
select top(50) * from config.ModuleSinglePointMooring

--*/

---
--- Demo data
---

/*
select top(5) * from biz.Countries
select top(5) * from biz.TelephoneTypes
select top(5) * from biz.Addresses
select top(5) * from biz.Locations
select top(5) * from biz.CountryCodes
select top(5) * from biz.TelephoneNumbers
select top(5) * from biz.Contacts
select top(5) * from biz.ContactLocation
select top(5) * from biz.Companies
select top(5) * from config.Sites

select top(5) * from lang.Languages
select top(5) * from users.Permissions
select top(5) * from users.Roles
select top(5) * from users.Users
select top(5) * from config.LanguageUser
select top(5) * from users.RoleUser
*/





