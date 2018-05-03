using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure
{
    using System.Data.Entity;

    public static class TOMOVE
    {
        public static void DoWork(Exception exception)
        {
            // Get Current DbContext
            foreach (DbContext dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
            {
                if (ShouldSave(dbContext, exception))
                {
                    PreprocessModelsBeforeSaving(dbContext);
                    dbContext.SaveChanges();
                }
            }

        }

        private static void PreprocessModelsBeforeSaving(DbContext dbContext)
        {
            //TODO
            //throw new NotImplementedException();
        }


        //dont want it to try save if there is an exception unless it is core
        //because core does some sort of save every time?
        private static bool ShouldSave(DbContext dbContext, Exception exception)
        {
            return dbContext.ChangeTracker.HasChanges() &&
                   (exception == null || dbContext.GetType() == typeof(App.Core.Infrastructure.Db.Context.AppCoreDbContext));
        }


    }
}
