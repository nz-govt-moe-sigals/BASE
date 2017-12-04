namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration.Conventions;

    // Note by default
    // OneToManyCascadeDeleteConvention
    // ManyToManyCascadeDeleteConvention
    // Are already installed.

    public class IdConvention : Convention
    {
        public IdConvention()
        {
            Properties()
                .Where(p =>
                    p.PropertyType == typeof(Guid)
                    &&
                    p.Name == "Id")
                .Configure(
                    p =>
                    {
                        p.IsKey();
                        p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                    });
        }
    }
}