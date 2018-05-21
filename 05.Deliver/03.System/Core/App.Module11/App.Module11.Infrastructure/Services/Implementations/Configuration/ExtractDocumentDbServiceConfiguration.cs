using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Attributes;
using App.Module11.Shared.Models.Configuration;


namespace App.Module11.Infrastructure.Services.Implementations.Configuration
{
    public class ExtractDocumentDbServiceConfiguration
    {
        public ExtractDocumentDbServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            Config = keyVaultService.GetObject<ExtractDocumentDbConfig>();
        }

        public ExtractDocumentDbConfig Config { get; set; }

    }
}
