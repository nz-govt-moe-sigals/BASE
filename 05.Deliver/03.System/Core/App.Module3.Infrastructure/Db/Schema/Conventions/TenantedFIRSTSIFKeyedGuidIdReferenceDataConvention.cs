namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models.Entities.Base;
    using App.Module3.Shared.Models.Entities;

    public class TenantedFIRSTSIFKeyedGuidIdReferenceDataConvention : TenantedReferenceDataConvention
    {


        public new void Define<T>(DbModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : TenantedSourceKeySIFKeyedGuidIdReferenceDataBase
        {

            string typeName = typeof(T).Name;

            // Call underlying method first:
            base.Define<T>(modelBuilder, ref order, o =>
            {
                if (o != 11)
                {
                    return o;
                }
                // Now inject into the position you want added.
                // It will push over the existing ones... I think...
                modelBuilder.Entity<T>()
                    .Property(x => x.SIFKey)
                    .HasColumnOrder(o++)
                    .HasColumnAnnotation("Index",
                        new IndexAnnotation(new IndexAttribute($"IX_{typeName}_SIFKey")
                        {
                            IsUnique = true
                        }))
                    .IsRequired();

                if (injectedPropertyDefs != null)
                {
                    o = injectedPropertyDefs.Invoke(o);
                }

                modelBuilder.Entity<T>()
                    .Property(x => x.SourceSystemKey)
                    .HasColumnOrder(o++)
                    .HasMaxLength(TextFieldSizes.X10)
                    .HasColumnAnnotation("Index",
                        new IndexAnnotation(new IndexAttribute($"IX_{typeName}_FIRSTKey")
                        {
                            IsUnique = true
                        }))
                    .IsRequired();

                if (injectedPropertyDefs != null)
                {
                    o = injectedPropertyDefs.Invoke(o);
                }

                return o;
            });


        }

    }
}