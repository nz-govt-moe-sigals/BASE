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