# About # 

Settings are provided in one of the following ways:

* via AppSettings defined in the Code Base.
* via AppSettings, provided via the Build/Deployment pipeline.
* KeyStore.

The KeyStore is the slowest, so should be used sparesly -- but used for all confidential secrets,
such as OIDC ClientId/Secret.

Azure's deployment mechanism provides the ability to set AppSettings.
Use this for settings that should not be committed to the code base. 
In other words, anything that contains resource environment variables
(Azure ResourceGroup, Azure Resource names, DNS domain names, Azure AAD tenancy names).


## Settings







## KeyVault Defined Settings

### Required

The following should be a list of most or all of the above settings that are both 
SRC:KEYVAULT and REQUIRED:


* App:
  * Core:
    * Integration:
    * Azure:
      * Insights:
          * "System-Integration-Azure-ApplicationInsights-InstrumentationKey"; REQUIRED; SRC:KEYVAULT;
      * DocumentDb:
        * Default:
          * "System-Integration-Azure-DocumentDb-Default-Key"; REQUIRED; SRC:KEYVAULT;
      * StorageAccount:
        * Diagnostics:
          * "System-Integration-Azure-StorageAccount-Diagnostics-Key"; REQUIRED; SRC:KEYVAULT;
        * Default:
          * "System-Integration-Azure-StorageAccount-Default-Key"; REQUIRED; SRC:KEYVAULT;
        * Backups:
          * "System-Integration-Azure-StorageAccount-Backups-Key"; REQUIRED; SRC:KEYVAULT;
    * Scanii:
        * "System-Integration-Scanii-MalwareDetection-OAuth-ClientId"; REQUIRED; SRC:KEYVAULT;
        * "System-Integration-Scanii-MalwareDetection-OAuth-ClientSecret"; REQUIRED; SRC:KEYVAULT;
      * Oidc:
          * "System-Integration-Oidc-ClientId"; REQUIRED; SRC:KEYVAULT;
          * Notes: The ClientId and ClientSecret are obtained by registering the app up to a remote OIDC capable IdP
          * "System-Integration-Oidc-ClientSecret"; REQUIRED; SRC:KEYVAULT;
      * Notes: The ClientId and ClientSecret are obtained by registering the app up to a remote OIDC capable IdP

### Optional

The following should be a list of most or all of the above settings that are both 
SRC:KEYVAULT and OPTIONAL:

* Not Applicable (Secrets MUST be in KeyVault).







## PIPELINE Defined Settings

### Required

* App:
  * Core:
    * Integration:
      * Azure:
        * Common:
          * "System-Integration-Azure-Common-ResourceName"; REQUIRED; SRC:PIPELINESETAPPSETTINGS
            * Example: "nzmoebase0000bt"
        * SqlServer:
          * "System-Integration-Azure-SqlDatabase-CodeFirst-AttachDebuggerToPSSeeding" 
            * Options: true|false
            * Must be provided by pipeline, to ensure dev variables are not used in prod...
          * "System-Integration-Azure-SqlDatabase-CodeFirst-SeedIncludeDemoEntries"
            * Options: true|false
            * Must be provided by pipeline, to ensure dev variables are not used in prod...
      * Oidc:
	    * General Settings for all OIDC Clients:
          * "System-Integration-Oidc-AuthorityUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-RedirectUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * Notes: This the DNS based url where the remote IdP redirects users back to when they have completed SignUp/In.
          * Example: "https://foobar.com/"
          * "System-Integration-Oidc-ClientPostLogoutUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * Notes: This the relational uri the user is directed back to after deleting their security token.
          * Example: "/"
          * "System-Integration-Oidc-AuthorityUriType"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-AuthorityTenantName"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-AuthorityUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
            <add key="System-Integration-Oidc-ApproachType" value="B2CUsingOIDCAndCookiesAndBearerTokens"/>
        * AAD SPECIFIC OIDC Client Settings/TODO:
          * "System-Integration-Oidc-PolicyBased-AadInstance" REQUIRED: SRC:PIPELINESETAPPSETTINGS
        * B2C SPECIFIC OIDC Client Settings:
          * "System-Integration-Oidc-PolicyBased-AuthorityCookieConfigurationPolicyUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-AuthorityTokenConfigurationPolicyUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-DefaultPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-SignUpPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-SignInPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-SignUpSignInPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-UserProfilePolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-EditProfilePolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "System-Integration-Oidc-PolicyBased-ResetPasswordPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS



