using App.Core.Infrastructure.Constants.Db;
using App.Module11.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class ModelBuilderExtensions
    {
        public static void DefineSIFFields<T>(this DbModelBuilder modelBuilder, ref int order)
            where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        {

            string typeName = typeof(T).Name;

            // Now inject into the position you want added.
            // It will push over the existing ones... I think...
            modelBuilder.Entity<T>()
                .Property(x => x.SIFKey)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X10)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeName}_SIFKey")
                    {
                        IsUnique = true
                    }))
                .IsRequired();

        }



        public static void DefineSourceSystemFields<T>(this DbModelBuilder modelBuilder, ref int order)
            where T : SourceSystemKeyedTenantedGuidIdReferenceDataBase
        {

            string typeName = typeof(T).Name;


            modelBuilder.Entity<T>()
        .Property(x => x.SourceSystemKey)
        .HasColumnOrder(order++)
        .HasMaxLength(TextFieldSizes.X10)
        .HasColumnAnnotation("Index",
            new IndexAnnotation(new IndexAttribute($"IX_{typeName}_FIRSTKey")
            {
                IsUnique = true
            }))
        .IsRequired();


            modelBuilder.Entity<T>()
                .Property(x => x.SourceSystemName)
                .HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X256)
                .IsOptional();

        }
    }
}

