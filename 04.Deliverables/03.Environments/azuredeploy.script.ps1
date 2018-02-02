<#
# README

  ## BACKGROUND
  Visual Studio Online (VSO)'s easy, Drag/Drop system to build a Build Definitions has the advantage
  of being easy to drag/drop and put together basic recipes, with a GUI to help determine the
  input parameters -- but it's also at the cost of keeping the recipe version controlled along
  with the deliverable code (don't forget the deliverable is the pipeline that delivers product, 
  not the product itself).
  Since we're developers...writting code is what we do. Including Build Pipelines. 

  The script heavily annotated to make it more accessible to team members of varying Powershell ability.



  ## PREREQUISITES

  ### PREREQUISITE KNOWLEDGE: POWERSHELL
  * Powershell is powerful while remaining easy. That said, a quick primer never hurt:
  * http://skysigal.com/it/ad/powershell/howto/syntax_basics/home 

  ### PREREQUISITE KNOWLEDGE: HOW TO GET CONTEXT INFO WITHIN YOUR SCRIPTS.
  Essentially, by the time this script is invoked, VSO will have pumped into a ton of variables.
  * More info: https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#predefined-variables
  * There is an Agent object
  * There is also a Server object
  * There is also a Build object
  * Every Custom Variable (eg: 'custom.Vars.Foo') you create in a VSO Build Definition will 
    be pumped into this memory space as $ENV:CUSTOM_VARS_FOO (note how it is an Env var, and the dots
    are replaced with '_')
  * you can also pass arguments to the script when you invoke it.

  ### PREREQUISITE KNOWLEDGE: AZURE AUTHENTICATION/SUBSCRIPTION CONTEXT
  Variables are then used to create or privision Resources within a specific target Azure Subscription. 

  ### PREREQUISITES: VARIABLES
  The script is expecting the following Custom Variable Inputs:
  * custom.vars.subscriptionName
  * custom.vars.resourceNameTemplate
  * custom.vars.resourceEnvIdentifier
  * custom.vars.defaultArmLocation
#>

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

# Cleanup Variables, Parameters and make local parameters:
$subscriptionName = $ENV:CUSTOM_VARS_SUBSCRIPTIONNAME;
if ($subscriptionName -eq $null){$subscriptionName = "";}
$buildSourceBranchName = $ENV:BUILD_SOURCEBRANCH_NAME;
if ($buildSourceBranchName -eq $null){$buildSourceBranchName = "";}
if ($buildSourceBranchName -eq "master"){$buildSourceBranchName = "";}
$resourceEnvIdentifier = $env:custom_vars_resourceEnvIdentifier;
if ($resourceEnvIdentifier -eq $null){$resourceEnvIdentifier = "";}
$resourceNameTemplate = $env:CUSTOM_VARS_RESOURCENAMETEMPLATE;
if ($resourceNameTemplate -eq $null){$resourceNameTemplate = "";}
$defaultArmLocation = $env:custom_vars_DEFAULTARMLOCATION;
if ($defaultArmLocation -eq $null){$defaultArmLocation = "";}

# Output System, Build's default and injected Variables:
Write-Host "Agent Variable of potential interests:"
Write-Host "...Agent.Id: $ENV:AGENT_ID"
Write-Host "...Agent.MachineName: $ENV:AGENT_MACHINENAME"
Write-Host "...Agent.BuildDirectory: $ENV:AGENT_BUILDDIRECTORY"
Write-Host "...Agent.WorkFolder: $ENV:AGENT_WORKFOLDER"
Write-Host "...Agent.JobStatus: $ENV:AGENT_JOBSTATUS"

Write-Host "System Variable of potential interests:"
Write-Host "...System.TeamProject: $ENV:SYSTEM_TEAMPROJECT"
Write-Host "...System.TeamProjectId: $ENV:SYSTEM_TEAMPROJECTID"

Write-Host "Build Variables of potential interest:"
Write-Host "...BUILD_BUILDID: $ENV:BUILD_BUILDID"
Write-Host "...BUILD_BUILDNUMBER: $ENV:BUILD_BUILDNUMBER"
Write-Host "...BUILD_SOURCEDIRECTORY: $ENV:BUILD_SOURCEDIRECTORY"
Write-Host "...BUILD_STAGINGDIRECTORY: $ENV:BUILD_STAGINGDIRECTORY"
Write-Host "...BUILD_ARTIFACTSTAGINGDIRECTORY: $ENV:BUILD_ARTIFACTSTAGINGDIRECTORY"
Write-Host "...BUILD_BINARIESDIRECTORY: $ENV:BUILD_BINARIESDIRECTORY"
Write-Host "...BUILD_WORKINGDIRECTORY: $ENV:BUILD_WORKINGDIRECTORY"
Write-Host "...BUILD_REASON: $ENV:BUILD_REASON"
Write-Host "...BUILD_REPOSITORY_CLEAN: $ENV:BUILD_REPOSITORY_CLEAN"
Write-Host "...BUILD_SOURCEBRANCH: $ENV:BUILD_SOURCEBRANCH"
Write-Host "...BUILD_SOURCEBRANCH_NAME: $ENV:BUILD_SOURCEBRANCH_NAME"

Write-Host "Injected Task Variables:"
Write-Host "...subscriptionName: $subscriptionName"
Write-Host "...defaultArmLocation: $defaultArmLocation"
Write-Host "...resourceEnvIdentifier: $resourceEnvIdentifier"
Write-Host "...resourceNameTemplate: $resourceNameTemplate"


Write-Host ""

# Create Name of ResourceGroup
Write-Host "Solving Resouce Group Name Template"
Write-Host "...resourceNameTemplate: $resourceNameTemplate"
Write-Host "...Replacing '{ENV}'/'{ENVID}'/'{ENVIDENTIFIER} found within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate= $resourceNameTemplate.Replace("{ENVIDENTIFIER}", $resourceEnvIdentifier).Replace("{ENVID}", $resourceEnvIdentifier).Replace("{ENV}", $resourceEnvIdentifier);
Write-Host "...Replacing '{SOURCEBRANCHNAME}'/'{SOURCEBRANCH}'/'{BRANCHNAME}'/'{BRANCH} found within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate= $resourceNameTemplate `
                            .Replace("{SOURCEBRANCHNAME}", $buildSourceBranchName) `
                            .Replace("{SOURCEBRANCH}", $buildSourceBranchName) `
                            .Replace("{BRANCHNAME}", $buildSourceBranchName) `
                            .Replace("{BRANCH}", $buildSourceBranchName);
# Remove final dashes and duplicates:
$resourceNameTemplate = $resourceNameTemplate.Replace("--", "-")
# $resourceNameTemplate= [Regex]::Replace($resourceNameTemplate.Replace("--", "-"),"(.*)-*$","$1");
Write-Host "...resourceNameTemplate (cleaned up): $resourceNameTemplate"

# Set Subscription
Select-AzureRmSubscription -SubscriptionName "$subscriptionName"

# Create Resource Group
# New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceGroupName-TemplateUri $templateUri



# Set output variables:
Write-host $env:OutputVar
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_RESOURCENAMETEMPLATE;]$resourceNameTemplate")
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_APPINSTANCE;]$appInstanceIdentifier")
Write-host $env:CUSTOM_VARS_RESOURCENAMETEMPLATE
Write-host $env:CUSTOM_VARS_CUSTOM_VARS_APPINSTANCE