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
    public class MigrationsSurveyLitterItems
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new SurveyLitterItem()
                {
                    Id = 1.ToGuid(),
                    LitterItemFK = 1.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 5,
                    Weight = 0.11m,
                },
                new SurveyLitterItem
                {
                    Id = 2.ToGuid(),
                    LitterItemFK = 2.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 9,
                    Weight = 0.187m,
                },
                new SurveyLitterItem
                {
                    Id = 3.ToGuid(),
                    LitterItemFK = 4.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 1,
                    Weight = 0.199m,
                },
                new SurveyLitterItem
                {
                    Id = 4.ToGuid(),
                    LitterItemFK = 3.ToGuid(),
                    SurveyFK = 1.ToGuid(),
                    Count = 15,
                    Weight = 0.14m,
                },


                new SurveyLitterItem
                {
                    Id = 11.ToGuid(),
                    LitterItemFK = 1.ToGuid(),
                    SurveyFK = 2.ToGuid(),
                    Count = 2,
                    Weight = 0.12m,
                },
                new SurveyLitterItem
                {
                    Id = 12.ToGuid(),
                    LitterItemFK = 2.ToGuid(),
                    SurveyFK = 2.ToGuid(),
                    Count = 5,
                    Weight = 0.91m,
                },
                new SurveyLitterItem
                {
                    Id = 13.ToGuid(),
                    LitterItemFK = 3.ToGuid(),
                    SurveyFK = 2.ToGuid(),
                    Count = 5,
                    Weight = 1.11m,
                },
            };

            var dbSet = context.Set<SurveyLitterItem>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
