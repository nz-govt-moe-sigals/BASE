﻿using System.Data.Entity;
using App.Core.Infrastructure.Contracts;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module80.Shared.Contracts;

namespace App.Module80.Infrastructure.Initialization.Db.Schema
{
    public class AppModuleDbModelBuilderOrchestrator : IHasModuleSpecificIdentifier
    {

        public AppModuleDbModelBuilderOrchestrator()
        {
        }


        public void Initialize(DbModelBuilder modelBuilder)
        {
            DefineByReflection(modelBuilder);
        }

        private void DefineByReflection(DbModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.

            AppDependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>()
                .ForEach(x => { if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))) { x.Define(modelBuilder); } });
        }


    }
}

