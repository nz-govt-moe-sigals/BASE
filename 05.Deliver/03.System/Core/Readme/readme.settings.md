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
          * "App-Core-Integration-Azure-ApplicationInsights-InstrumentationKey"; REQUIRED; SRC:KEYVAULT;
	    * DocumentDb:
		  * Default:
            * "App-Core-Integration-Azure-DocumentDb-Default-Key"; REQUIRED; SRC:KEYVAULT;
	    * StorageAccount:
		  * Diagnostics:
            * "App-Core-Integration-Azure-StorageAccount-Diagnostics-Key"; REQUIRED; SRC:KEYVAULT;
		  * Default:
            * "App-Core-Integration-Azure-StorageAccount-Default-Key"; REQUIRED; SRC:KEYVAULT;
		  * Backups:
            * "App-Core-Integration-Azure-StorageAccount-Backups-Key"; REQUIRED; SRC:KEYVAULT;
	  * Scanii:
        * "App-Core-Integration-Scanii-MalwareDetection-Key"; REQUIRED; SRC:KEYVAULT;
        * "App-Core-Integration-Scanii-MalwareDetection-Secret"; REQUIRED; SRC:KEYVAULT;
      * Oidc:
          * "App-Core-Integration-Oidc-ClientId"; REQUIRED; SRC:KEYVAULT;
    	    * Notes: The ClientId and ClientSecret are obtained by registering the app up to a remote OIDC capable IdP
          * "App-Core-Integration-Oidc-ClientSecret"; REQUIRED; SRC:KEYVAULT;
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
          * "App-Core-Integration-Azure-Common-ResourceName"; REQUIRED; SRC:PIPELINESETAPPSETTINGS
            * Example: "nzmoebase0000bt"
	    * SqlServer:
          * "App-Core-Integration-Sql-CodeFirst-AttachDebuggerToPSSeeding" 
            * Options: true|false
            * Must be provided by pipeline, to ensure dev variables are not used in prod...
          * "App-Core-Integration-Sql-CodeFirst-SeedIncludeDemoEntries"
            * Options: true|false
            * Must be provided by pipeline, to ensure dev variables are not used in prod...
      * Oidc:
        * General Settings for all OIDC Clients:
          * "App-Core-Integration-Oidc-AuthorityUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-RedirectUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
    	    * Notes: This the DNS based url where the remote IdP redirects users back to when they have completed SignUp/In.
    	    * Example: "https://foobar.com/"
          * "App-Core-Integration-Oidc-ClientPostLogoutUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
    	    * Notes: This the relational uri the user is directed back to after deleting their security token.
    	    * Example: "/"
          * "App-Core-Integration-Oidc-AuthorityUriType"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-AuthorityTenantName"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-AuthorityUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
    	      <add key="App-Core-Integration-Oidc-ApproachType" value="B2CUsingOIDCAndCookiesAndBearerTokens"/>
        * AAD SPECIFIC OIDC Client Settings/TODO:
          * "App-Core-Integration-Oidc-PolicyBased-AadInstance" REQUIRED: SRC:PIPELINESETAPPSETTINGS
        * B2C SPECIFIC OIDC Client Settings:
          * "App-Core-Integration-Oidc-PolicyBased-AuthorityCookieConfigurationPolicyUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-AuthorityTokenConfigurationPolicyUri"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-DefaultPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-SignUpPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-SignInPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-SignUpSignInPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-UserProfilePolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-EditProfilePolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS
          * "App-Core-Integration-Oidc-PolicyBased-ResetPasswordPolicyId"; REQIURED; SRC:PIPELINESETAPPSETTINGS



### Less Required

The following are required as well..but can wait. 
They probably should not be in the CodeBase/web.config as it ties the code strongly down
to a specific system, making the code less reusable. 

* App:
  * Core:
      * "SystemInfo":
  	    * Provides the name/description of the app (used by FrontEnds):
          * "App-Core-Application-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * Describe the Creator of the App:
          * "App-Core-Application-Creator-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Creator-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Creator-SiteUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Creator-ContactUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
        * Describe the Distributor of the App:
          * "App-Core-Application-Distributor-Name"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Distributor-Description"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Distributor-SiteUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
          * "App-Core-Application-Distributor-ContactUrl"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;



