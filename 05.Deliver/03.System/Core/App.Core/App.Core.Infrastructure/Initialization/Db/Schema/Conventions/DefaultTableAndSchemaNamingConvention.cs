namespace App.Core.Infrastructure.Db.Schema.Conventions
{
    using System.Data.Entity;

    public class DefaultTableAndSchemaNamingConvention
    {
        public void Define<T>(DbModelBuilder modelBuilder, string schema = Constants.Db.AppCoreDbContextNames.Core)
            where T : class
        {
            string name = typeof(T).Name;

            if (name.EndsWith("y"))
            {
                name = name.Substring(0, name.Length - 1) + "ies";
            }
            else
            {
                name += "s";
            }

            modelBuilder.Entity<T>().ToTable(name, schema);

        }
    }

}