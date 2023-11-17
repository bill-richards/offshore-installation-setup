USE [Offshore-Configuration]
GO

---
--- Default data
---
--/*
select top(20) * from biz.Countries
select top(20) * from biz.TelephoneTypes
select top(20) * from biz.CountryCodes
select top(20) * from lang.Languages
select top(20) * from users.Permissions
select top(20) * from users.Roles
select top(20) * from biz.TelephoneNumbers
select top(20) * from users.Users
select top(20) * from config.LanguageUser
select top(20) * from users.RoleUser
select top(20) * from config.Sites
select top(20) * from config.Modules
---
--- These guys are only pertinent if we setup Offshore Operations data
--- by default, which I'm not sure about at the moment but also think
--- that we probably should
---
select top(10) * from biz.Locations
select top(10) * from biz.Companies
select top(10) * from biz.Addresses
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





