using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Attributes;

namespace App.Module3.Shared.Models.Configuration
{
    public class ExtractDocumentDbConfig
    {
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module3.Shared.Constants.ConfigurationKeys.AppModule3ExtractDocumentDbUri)]
        public string EndpointUrlString { get; set; }


        public Uri EndpointUrl { get { return new Uri(EndpointUrlString); } }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module3.Shared.Constants.ConfigurationKeys.AppModule3ExtractDocumentDbAuthorisationKey)]
        public string AuthorizationKey { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module3.Shared.Constants.ConfigurationKeys.AppModule3ExtractDocumentDbExtractDatabaseName)]
        public string DatabaseName { get; set; }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(App.Module3.Shared.Constants.ConfigurationKeys.AppModule3ExtractDocumentDbCollectionName)]
        public string CollectionName { get; set; }
    }
}
