# README: PREREQUISITES
# * Custom Variables:
#   Your Build Definition will need custom Variables:
#   custom.vars.AppInstance = "";
#   custom.vars.resourceNameTemplate = "MYORG-MYAPP-{APPINST}-{RESOURCETYPE}";
#   custom.vars.subscriptionName = "...";

# README
# * Build Variables are automatically passed to PowerShell scripts as environment variables.
#   Vars Must be Uppercase.
#   And "." is converted to "_", so a custom variable with a key of
#   'custom.vars.Foo' is available as '$env:CUSTOM_VARS_FOO'
# * Arguments

# Context:
#BUILD_ARTIFACTSTAGINGDIRECTORY

# https://docs.microsoft.com/en-gb/vsts/build-release/concepts/definitions/release/variables?tabs=batch#default-variables

#Write-Host "...System.TeamProject: $(System.TeamProject)"
#Write-Host "...System.TeamProjectId: $(System.TeamProjectId)"


#Write-Host "...System.TeamProject: $(ENV:SYSTEM_TEAMPROJECT)"
#Write-Host "...System.TeamProjectId: $(ENV:SYSTEM_TEAMPROJECTID)"

Write-Host "...."

#Write-Host "...BUILD_ARTIFACTSTAGINGDIRECTORY: $(BUILD_ARTIFACTSTAGINGDIRECTORY)"
#Write-Host "...BUILD_BUILDID: $(BUILD_BUILDID)"
#Write-Host "...BUILD_BUILDNUMBER: $(BUILD_BUILDNUMBER)"
#Write-Host "...BUILD_SOURCEDIRECTORY: $(BUILD_SOURCEDIRECTORY)"
#Write-Host "...BUIL_STAGINGDIRECTORY: $(BUILD_STAGINGDIRECTORY)"
#Write-Host "...BUILD_BINARIESDIRECTORY: $(BUILD_BINARIESDIRECTORY)"
#Write-Host "...BUILD_WORKINGDIRECTORY: $(BUILD_WORKINGDIRECTORY)"
#Write-Host "...BUILD_REASON: $(BUILD_REASON)"
#Write-Host "...BUILD_REPOSITORY_CLEAN: $(BUILD_REPOSITORY_CLEAN)"
#Write-Host "...BUILD_SOURCEBRANCH: $(BUILD_SOURCEBRANCH)"
#Write-Host "...BUILD_SOURCEBRANCH_NAME: $(BUILD_SOURCEBRANCH_NAME)"

Write-Host "...."
$a = $Env:BUILD_ARTIFACTSTAGINGTABLE;

Write-Host "...BUILD_ARTIFACTSDIRECTORY: $(Env:BUILD_ARTIFACTSTAGINGDIRECTORY)"
Write-Host "...BUILD_BUILDID: $(ENV:BUILD_BUILDID)"
Write-Host "...BUILD_BUILDNUMBER: $(ENV:BUILD_BUILDNUMBER)"
Write-Host "...BUILD_SOURCEDIRECTORY: $(ENV:BUILD_SOURCEDIRECTORY)"
Write-Host "...BUILD_STAGINGDIRECTORY: $(ENV:BUILD_STAGINGDIRECTORY)"
Write-Host "...BUILD_BINARIESDIRECTORY: $(ENV:BUILD_BINARIESDIRECTORY)"
Write-Host "...BUILD_REASON: $(ENV:BUILD_REASON)"
Write-Host "...BUILD_REPOSITORY_CLEAN: $(ENV:BUILD_REPOSITORY_CLEAN)"
Write-Host "...BUILD_SOURCEBRANCH: $(ENV:BUILD_SOURCEBRANCH)"
Write-Host "...BUILD_SOURCEBRANCH_NAME: $(ENV:BUILD_SOURCEBRANCH_NAME)"

# Create Temp Vars:

# Cleanup Parameters:
$subscriptionName = $ENV:CUSTOM_VARS_SUBSCRIPTION_NAME;
if ($subscriptionName -eq $null){$subscriptionName = $ENV:CUSTOM_VARS_SUBSCRIPTIONNAME;}
if ($subscriptionName -eq $null){$subscriptionName = "";}
Write-Host "...subscriptionName: $(subscriptionName)"

# ...Branch Name:
$buildSourceBranchName = $ENV:BUILD_SOURCEBRANCH_NAME;
if ($buildSourceBranchName -eq $null){$buildSourceBranchName = "";}
if ($buildSourceBranchName -eq "master"){$buildSourceBranchName = "";}

# ...Cleanup the ARM Location Uri/Path:
$defaultArmLocation = $env:custom_vars_DEFAULTARMLOCATION;
if ($defaultArmLocation -eq $null){$defaultArmLocation = "";}
Write-Host "...defaultArmLocation: $(defaultArmLocation)"
# ...Cleanup the AppInstanceIdentifier:
$resourceEnvIdentifier = $env:custom_vars_resourceEnvIdentifier;
if ($appInstanceIdentifier -eq $null){$resourceEnvIdentifier = "";}
Write-Host "...resourceEnvIdentifier: $(resourceEnvIdentifier)"

# ...Cleanup the resourceNameTemplate:
$resourceNameTemplate = $env:CUSTOM_VARS_RESOURCENAMETEMPLATE;
if ($resourceNameTemplate -eq $null){$resourceNameTemplate = "";}
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"



# Create Name of ResourceGroup
Write-Host "Solving Resouce Group Name Template"
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"
Write-Host "...Replaceing '{ENV}'/'{ENVID}'/'{ENVIDENTIFIER} found within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate= $resourceNameTemplate.Replace("{ENVIDENTIFIER}", $resourceEnvIdentifier);
$resourceNameTemplate= $resourceNameTemplate.Replace("{ENVID}", $resourceEnvIdentifier);
$resourceNameTemplate= $resourceNameTemplate.Replace("{ENV}", $resourceEnvIdentifier);
$resourceNameTemplate= $resourceNameTemplate.Replace("{SOURCEBRANCHNAME}", $buildSourceBranchName);
$resourceNameTemplate= $resourceNameTemplate.Replace("{SOURCEBRANCH}", $buildSourceBranchName);
$resourceNameTemplate= $resourceNameTemplate.Replace("{BRANCHNAME}", $buildSourceBranchName);
$resourceNameTemplate= $resourceNameTemplate.Replace("{BRANCH}", $buildSourceBranchName);
$resourceNameTemplate= $resourceNameTemplate.Replace("--", "-");
Write-Host "...resourceNameTemplate: $(resourceNameTemplate)"

# Set Subscription
Select-AzureRmSubscription -SubscriptionName "$subscriptionName"

# Create Resource Group
# New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName-TemplateUri $templateUri



# Set output variables:
Write-host $env:OutputVar
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_RESOURCENAMETEMPLATE;]$(resourceNameTemplate)")
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_APPINSTANCE;]$(appInstanceIdentifier)")
Write-host $env:OutputVar