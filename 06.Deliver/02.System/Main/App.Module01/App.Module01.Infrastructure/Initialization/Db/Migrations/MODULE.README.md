﻿Tip: 
Make sure you've read App.Core.Application/Db/README.txt for a general 
idea of how DbContexts, Migrations, Seeding work when combined with IoC/DI.

// For initializers, see DatabaseInitializerConfigure.cs
// But this can also be done solely via web.config as per bottom of
// https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application


// Notice below how:
// a) the referenced Infrastructure is Module specific (eg: App.Module01.Infrastructure)
// b) the Migrations directory is Module specific (eg: 'Db/Migrations/Module01')

// Run once, at the beginning of projects, to create the Db/Configuration class:
Enable-Migrations -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -ContextProjectName "App.Module01.Infrastructure" -MigrationsDirectory "Initialization\Db\Migrations\Default" -Verbose

// Run after every Db Model schema change, changing the name every time, in order to make a Migration class
add-Migration "Entities.Example" -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -Verbose                      

// Run after every Db Model schema change to apply the above migration class:
Update-Database -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -Verbose


// Generate SQL scripts for deployment:
Update-Database -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -Script -SourceMigration: $InitialDatabase -Verbose 
// Generate SQL scripts for deployment up to a target Migration:
//Update-Database -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -Script -SourceMigration: $InitialDatabase -TargetMigration: AddPostAbstract -Verbose

//Rollback 
//Update-Database -StartUpProjectName "App.Host" -ProjectName "App.Module01.Infrastructure" -Script -TargetMigration: XYZ -Verbose   

