using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.IDA.Models.Implementations;
using App.Core.Shared.Attributes;

namespace App.Core.Infrastructure.IDA.Models.Implementations
{
    public class OktaOidcConfidentialClientConfiguration : IOktaOidcConfidentialClientConfiguration
    {
        private string _clientPostLogoutUri;
        private string _baseuri;

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.BaseUri)]
        public string OktaApiUri
        {
            get { return this._baseuri; }
            set { this._baseuri = value; }
        }


        public string AuthorityUri
        {
            get
            {
                if(string.IsNullOrWhiteSpace(this._baseuri))
                    return null;
                return this._baseuri + "oauth2/default";
            }
            set { }
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.ClientId)]
        public string ClientId
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.ClientSecret)]
        public string ClientSecret
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.ClientRedirectUri)]
        public string ClientRedirectUri
        {
            get; set;
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.ClientPostLogoutRedirectUri)]
        public string ClientPostLogoutUri
        {
            get => this._clientPostLogoutUri ?? this.ClientRedirectUri;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "/";
                }
                this._clientPostLogoutUri = value;
            }
        }

        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(App.Core.Infrastructure.IDA.Constants.HostSettingsKeys.OktaOidcClientKeys.ApiKey)]
        public string ApiKey { get; set; }
    }
}