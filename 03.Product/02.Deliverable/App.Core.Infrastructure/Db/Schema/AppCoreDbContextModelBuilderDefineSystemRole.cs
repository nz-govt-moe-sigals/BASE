﻿namespace App.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Schema.Conventions;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Shared.Models.Entities;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppCoreDbContextModelBuilderDefineSystemRole : IHasAppCoreDbContextModelBuilderInitializer
    {
        public void Define(DbModelBuilder modelBuilder)
        {
            var order = 1;

            new NonTenantFKEtcConvention().Define<SystemRole>(modelBuilder, ref order);

            modelBuilder.Entity<SystemRole>()
                .Property(x => x.Enabled)
                .IsRequired();

            modelBuilder.Entity<SystemRole>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<SystemRole>()
                .Property(x => x.Key)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("IX_SystemRole_Key") { IsUnique = false }))
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();


        }
    }
}