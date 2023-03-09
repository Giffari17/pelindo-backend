# How to start
```
Reqs:
1. Dotnet SDK
2. Nuget Packages
3. Dotnet Migration Tools

Init Packages:
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

Init Migration:
Tool for interact with ORM
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

Run:
dotnet run
```

## Notes
```
Change DefaultConnection to connect to DB
Go to appsettings.json, change
"DefaultConnection": "Server=192.168.56.2;User ID=giffari;Password=password;Database=pelindo"

To your own database
```