### Less Required

The following are required as well..but can wait. 
They probably should not be in the CodeBase/web.config as it ties the code strongly down
to a specific system, making the code less reusable. 


* App:
  * Core:
    * "SystemInfo":
      * Provides the name/description of the app (used by FrontEnds):
        * "System-Application-Info-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Info-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
      * Describe the Creator of the App:
        * "System-Application-Creator-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Creator-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Creator-SiteUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Creator-ContactUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
      * Describe the Distributor of the App:
        * "System-Application-Distributor-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Distributor-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Distributor-SiteUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * "System-Application-Distributor-ContactUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;



### Optional

The following are not required, but are there for those who have to fiddle.

* App:
  * Core:
    * Integration:
      * Azure:
        * KeyVault:
          * Default:
          * "System-Integration-Azure-KeyVaultStores-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS; 
            * Notes: Not required as if not provided, falls back to System-Integration-Azure-Common-ResourceName
        * StorageAccount:
          * Default:
            * "System-Integration-Azure-StorageAccount-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
              * Notes: If not provided, falls back to System-Integration-Azure-Common-ResourceName + Suffix
            * "System-Integration-Azure-StorageAccount-Default-ResourceNameSuffix"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
              * Default: ''
          * Diagnostics:
            * "System-Integration-Azure-StorageAccount-Diagnostics-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
              * Notes: If not provided, falls back to System-Integration-Azure-Common-ResourceName + Suffix
            * "System-Integration-Azure-StorageAccount-Diagnostics-ResourceNameSuffix"; OPTIONAL; SRC:APPSETTINGS|PIPELINESETAPPSETTINGS;
            * Default: 'di'
          * Backups:
            * "System-Integration-Azure-StorageAccount-Backups-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
              * Notes: If not provided, falls back to System-Integration-Azure-Common-ResourceName + Suffix
            * "System-Integration-Azure-StorageAccount-Backups-ResourceNameSuffix"; OPTIONAL; SRC:APPSETTINGS|PIPELINESETAPPSETTINGS;
              * Default: 'bk'
        * DocumentDb:
          * Default:
              * "System-Integration-Azure-DocumentDb-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
              * "System-Integration-Azure-DocumentDb-Default-ResourceNameSuffix"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
        * SqlServer:
        * Default:
            * "System-Integration-Azure-SqlDatabase-CodeFirst-AttachDebuggerToPSSeeding"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
            * Options: "true|false" 
            * Purpose: Seeding from Powershell can be difficult to debug. This Attaches a Debugger
          * "System-Integration-Azure-SqlDatabase-CodeFirst-SeedIncludeDemoEntries"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
            * Options: "true|false" 
            * Purpose: Seeding can include demo records to get going quicker:
        * Insights:
          * System-Integration-Azure-ApplicationInsights-Enabled; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * Default: false
          * Options: true|false
            * Notes: Diagnostics should be enabled, but maybe you want to wait till you have other things sorted out:
      * Scanii:
      * MalwareDetection:
          * System-Integration-MalwareDetection-Scanii-BaseUri; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
            * Notes: Most of the Scanii settings (secrets) are configured form the KeyVault, except for this optional path
            * Default: https://api-ap1.scanii.com/v2.1/





## AppSettings Defined Settings

### Required



### Optional

* App:
  * Core:
    * Security:
    * "System-TLS-SecurityProtocol"; OPTIONAL; SRC:APPSETTINGS;
    * Description: define that all outgoing requests are over Tls12
      * Options:
  * Media:
    * "System-Media-HashType"; OPTIONAL; SRC:APPSETTINGS;
      * What hash to use to compare uploaded media.



### Developer Settings 

* "System-Integration-Azure-Common-ResourceName"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
  * Example: "nzmoebase0000bt"
  * It's sort of ok to be in local web.config (any better suggestion?), 
    but must be overwritten by pipeline
* "System-Integration-Azure-SqlDatabase-CodeFirst-AttachDebuggerToPSSeeding"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS; 
  * Options: true|false
* "System-Integration-Azure-SqlDatabase-CodeFirst-SeedIncludeDemoEntries"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
  * Options: true|false
