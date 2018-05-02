[cmdletbinding]
function Post-Deploy-Infrastructure-Assign-Rights {
    [CmdletBinding()]
    Param (
    )

    # Assign rights from WebApp to default StorageAccount:
    $scope = "/subscriptions/$($ENV:custom_vars_webSiteSubscriptionId)/resourceGroups/$($ENV:custom_vars_resourceGroupName)/providers/Microsoft.Storage/storageAccounts/$($ENV:custom_vars_diagnosticsStorageAccountResourceName)"
    New-AzureRmRoleAssignment -ObjectId $ENV:custom_vars_webSitePrincipalId -RoleDefinitionName "Contributor" -Scope $scope

    # Assign rights from WebApp to default StorageAccount:
    $scope = "/subscriptions/$($ENV:custom_vars_webSiteSubscriptionId)/resourceGroups$($ENV:custom_vars_resourceGroupName)/providers/Microsoft.Storage/storageAccounts/$($ENV:custom_vars_tempStorageAccountResourceName)"
    New-AzureRmRoleAssignment -ObjectId $ENV:custom_vars_webSitePrincipalId -RoleDefinitionName "Contributor" -Scope $scope
    
    # Assign rights from WebApp to default StorageAccount:
    $scope = "/subscriptions/$($ENV:custom_vars_webSiteSubscriptionId)/resourceGroups/$($ENV:custom_vars_resourceGroupName)/providers/Microsoft.Storage/storageAccounts/$($ENV:custom_vars_defaultStorageAccountResourceName)"
    New-AzureRmRoleAssignment -ObjectId $ENV:custom_vars_webSitePrincipalId -RoleDefinitionName "Contributor" -Scope $scope

}



#Post-Deploy-Infrastructure-Assign-Rights