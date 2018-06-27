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
    public class MigrationsRegions
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new Region()
                {
                    Id = 1.ToGuid(),
                    Name = "Wairarapa",
                    RegionId = 1
                },
                new Region
                {
                    Id = 2.ToGuid(),
                    Name = "Northland",
                    RegionId = 2
                },
            };

            var dbSet = context.Set<Region>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
