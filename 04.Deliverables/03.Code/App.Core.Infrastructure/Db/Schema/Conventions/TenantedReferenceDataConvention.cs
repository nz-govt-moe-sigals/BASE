namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System.Data.Entity;
    using App.Core.Shared.Models.Entities.Base;

    public class TenantedReferenceDataConvention : TenantFKEtcConvention
    {
        public void Define<T>(DbModelBuilder modelBuilder, ref int order)
            where T: TenantedGuidIdReferenceDataBase 
        {
            base.Define<T>(modelBuilder,ref order);

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