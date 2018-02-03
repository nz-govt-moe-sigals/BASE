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
  The script is expecting the following Custom Variable Inputs being set in the Build Definition Variables:
  * NO: Legacy: custom.vars.subscriptionName
  * custom.vars.resourceNameTemplate
  * custom.vars.envIdentifier
  * custom.vars.armTemplateRoot
#>


# Context:

#BUILD_ARTIFACTSTAGINGDIRECTORY

# https://docs.microsoft.com/en-gb/vsts/build-release/concepts/definitions/release/variables?tabs=batch#default-variables

#Write-Host "...System.TeamProject: $(System.TeamProject)"
#Write-Host "...System.TeamProjectId: $(System.TeamProjectId)"


# Cleanup Variables, Parameters and make local parameters:
# Legacy: $subscriptionName = $ENV:CUSTOM_VARS_SUBSCRIPTIONNAME;
# Legacy: if ($subscriptionName -eq $null){$subscriptionName = "";}
$buildSourceBranchName = $ENV:BUILD_SOURCEBRANCH_NAME;
if ($buildSourceBranchName -eq $null){$buildSourceBranchName = "";}
if ($buildSourceBranchName -eq "master"){$buildSourceBranchName = "";}
# EnvIdentifier is going to be something like BT, DT, ST, UAT, PROD, etc.
$envIdentifier = $env:custom_vars_envIdentifier;
if ($envIdentifier -eq $null){$envIdentifier = "";}
# resourceNameTemplate is going to be something like MYORG-MYAPP-{ENVID}-{BRANCHNAME}-{RESOURCETYPE}
$resourceNameTemplate = $env:CUSTOM_VARS_RESOURCENAMETEMPLATE;
if ($resourceNameTemplate -eq $null){$resourceNameTemplate = "";}
$defaultResourceLocation = $env:custom_vars_DEFAULTRESOURCELOCATION;
if ($defaultResourceLocation -eq $null){$defaultResourceLocation = "Australia East";}
# as for the ARM Templates:
$armTemplateRoot = $env:custom_vars_armTemplateRoot;
if ($armTemplateRoot -eq $null){$armTemplateRoot = "";}
if ($armTemplateRoot -eq ""){$armTemplateRoot = $ENV:BUILD_SOURCEDIRECTORY}
$armTemplatePath = $env:custom_vars_armTemplatePath;
if ($armTemplatePath -eq $null){$armTemplatePath = "";}
if ([System.IO.Path]::IsPathRooted($armTemplatePath) -eq $false){
  $armTemplatePath = [System.IO.Path]::Combine($armTemplateRoot, $armTemplatePath)
}
$armTemplateParameterPath = $env:custom_vars_armTemplateParameterPath;
if ($armTemplateParameterPath -eq $null){$armTemplateParameterPath = "";}
if ([System.IO.Path]::IsPathRooted($armTemplateParameterPath) -eq $false){
  $armTemplateParameterPath = [System.IO.Path]::Combine($armTemplateRoot, $armTemplateParameterPath)
}




# Output System, Build's default and injected Variables:
Write-Host "Script variables of potential interest:"
Write-Host "...PSScriptRoot: $PSScriptRoot"

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
Write-Host "...BUILD_SOURCEBRANCHNAME: $ENV:BUILD_SOURCEBRANCHNAME"

Write-Host "Injected Task Variables:"
# Legacy: Write-Host "...subscriptionName: $subscriptionName"
Write-Host "...envIdentifier: $envIdentifier"
Write-Host "...resourceNameTemplate: $resourceNameTemplate"
Write-Host "...armTemplateRoot: $armTemplateRoot"
Write-Host "...armTemplatePath: $armTemplatePath"
Write-Host "...armTemplateParameterPath: $armTemplateParameterPath"


Write-Host ""

# Create Name of ResourceGroup
Write-Host "Solving Resource Group Name Template"
Write-Host "...resourceNameTemplate: $resourceNameTemplate"
Write-Host "...Replacing {ENV[ID][ENTIFIER]} within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate = $resourceNameTemplate `
                        -replace "{ENVIDENTIFIER}", $envIdentifier `
                        -replace "{ENVID}", $envIdentifier `
                        -replace "{ENV}", $envIdentifier

Write-Host "...Replacing '{[SOURCE]BRANCH[NAME]}' within 'env:CUSTOM_VARS_RESOURCENAMETEMPLATE':"
$resourceNameTemplate = $resourceNameTemplate `
                        -replace "{SOURCEBRANCHNAME}", $buildSourceBranchName `
                        -replace "{SOURCEBRANCH}", $buildSourceBranchName `
                        -replace "{BRANCHNAME}", $buildSourceBranchName `
                        -replace "{BRANCH}", $buildSourceBranchName
# Remove final dashes and duplicates:
$resourceNameTemplate = $resourceNameTemplate -replace "--", "-"
# $resourceNameTemplate= [Regex]::Replace($resourceNameTemplate.Replace("--", "-"),"(.*)-*$","$1");
Write-Host "...resourceNameTemplate (cleaned up): $resourceNameTemplate"

# Set Subscription
# Legacy: No need to, as we are in the Azure PostScript Task which has already 
# connected to the Service Principal, and Subscription:
# Select-AzureRmSubscription -SubscriptionName "$subscriptionName" 

                        
# Create/Ensure Resource Group
$resourceName  = $resourceNameTemplate `
                        -replace "{RESOURCETYPE}", "RG" `
                        -replace "{TYPE}", "RG"
Write-Host "...Ensure ResourceGroup -Name $resourceName -Location $defaultResourceLocation -Force"
New-AzureRmResourceGroup -Name $resourceName -Location $defaultResourceLocation -Tag @{PROJ="EDU/MOE/CORE"} -Force


# Deploy to Existing Resource Group
if (($armTemplatePath.StartsWith('http:')) -or ($armTemplatePath.StartsWith('https:')) ){
  New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceName -TemplateUri $armTemplatePath  -TemplateParameterUri $armTemplateParameterPath -resourceNameTemplate $resourceNameTemplate  -armTemplateRoot $armTemplateRoot
}else{
  New-AzureRmResourceGroupDeployment -ResourceGroupName $resourceName -TemplateFile $armTemplatePath  -TemplateParameterFile $armTemplateParameterPath -resourceNameTemplate $resourceNameTemplate  -armTemplateRoot $armTemplateRoot
}





# Set output variables:
Write-host $env:OutputVar
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_RESOURCENAMETEMPLATE;]$resourceNameTemplate")
Write-Output ("##vso[task.setvariable variable=CUSTOM_VARS_APPINSTANCE;]$appInstanceIdentifier")
Write-host $env:CUSTOM_VARS_RESOURCENAMETEMPLATE
Write-host $env:CUSTOM_VARS_CUSTOM_VARS_APPINSTANCE

