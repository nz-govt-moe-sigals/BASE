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
    public class MigrationLargeItems
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new LargeItem
                {
                    Id = 1.ToGuid(),
                    Code = 1.ToString(),
                    Category = "WhiteWare",
                    Description = "Dish Washer"
                },
                new LargeItem
                {
                    Id = 2.ToGuid(),
                    Code = 2.ToString(),
                    Category = "WhiteWare",
                    Description = "Washing Machine"
                },
                new LargeItem
                {
                    Id = 3.ToGuid(),
                    Code = 3.ToString(),
                    Category = "Electronics",
                    Description = "TV"
                },
                new LargeItem
                {
                    Id = 4.ToGuid(),
                    Code = 4.ToString(),
                    Category = "Misc",
                    Description = "Other"
                }
            };

            var dbSet = context.Set<LargeItem>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
