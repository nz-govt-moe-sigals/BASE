using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Attributes;

namespace App.Module31.Shared.Models.Configuration
{
    public class ExtractDocumentDbConfig
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module31.Shared.Constants.ConfigurationKeys.AppModule31ExtractDocumentDbUri)]
        public string EndpointUrlString { get; set; }


        public Uri EndpointUrl { get { return new Uri(EndpointUrlString); } }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module31.Shared.Constants.ConfigurationKeys.AppModule31ExtractDocumentDbAuthorisationKey)]
        public string AuthorizationKey { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module31.Shared.Constants.ConfigurationKeys.AppModule31ExtractDocumentDbExtractDatabaseName)]
        public string DatabaseName { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module31.Shared.Constants.ConfigurationKeys.AppModule31ExtractDocumentDbCollectionName)]
        public string CollectionName { get; set; }
    }
}





