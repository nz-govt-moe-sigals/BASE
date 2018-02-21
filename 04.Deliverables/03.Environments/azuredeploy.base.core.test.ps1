

[cmdletbinding]
# Define method before invoking it
function Test-ArmTemplates {
    <#
    .SYNOPSIS
    ...etc...
    .DESCRIPTION
    ...etc...
    .EXAMPLE
    Provision-AzureAD
    .EXAMPLE
    Provision-AzureAD -adDomainName:myschool.school.nz
    .PARAMETER adDomainName
    ...etc...
    .PARAMETER adPrincipalName
    ...etc...
    #>
    [CmdletBinding()]
    Param (
        #[Parameter(mandatory = $false)] [bool]$deployResourceGroupByPowerShell = $false
    ) 
    

    # RUN 

    #NO npm install http-server -g
    #NO http-server . -d -p 3000 -o -cors -c-1
    # better
    # https://www.npmjs.com/package/local-web-server


    # .\azuredeploy.base.core.test.ps1

    # Login-AzureRmAccount

    $subscriptionName = "EDU-MOE-BASE-TestDev-01";
    Select-AzureRmSubscription -SubscriptionName "$subscriptionName" 


    $storageAccountName = "basecoredeploytmp" 
    $storageAccountKey = "4oy2aAxotGS68vuByKj6xErC51iK88hPqDZ8h0oLhhezufTKK+L/VS7MNYpvKUTzNAUCJIlYktQO74FsC5G3qg=="
    $storageAccountContainerName = "public"
    $localFileDirectory = "./"
    $storageAccountContainerPath = "base/core/";

    $ctx = New-AzureStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageAccountKey


    foreach ($file in Get-ChildItem -Path $localFileDirectory -Recurse -File) {
        $localFile = $localFileDirectory + $file
        $blobName = $storageAccountContainerPath + $file
        Write-Host $blobName;
        Set-AzureStorageBlobContent -Context $ctx -File $localFile -Container $storageAccountcontainerName -Blob $blobName -Force
    }


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

    $secureLogin = "NOTADMIN"| ConvertTo-SecureString  -AsPlainText -Force
    $securePassword = "NOTAPASSWORD" | ConvertTo-SecureString  -AsPlainText -Force


    Write-Host $secureLogin

    #-armTemplateRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm" `
    #-armTemplateParameterRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core/arm" `


    #https://blog.mexia.com.au/testing-arm-templates-with-pester
    #https://bentaylor.work/2017/10/unit-testing-azure-arm-templates-with-pester/


    $testRun = $false

    if ($testRun) {
        $rawResponse = $($successStream = Test-AzureRmResourceGroupDeployment `
                -ResourceGroupName "MYORG-MYAPP-MYBT-RG" `
                -TemplateFile "./azuredeploy.base.core.json" `
                -TemplateParameterFile "./azuredeploy.base.core.parameters.json" `
                -Mode "Incremental" `
                -resourceLocation "Australia East" `
                -resourceNameTemplate "ORG-APP-ENV-BRANCH-{RT}" `
                -armTemplateRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core" `
                -armTemplateParameterRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core" `
                -sqlServerAdministratorLogin $secureLogin `
                -sqlServerAdministratorLoginPassword $securePassword `
                -debug `
                -ErrorAction Stop) *>&1

        Write-Host   $rawResponse

        # take from the 32nth line of the response
        $result = (($rawResponse[32] -split "Body:")[1] | ConvertFrom-Json)

        if ($result.properties.provisioningState -eq "Succeeded") {
            Write-Host "Yay!"
        }
        else {
            Write-Host "NOT SO GOOD!"
        }
    }else{
        $rawResponse = $($successStream = New-AzureRmResourceGroupDeployment  `
                -ResourceGroupName "MYORG-MYAPP-MYBT-RG" `
                -TemplateFile "./azuredeploy.base.core.json" `
                -TemplateParameterFile "./azuredeploy.base.core.parameters.json" `
                -Mode "Incremental" `
                -resourceLocation "Australia East" `
                -resourceNameTemplate "ORG-APP-ENV-BRANCH-{RT}" `
                -armTemplateRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core" `
                -armTemplateParameterRootUrl "https://basecoredeploytmp.blob.core.windows.net/public/base/core" `
                -sqlServerAdministratorLogin $secureLogin `
                -sqlServerAdministratorLoginPassword $securePassword `
                -debug `
                -ErrorAction Stop) *>&1

                
        Write-Host   $rawResponse
        
    }

}


# INVOKE:
Test-ArmTemplates