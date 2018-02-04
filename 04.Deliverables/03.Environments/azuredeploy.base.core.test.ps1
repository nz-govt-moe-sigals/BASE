# .\azuredeploy.base.core.test.ps1

# Login-AzureRmAccount

$subscriptionName = "ESL-EDU-B2C-ProdUAT-01";
Select-AzureRmSubscription -SubscriptionName "$subscriptionName" 


#Next startment provides a listing of all Resourceproviders and thier status in the subscription
#Get-AzureRmResourceProvider -ListAvailable |Export-csv 'ResourceProviders.csv'
#next statements register the providers required to build a VM
#Register-AzureRmResourceProvider -ProviderNamespace Microsoft.Compute
#Register-AzureRmResourceProvider -ProviderNamespace Microsoft.Storage 
#Register-AzureRmResourceProvider -ProviderNamespace Microsoft.Network

# Better code - but still does not work.
# https://www.nwcadence.com/blog/resolving-authorizationfailed-2016
#Get-AzureRmResourceProvider -ListAvailable | Select-Object ProviderNamespace | Foreach-Object { Register-AzureRmResourceProvider -ProviderName $_.ProviderNamespace  }

# New-AzureRmRoleAssignment  -ObjectId '1aa94e7a-7cdb-4edd-bed8-6a9a5b9b854e' -ResourceGroupName "MYORG-MYAPP-MYBT-RG" -RoleDefinitionName Owner

$env:CUSTOM_VARS_resourceNameTemplate = "MYORG-MYAPP-MYENV-MYBRANCH-{RESOURCETYPE}";
$env:CUSTOM_VARS_armTemplateRootUri = "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm";
$env:CUSTOM_VARS_armTemplateRootSas = "";
$env:CUSTOM_VARS_armTemplateParameterRootUri = "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm";
$env:CUSTOM_VARS_armTemplateParameterRootSas = ""; 

$secureLogin = ConvertTo-SecureString "NOTADMIN" -AsPlainText -Force;
$securePassword = ConvertTo-SecureString "NOTPASSWORD" -AsPlainText -Force;


Test-AzureRmResourceGroupDeployment `
    -ResourceGroupName "MYORG-MYAPP-MYBT-RG" `
    -TemplateFile "./azuredeploy.base.core.json" `
    -TemplateParameterFile "./azuredeploy.base.core.parameter.json" `
    -Mode "Incremental" `
    `
    -resourceLocation "Australia East" `
    -resourceNameTemplate "MYORG-MYAPP-MYENV-MYBRANCH-MYMY-{RESOURCETYPE}" `
    -armTemplateRootUri "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm" `
    -armTemplateParameterRootUri "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm" `
    -sqlServerAdministratorLogin $secureLogin `
    -sqlServerAdministratorPassword $securePassword
    

 