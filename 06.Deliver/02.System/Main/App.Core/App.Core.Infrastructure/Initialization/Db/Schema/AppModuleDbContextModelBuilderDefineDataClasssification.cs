﻿namespace App.Core.Infrastructure.Db.Schema
{
    using System;
    using System.Data.Entity;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineDataClasssification : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<DataClassification>(modelBuilder);

            var order = 1;

            // Note that this Schema uses an Enum as the Id:
            new UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention()
                .Define<DataClassification, NZDataClassification>(modelBuilder, ref order);

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);
        }

    }
}