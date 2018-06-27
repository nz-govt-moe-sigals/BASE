using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module80.Infrastructure.Db.Context.Default;
using App.Module80.Shared.Models.Entities;

namespace App.Module80.Infrastructure.Initialization.Db.Migrations.Seeding.Implementations
{
    public class MigrationsOrganisations
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new Organisation()
                {
                    Id = 1.ToGuid(),
                    Name = "The Rising Legion",
                    ContactNumber = "+64 06 34352 2352"
                },
                new Organisation
                {
                    Id = 2.ToGuid(),
                    Name = "The Keep it Real Brigade",
                    ContactNumber = "+64 06 34352 2351"
                },
            };

            var dbSet = context.Set<Organisation>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
