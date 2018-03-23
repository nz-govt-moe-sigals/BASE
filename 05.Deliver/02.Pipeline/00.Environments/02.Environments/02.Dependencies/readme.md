## About ##

Known systems this application integrates with include (but being a live doc, probably not limited to):

* Azure Telemetry (Application Insights):
  * see App.Core.Application/ApplicationInsights.config 
  * you'll have to set a Key obtained from your Azure Subscription (Application Insights Key)
  * TODO: Ensure that keys are not committed (DOS risk?)
  * Example process to get one:
    *  An Instrumentation Key can be automatically generated when you setup a project in VSTS, but that's not the cleanest. Instead, consider:
       * Sign in to portal.azure.com
       * Use New+ to add new Insights
       * Create it within a new Project specific Subscription and Resource Group
       * navigate to its Properties Blade
       * Get the Instrumentation number
       * Stick it in the gitignored web.config.appsettings.secret file.	   
* Azure Sql Database:
  * You'll need a connection string to a local database, but you'll also need
  * You'll need connection strings for the databases in the cloud.
* Azure Storage Account:
  * In Azure, you can't save to a local hard drive (TLTE: you'll end up whatever you put there)
  * Instead, you'll be storing media to a storage account.
  * You get that storage account identifier from Azure.
* IDP:
  * Any modern app will be using OIDC to sign in users.
  * This demo is using OIDC over AAD B2C.
  * See web.config.appsettings.template and web.config.appsetting.secret
  * Note that you *MUST* use web.config.appsettings.secret (or you'll be committing credential Secrets)
* AntiMalware:
  * See web.config.appsettings.template and web.config.appsetting.secret
  * Note that you *MUST* use web.config.appsettings.secret (or you'll be committing credential Secrets)
  * You'll have to set the key and secret that is specific to the project's scanii account.
* SMTP:
  * You'll have to configure the MTA parameters.
  * Note that you *MUST* not embed the username/password in the app.settings (or you'll be committing Secrets)

  
You'll also need:
* Service Accounts to the database in Azure in order to use AAD and integrated security there 
(much more secure than passing username/password credentials over the wire).
