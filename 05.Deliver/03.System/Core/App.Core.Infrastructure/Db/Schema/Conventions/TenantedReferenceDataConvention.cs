namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System.Data.Entity;
    using App.Core.Shared.Models.Entities.Base;

    public class TenantedReferenceDataConvention : TenantFKEtcConvention
    {
        public new void Define<T>(DbModelBuilder modelBuilder, ref int order)
            where T: TenantedGuidIdReferenceDataBase 
        {
            // Call underlying method first:
            base.Define<T>(modelBuilder,ref order);

            // then specific:
            modelBuilder.Entity<T>()
                .Property(x => x.Enabled)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.Text)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.DisplayOrderHint)
                .HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.DisplayStyleHint)
                .HasColumnOrder(order++)
                .HasMaxLength(Constants.Db.TextFieldSizes.X64)
                .IsOptional();
        }
    }
}