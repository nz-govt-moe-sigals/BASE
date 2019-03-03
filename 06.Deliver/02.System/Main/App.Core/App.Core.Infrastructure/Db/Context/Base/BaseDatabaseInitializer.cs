using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Db.Context.Default;
using App.Core.Infrastructure.Db.Migrations;

namespace App.Core.Infrastructure.Db.Context.Base
{
    public class BaseDatabaseInitializer<TContext, TMigrationsConfiguration> : 
        MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>
        where TContext : System.Data.Entity.DbContext
        where TMigrationsConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<TContext>, new()

    {

        public BaseDatabaseInitializer() : base(useSuppliedContext: true)
        {

        }
    }
}
