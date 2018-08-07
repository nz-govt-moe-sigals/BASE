using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module32.Infrastructure.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace App.Module32.WebJob.Transfer
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        [NoAutomaticTrigger]
        public static void ProcessQueueMessage(/*[QueueTrigger("queue")]*/ string message, ILogger log)
        {
            Stopwatch sw = Stopwatch.StartNew();
            log.LogInformation($"{DateTime.UtcNow} - Executing {message}");
            try
            {
                //var app = AppDependencyLocator.Current.GetInstance<IExtractServiceController>();
                //app.ProcessAllTables();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Job did not run properly");
                throw;
            }
            finally
            {
                sw.Stop();
                log.LogInformation($"{DateTime.UtcNow} - Total Minutes: {sw.Elapsed.TotalMinutes}, Total Seconds: {sw.Elapsed.TotalSeconds}");
            }
                      
          
        }
    }
}
