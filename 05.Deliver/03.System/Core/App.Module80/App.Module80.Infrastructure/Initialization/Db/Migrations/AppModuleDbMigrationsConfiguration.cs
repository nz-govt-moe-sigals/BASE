﻿using System.Data.Entity.Migrations;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Module80.Infrastructure.Db.Context.Default;
using App.Module80.Infrastructure.Initialization.Db.Migrations.Seeding.Default;

namespace App.Module80.Infrastructure.Initialization.Db.Migrations
{
    /// <summary>
    /// <para>
    /// WARNING: 
    /// You can change the name of any other class that is associated
    /// to CodeFirst Migration, bar this one. Or its namespace. 
    /// It is recorded in the Schema's Migration table. 
    /// If changed, will block the creation of 'another' table with the same name 
    /// as already exists -- until you either change the name back, or change the 
    /// schema name.
    /// </para>
    /// <para>
    /// Referenced by AppModuleDatabaseInitializer
    /// </para>
    /// </summary>
    public sealed class AppModuleDefaultDbMigrationsConfiguration : DbMigrationsConfiguration<AppModuleDbContext>, App.Module80.Shared.Contracts.IHasModuleSpecificIdentifier
    {
        public AppModuleDefaultDbMigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            //Where to save Migrations (keep schemas distinct in their own folder):
            this.MigrationsDirectory = @"Initialization\Db\Migrations\" + "Default" /*Constants.Module.Names.ModuleKey*/;
        }

        protected override void Seed(AppModuleDbContext context)
        {
            // Hand off to a specialized class for Seeding.
            var hostSettingsService = AppDependencyLocator.Current.GetInstance<IHostSettingsService>();
            new AppModuleDbContextSeedingOrchestrator(hostSettingsService).Initialize(context);
        }
    }
}
