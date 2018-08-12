to get running in local env. 
This will give it access to keyvault

1. download azure cli
 -https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest

2. Open windows Powershell
3. az login
4. az account set <accountid>
 - b81bf4a6-b746-41c2-ac29-9466c74f2b57
5. az keyvault secret list --vault-name <vaultname>
 - nzmoebase000000dt

 -------------------------------

 https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer#cron-expressions

 -------------------------------------------------------------------------------

 When deploying it seems to come up with a warning as follows, 
 It does not seem to impact

 The configuration is not properly set for the Microsoft Azure WebJobs Dashboard. 
In your Microsoft Azure Website configuration you must set a connection string named AzureWebJobsDashboard by using the following format DefaultEndpointsProtocol=https;AccountName=NAME;AccountKey=KEY pointing to the Microsoft Azure Storage account where the Microsoft Azure WebJobs Runtime logs are stored. 

Please visit the article about configuring connection strings for more information on how you can configure connection strings in your Microsoft Azure Website.