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
    public class MigrationsSurveyLocations
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new SurveyLocation()
                {
                    Id = 1.ToGuid(),
                    SurveyLocationId = "4124451",
                    Name = "Riversdale",
                    RegionFK = 1.ToGuid(),
                    Access = true,
                    BackOfBeach = "Town",
                    Width = 1.1m,
                    Length = 11.85m

                },
                new SurveyLocation()
                {
                    Id = 2.ToGuid(),
                    Name = "Castlepoint",
                    SurveyLocationId = "4124459",
                    RegionFK = 1.ToGuid(),
                    Access = true,
                    BackOfBeach = "Town",
                    Width = 0.85m,
                    Length = 21.85m
                },
                new SurveyLocation
                {
                    Id = 3.ToGuid(),
                    SurveyLocationId = "3124459",
                    Name = "90 Mile Beach",
                    RegionFK = 2.ToGuid(),
                    Access = true,
                    BackOfBeach = "Forest",
                    Width = 0.75m,
                    Length = 90.01m
                },
            };

            var dbSet = context.Set<SurveyLocation>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }

    }
}
