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
    public class MigrationLitterItems
    {

        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new LitterItem
                {
                    Id = 1.ToGuid(),
                    Code = 1.ToString(),
                    Category = "FakeCategory",
                    Description = "Fake Litter Item "
                },
                new LitterItem
                {
                    Id = 2.ToGuid(),
                    Code = 2.ToString(),
                    Category = "PEP",
                    Description = "2L bottle"
                },
                new LitterItem
                {
                    Id = 3.ToGuid(),
                    Code = 3.ToString(),
                    Category = "PEP",
                    Description = "1L Bottle"
                },
                new LitterItem
                {
                    Id = 4.ToGuid(),
                    Code = 4.ToString(),
                    Category = "Aluminum",
                    Description = "Soft Drink Can"
                }
            };

            var dbSet = context.Set<LitterItem>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
