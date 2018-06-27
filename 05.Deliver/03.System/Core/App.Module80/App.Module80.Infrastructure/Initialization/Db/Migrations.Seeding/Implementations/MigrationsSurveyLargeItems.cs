using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Module80.Infrastructure.Db.Context.Default;
using App.Module80.Shared.Models.Entities;
using App.Module80.Shared.Models.Entities.Enums;

namespace App.Module80.Infrastructure.Initialization.Db.Migrations.Seeding.Implementations
{
    public class MigrationsSurveyLargeItems
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new SurveyLargeItem()
                {
                    Id = 1.ToGuid(),
                    LargeItemFK = 2.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 2,
                    Status = LargeItemStatus.Destroyed,
                    Latitude = 0m,
                    Longitude = 0m,
                },
                new SurveyLargeItem
                {
                    Id = 2.ToGuid(),
                    LargeItemFK = 2.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 1,
                    Status = LargeItemStatus.Repairable,
                },

                new SurveyLargeItem
                {
                    Id = 3.ToGuid(),
                    LargeItemFK = 2.ToGuid(),
                    SurveyFK = 2.ToGuid(),
                    Count = 3,
                    Status = LargeItemStatus.Repairable,
                },
            };

            var dbSet = context.Set<SurveyLargeItem>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
