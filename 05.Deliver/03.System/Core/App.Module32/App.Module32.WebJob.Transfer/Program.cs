using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Module32.Infrastructure.Constants.Db;
using App.Module32.Shared.Models.Entities;
using Microsoft.Azure.WebJobs;

namespace App.Module32.WebJob.Transfer
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            PowershellServiceLocatorConfig.Initialize();
            var connectionString = GetConnectionString();
            var config = new JobHostConfiguration(connectionString);

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            WarmUpDatabase();
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }

        static void WarmUpDatabase()
        {
            var repo = AppDependencyLocator.Current.GetInstance<IRepositoryService>();
            repo.Count<EducationSchoolProfile>(AppModuleDbContextNames.Default);
        }

        static string GetConnectionString()
        {
            var keyVaultService = AppDependencyLocator.Current.GetInstance<IAzureKeyVaultService>();
            var configuration =
                keyVaultService.GetObject<AzureStorageAccountDefaultConfigurationSettings>();


            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = configuration.DefaultResourceName;
            }

            return $"DefaultEndpointsProtocol=https;AccountName={configuration.ResourceName}{configuration.ResourceNameSuffix};AccountKey={configuration.Key};EndpointSuffix=core.windows.net";
        }
    }
}
