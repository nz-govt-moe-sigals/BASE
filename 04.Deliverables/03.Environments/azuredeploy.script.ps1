# README: PREREQUISITES
# * Custom Variables:
#   Your Build Definition will need custom Variables:
#   custom.vars.AppInstance = "";
#   custom.vars.resourceNameTemplate = "MYORG-MYAPP-{APPINST}-{RESOURCETYPE}";

# README
# * Build Variables are automatically passed to PowerShell scripts as environment variables.
#   Note thate "." is converted to "_", so a custom variable with a key of
#   'custom.vars.Foo' is available as '$env:custom_vars_Foo'
# * Arguments

# Context:
BUILD_ARTIFACTSTAGINGDIRECTORY
Write-Host "...BUILD_ARTIFACTSTAGINGDIRECTORY: $(BUILD_ARTIFACTSTAGINGDIRECTORY)"
Write-Host "...BUILD_BUILDID: $(BUILD_BUILDID)"
Write-Host "...BUILD_BUILDNUMBER: $(BUILD_BUILDNUMBER)"
Write-Host "...BUILD_SOURCEDIRECTORY: $(BUILD_SOURCEDIRECTORY)"
Write-Host "...BUILD_STAGINGDIRECTORY: $(BUILD_STAGINGDIRECTORY)"
Write-Host "...BUILD_BINARIESDIRECTORY: $(BUILD_BINARIESDIRECTORY)"
Write-Host "...BUILD_REASON: $(BUILD_REASON)"
Write-Host "...BUILD_REPOSITORY_CLEAN: $(BUILD_REPOSITORY_CLEAN)"
Write-Host "...BUILD_SOURCEBRANCH: $(BUILD_SOURCEBRANCH)"
Write-Host "...BUILD_SOURCEBRANCH_NAME: $(BUILD_SOURCEBRANCH_NAME)"

Write-Host "...."

Write-Host "...BUILD_ARTIFACTSTAGINGDIRECTORY: $(ENV:BUILD_ARTIFACTSTAGINGDIRECTORY)"
Write-Host "...BUILD_BUILDID: $(ENV:BUILD_BUILDID)"
Write-Host "...BUILD_BUILDNUMBER: $(ENV:BUILD_BUILDNUMBER)"
Write-Host "...BUILD_SOURCEDIRECTORY: $(ENV:BUILD_SOURCEDIRECTORY)"
Write-Host "...BUILD_STAGINGDIRECTORY: $(ENV:BUILD_STAGINGDIRECTORY)"
Write-Host "...BUILD_BINARIESDIRECTORY: $(ENV:BUILD_BINARIESDIRECTORY)"
Write-Host "...BUILD_REASON: $(ENV:BUILD_REASON)"
Write-Host "...BUILD_REPOSITORY_CLEAN: $(ENV:BUILD_REPOSITORY_CLEAN)"
Write-Host "...BUILD_SOURCEBRANCH: $(ENV:BUILD_SOURCEBRANCH)"
Write-Host "...BUILD_SOURCEBRANCH_NAME: $(ENV:BUILD_SOURCEBRANCH_NAME)"


# Cleanup Parameters:
# ...Cleanup the ARM Location Uri/Path:
$defaultArmLocation = $env:custom_vars_DEFAULTARMLOCATION;
if ($defaultArmLocation -eq $null){$defaultArmLocation = "";}
Write-Host "...defaultArmLocation: $(defaultArmLocation)"
# ...Cleanup the AppInstanceIdentifier:
$appInstanceIdentifier = $env:custom_vars_APPINSTANCE;
if ($appInstanceIdentifier -eq $null){$appInstanceIdentifier = "";}
Write-Host "...appInstanceIdentifier: $(appInstanceIdentifier)"
# ...Cleanup the resourceNameTemplate:
$resourceNameTemplate = $env:CUSTOM_VARS_RESOURCENAMETEMPLATE;
if ($resourceNameTemplate -eq $null){$resourceNameTemplate = "";}
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"



# Create Name of ResourceGroup
Write-Host "Solving Resouce Group Name Template"
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"
Write-Host "...Replaceing '{APPINST}' found within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate= $resourceNameTemplate.Replace("{APPINST}", $appInstanceIdentifier);
$resourceNameTemplate= $resourceNameTemplate.Replace("--", "-");
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"


# Create Resource Group
# New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName-TemplateUri $templateUri



# Set output variables:
Write-host $env:OutputVar
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_RESOURCENAMETEMPLATE;]$(resourceNameTemplate)")
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_APPINSTANCE;]$(appInstanceIdentifier)")
Write-host $env:OutputVar