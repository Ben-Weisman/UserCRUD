Stack:
* The application was built using MVC design-pattern.
* Framework: ASP.Net using C#
* DB: Microsoft SQL Server

Description: Web-App based on asp.net framework using C#, for performing CRUD operations on user-object data. The supported fields are:
- User ID (mandatory field)
- Date Of Birth (mandatory field)
- Name (mandatory field)
- Gender
- Phone number
- Email address


Actions:
Migrate DB before running:
* Tools -> NuGet Package Manager -> Package Manager Console ->
 Run commands:
* Add-Migration "someComment"
* Update-Database

This will create the DB in Microsoft SQL server Management studio with all the configuration requirements. 



Requirements:
Frameworks:
- Microsoft.AspNetCore.App
- Microsoft.NETCore.App

Packages:
- Microsoft.EntityFrameworkCore.SqlServer (7.0.8) (or above)
- Microsoft.EntityFrameworkCore.Tools (7.0.8) (or above)

wwwroot validation libraries:
- Jquery
- Jquery-validation
- Jquery-validation-unobtrusive