### Optional

The following are not required, but are there for those who have to fiddle.

* App:
  * Core:
    * Integration:
      * Azure:
        * KeyVault:
          * Default:
    	    * "App-Core-Integration-Azure-KeyVaultStores-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS; 
    	      * Notes: Not required as if not provided, falls back to App-Core-Integration-Azure-Common-ResourceName
    	  * StorageAccount:
    	    * Default:
            * "App-Core-Integration-Azure-StorageAccount-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	        * Notes: If not provided, falls back to App-Core-Integration-Azure-Common-ResourceName + Suffix
            * "App-Core-Integration-Azure-StorageAccount-Default-ResourceNameSuffix"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
    	        * Default: ''
    	    * Diagnostics:
            * "App-Core-Integration-Azure-StorageAccount-Diagnostics-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	        * Notes: If not provided, falls back to App-Core-Integration-Azure-Common-ResourceName + Suffix
            * "App-Core-Integration-Azure-StorageAccount-Diagnostics-ResourceNameSuffix"; OPTIONAL; SRC:APPSETTINGS|PIPELINESETAPPSETTINGS;
      	    * Default: 'di'
          * Backups:
            * "App-Core-Integration-Azure-StorageAccount-Backups-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	        * Notes: If not provided, falls back to App-Core-Integration-Azure-Common-ResourceName + Suffix
            * "App-Core-Integration-Azure-StorageAccount-Backups-ResourceNameSuffix"; OPTIONAL; SRC:APPSETTINGS|PIPELINESETAPPSETTINGS;
    	        * Default: 'bk'
        * DocumentDb:
    	    * Default:
              * "App-Core-Integration-Azure-DocumentDb-Default-ResourceName"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
              * "App-Core-Integration-Azure-DocumentDb-Default-ResourceNameSuffix"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
        * SqlServer:
    	  * Default:
            * "App-Core-Integration-Sql-CodeFirst-AttachDebuggerToPSSeeding"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	      * Options: "true|false" 
    	      * Purpose: Seeding from Powershell can be difficult to debug. This Attaches a Debugger
    	    * "App-Core-Integration-Sql-CodeFirst-SeedIncludeDemoEntries"; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	      * Options: "true|false" 
    	      * Purpose: Seeding can include demo records to get going quicker:
        * Insights:
          * App-Core-Integration-Azure-ApplicationInsights-Enabled; OPTIONAL; SRC:PIPELINESETAPPSETTINGS;
    	    * Default: false
    	    * Options: true|false
            * Notes: Diagnostics should be enabled, but maybe you want to wait till you have other things sorted out:
      * Scanii:
        * App-Core-Integration-MalwareDetection-Scanii-BaseUri; OPTIONAL; SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
    	  * Notes: Most of the Scanii settings (secrets) are configured form the KeyVault, except for this optional path
    	  * Default: https://api-ap1.scanii.com/v2.1/


## AppSettings Defined Settings

### Required

### Optional

* App:
  * Core:
    * Security:
	  * "App-Core-TLS-SecurityProtocol"; OPTIONAL; SRC:APPSETTINGS;
		* Description: define that all outgoing requests are over Tls12
	    * Options:
	* Media:
	  * "App-Core-Media-HashType"; OPTIONAL; SRC:APPSETTINGS;
	    * What hash to use to compare uploaded media.



### Developer Settings 

* "App-Core-Integration-Azure-Common-ResourceName"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
  * Example: "nzmoebase0000bt"
  * It's sort of ok to be in local web.config (any better suggestion?), 
    but must be overwritten by pipeline
* "App-Core-Integration-Sql-CodeFirst-AttachDebuggerToPSSeeding"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS; 
  * Options: true|false
* "App-Core-Integration-Sql-CodeFirst-SeedIncludeDemoEntries"; OPTIONAL: SRC:PIPELINESETAPPSETTINGS|APPSETTINGS;
  * Options: true|false
