using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module32.Infrastructure.Services;
using Microsoft.Azure.WebJobs;

namespace App.Module32.WebJob.Transfer
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            

            //var container = Container.For<AppAllInfrastructureRegistry>();
            //var app = AppDependencyLocator.Current.GetInstance<IExtractServiceController>();
            //app.ProcessAllTables();
        }
    }
}
