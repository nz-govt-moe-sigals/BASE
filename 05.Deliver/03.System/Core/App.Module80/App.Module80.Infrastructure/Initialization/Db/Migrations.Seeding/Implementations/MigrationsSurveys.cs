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
    public class MigrationsSurveys
    {
        public static void SeedDevOnlyEntries(AppModuleDbContext context)
        {
            var records = new[]
            {
                new Survey()
                {
                    Id = 1.ToGuid(),
                    Name = "Survey Operation GONE!",
                    BeachFK = 1.ToGuid(),
                    OrganisationFK = 1.ToGuid(),
                    NumberOfPersonsInvolved = 9,
                    StartTime = DateTime.UtcNow,
                    StartLatitude = 0.001m,
                    StartLongitude = -0.101m,
                    EndTime = DateTime.Now,
                    EndLatitude = 0.005m,
                    EndLongitude = -0.104m,

                },
                new Survey()
                {
                    Id = 2.ToGuid(),
                    Name = "Survey In Operation GOING!",
                    BeachFK = 1.ToGuid(),
                    OrganisationFK = 2.ToGuid(),
                    NumberOfPersonsInvolved = 45,
                    StartTime = DateTime.UtcNow,
                    StartLatitude = 0.001m,
                    StartLongitude = -0.101m,
                },
                new Survey
                {
                    Id = 3.ToGuid(),
                    Name = "Survey Operation WAITING! , but different beach",
                    BeachFK = 2.ToGuid(),
                    OrganisationFK = 2.ToGuid(),
                    NumberOfPersonsInvolved = 30
                },
            };

            var dbSet = context.Set<Survey>();

            dbSet.AddOrUpdate(p => p.Id, records);

            context.SaveChanges();
        }
    }
}
