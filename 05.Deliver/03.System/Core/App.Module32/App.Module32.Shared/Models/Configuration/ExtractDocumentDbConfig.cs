using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Attributes;

namespace App.Module32.Shared.Models.Configuration
{
    public class ExtractDocumentDbConfig
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module32.Shared.Constants.ConfigurationKeys.AppModule32ExtractDocumentDbUri)]
        public string EndpointUrlString { get; set; }


        public Uri EndpointUrl { get { return new Uri(EndpointUrlString); } }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module32.Shared.Constants.ConfigurationKeys.AppModule32ExtractDocumentDbAuthorisationKey)]
        public string AuthorizationKey { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module32.Shared.Constants.ConfigurationKeys.AppModule32ExtractDocumentDbExtractDatabaseName)]
        public string DatabaseName { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module32.Shared.Constants.ConfigurationKeys.AppModule32ExtractDocumentDbCollectionName)]
        public string CollectionName { get; set; }


        public int PageQuerySize => 750;
    }
}





