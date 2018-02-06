
# Define method before invoking it
function Provision-Variables {
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
        [Parameter(mandatory = $false)] [string]$adDomainName = "foo", 
        [Parameter(mandatory = $false)] [int] $bar = 3     
    )

    
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
  * Every Custom Variable (eg: 'custom_task_vars_Foo') you create in a VSO Build Definition will 
    be pumped into this memory space as $ENV:custom_task_vars_FOO (note how it is an Env var, and the dots
    are replaced with '_')
  * you can also pass arguments to the script when you invoke it.

  ### PREREQUISITE KNOWLEDGE: AZURE AUTHENTICATION/SUBSCRIPTION CONTEXT
  Variables are then used to create or privision Resources within a specific target Azure Subscription. 

  ### PREREQUISITES KNOWLEDGE: ARMS
  You can find ARM Templates to look at here: https://azure.microsoft.com/en-us/resources/templates/?sort=Popular

  ### PREREQUISITES: VARIABLES
  The script is expecting the following Custom Variable Inputs being set in the Build Definition Variables:
  * NO: Legacy: custom_task_vars_subscriptionName
  * custom_task_vars_resourceNameTemplate
  * custom_task_vars_envIdentifier
  // These are for the entry point top ARM Template:
  * custom_task_vars_armTemplatePath
  // These vars are for ARM Linking to work:
  * custom_task_vars_armTemplateRootUri
  * custom_task_vars_armTemplateRootSas
  * custom_task_vars_armTemplateParameterRootUri
  * custom_task_vars_armTemplateParameterRootSas
  * custom_task_vars_deployResourceGroupByPowerShell

  ### RESOURCES
  * https://github.com/Microsoft/vsts-tasks/blob/master/docs/authoring/commands.md


  #>

    ## Overrides

    # Context:

    #BUILD_ARTIFACTSTAGINGDIRECTORY

    # https://docs.microsoft.com/en-gb/vsts/build-release/concepts/definitions/release/variables?tabs=batch#default-variables

    #Write-Host "...System.TeamProject: $(System.TeamProject)"
    #Write-Host "...System.TeamProjectId: $(System.TeamProjectId)"


    # Cleanup Variacustom_task_vars_armTemplateRootUribles, Parameters and make local parameters:
    # Legacy: $subscriptionName = $ENV:custom_task_vars_SUBSCRIPTIONNAME;
    # Legacy: if ($subscriptionName -eq $null){$subscriptionName = "";}
    $buildSourceBranchName = $ENV:BUILD_SOURCEBRANCH_NAME;
    if ([string]::IsNullOrEmpty($buildSourceBranchName)) {$buildSourceBranchName = ""; }
    if ($buildSourceBranchName -eq "master") {$buildSourceBranchName = ""; }
    # EnvIdentifier is going to be something like BT, DT, ST, UAT, PROD, etc.
    $envIdentifier = $env:custom_task_vars_envIdentifier;
    if ([string]::IsNullOrEmpty($envIdentifier)) {$envIdentifier = ""; }

    $defaultResourceLocation = $env:custom_task_vars_defaultResourceLocation;
    if ([string]::IsNullOrEmpty($defaultResourceLocation)) {$defaultResourceLocation = "Australia East"; }

    # as for the ARM Templates:
    # the Root template as to where to find ARM files should be set to an HTTPS location.
    # in the most trivial of ARM templates (with no child templates) the local Src dir could
    # work in a pinch (low chance of that working...)
    Write-Host "env:custom_task_vars_armTemplateRootUri: $env:custom_task_vars_armTemplateRootUri"
    $armTemplateRootUri = $env:custom_task_vars_armTemplateRootUri;
    if ($armTemplateRootUri.StartsWith("http") -eq $false) {
        $armTemplateRootUri = ""; 
        Write-Host "env:custom_task_vars_armTemplateRootUri did not start with http...stripping out."
    }
    Write-Host "env:custom_task_vars_armTemplateRootUri: $env:custom_task_vars_armTemplateRootUri"
    # DUMB, since most of the time it should be coming from a public url:
    # if ([string]::IsNullOrWhiteSpace($armTemplateRootUri)) {$armTemplateRootUri = $ENV:BUILD_SOURCEDIRECTORY; }
    $armTemplateRootSas = $env:custom_task_vars_armTemplateRootSas;
    if ([string]::IsNullOrWhiteSpace($armTemplateRootSas)) {$armTemplateRootSas = ""; }
    # whereas templates can be from public, well-known urls, 
    # its normally that params are from the same source. but can be different (private)
    $armTemplateParameterRootUri = $env:custom_task_vars_armTemplateParameterRootUri;
    if ($armTemplateParameterRootUri.StartsWith("http") -eq $false) {
        $armTemplateParameterRootUri = ""; 
        Write-Host "env:custom_task_vars_armTemplateParameterRootUri did not start with http...stripping out."
    }
    if ([string]::IsNullOrWhiteSpace($armTemplateParameterRootUri)) {$armTemplateParameterRootUri = $armTemplateRootUri; }
    # Root SAS:
    $armTemplateParameterRootSas = $env:custom_task_vars_armTemplateParameterRootSas;
    if ([string]::IsNullOrWhiteSpace($armTemplateParameterRootSas)) {$armTemplateParameterRootSas = $armTemplateRootSas; }
    # the path to the entry point ARM could be just a filename, in which case, prepend with the root Uri:
    $armTemplatePath = $env:custom_task_vars_armTemplatePath;
    if ([string]::IsNullOrWhiteSpace($armTemplatePath)) {$armTemplatePath = ""; }
    if ([System.IO.Path]::IsPathRooted($armTemplatePath) -eq $false) {
        Write-Host "env:custom_task_vars_armTemplatePath is not rooted. Prepending with $armTemplateRootUri."
        $armTemplatePath = [System.IO.Path]::Combine($armTemplateRootUri, $armTemplatePath)
    }


    # the path to the entry point ARM parameters could be just a filename, in which case, prepend with the root Uri:
    $armTemplateParameterPath = $env:custom_task_vars_armTemplateParameterPath;
    if ([string]::IsNullOrWhiteSpace($armTemplateParameterPath)) {$armTemplateParameterPath = ""; }
    if ([System.IO.Path]::IsPathRooted($armTemplateParameterPath) -eq $false) {
        Write-Host "env:custom_task_vars_armTemplateParameterPath is not rooted. Prepending with $armTemplateParameterRootUri."
        $armTemplateParameterPath = [System.IO.Path]::Combine($armTemplateParameterRootUri, $armTemplateParameterPath)
    }
    # resourceNameTemplate is going to be something like MYORG-MYAPP-{ENVID}-{BRANCHNAME}-{RESOURCETYPE}
    $resourceNameTemplate = $env:custom_task_vars_resourceNameTemplate;
    if ([string]::IsNullOrWhiteSpace($resourceNameTemplate)) {$resourceNameTemplate = ""; }


    # finally. Should we be deploying by code, or not?
    $deployResourceGroupByPowerShell = $false;
    [bool]::TryParse($env:custom_task_vars_deployResourceGroupByPowerShell, [ref]$deployResourceGroupByPowerShell);

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
    Write-Host "...defaultResourceLocation: $defaultResourceLocation"
    Write-Host "...armTemplatePath: $armTemplatePath"
    Write-Host "...armTemplateParameterPath: $armTemplateParameterPath"
    Write-Host "...armTemplateRootUri: $armTemplateRootUri"
    Write-Host "...armTemplateRootSas: $armTemplateRootSas"
    Write-Host "...armTemplateParameterRootUri: $armTemplateParameterRootUri"
    Write-Host "...armTemplateParameterRootSas: $armTemplateParameterRootSas"


    Write-Host ""

    # Create Name of ResourceGroup
    Write-Host "Solving Resource Group Name Template"
    Write-Host "...resourceNameTemplate: $resourceNameTemplate"
    Write-Host "...Replacing {ENV[ID][ENTIFIER]} within 'env:custom_task_vars_RESOURCENAMETEMPLATE':"
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{ENVIDENTIFIER}", $envIdentifier `
        -replace "{ENVID}", $envIdentifier `
        -replace "{ENV}", $envIdentifier

    Write-Host "...Replacing '{[SOURCE]BRANCH[NAME|ID[DENTIFIER]]}' within 'env:custom_task_vars_RESOURCENAMETEMPLATE':"
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{SOURCEBRANCHIDENTIFIER}", $buildSourceBranchName `
        -replace "{SOURCEBRANCHID}", $buildSourceBranchName `
        -replace "{BRANCHIDENTIFIER}", $buildSourceBranchName `
        -replace "{BRANCHID}", $buildSourceBranchName `
        -replace "{SOURCEBRANCHID}", $buildSourceBranchName `
        -replace "{SOURCEBRANCHNAME}", $buildSourceBranchName `
        -replace "{SOURCEBRANCH}", $buildSourceBranchName `
        -replace "{BRANCHNAME}", $buildSourceBranchName `
        -replace "{BRANCH}", $buildSourceBranchName
    # Remove final dashes and duplicates:
    $resourceNameTemplate = $resourceNameTemplate -replace "--", "-"
    # $resourceNameTemplate= [Regex]::Replace($resourceNameTemplate.Replace("--", "-"),"(.*)-*$","$1");
    Write-Host "...resourceNameTemplate (cleaned up): $resourceNameTemplate"




    # After saving the variables in the globally available Variables, 
    # you have the option of deploying ResourceGroups (and ARM templates)
    # by Code (I like that approach as it makes it one more thing that is version controlled, but 
    # Azure based Powershell scripts are so much slower)
    # or leave it to a subsequent Build/Release Task to sort out, based on drag/drop approach. 


    Write-Host "custom_task_vars_deployResourceGroupByPowerShell: $deployResourceGroupByPowerShell"
    if ($deployResourceGroupByPowerShell) {

  
        # Set Subscription
        # Legacy: No need to, as we are in the Azure PostScript Task which has already 
        # connected to the Service Principal, and Subscription:
        # Select-AzureRmSubscription -SubscriptionName "$subscriptionName" 


        # Create/Ensure Resource Group
        Write-Host "...Ensuring ResourceGroup Exists..."
        $resourceName = $resourceNameTemplate -replace "{RESOURCETYPE}", "RG" 
        Write-Host "...Ensure ResourceGroup -Name $resourceName -Location $defaultResourceLocation -Force"
        New-AzureRmResourceGroup -Name $resourceName -Location $defaultResourceLocation -Tag @{PROJ = "EDU/MOE/CORE"} -Force






        # Deploy to Existing Resource Group.
        # The theory here is 
        # import the ARM, with its default values
        # and the ARM Params, which might be incomplete
        # and pass some params 'on the fly'
        # so that the fly fill in any gaps in the params (but params get precedence) 
        Write-Host "...Deploying Resource Group Template..."
        if (($armTemplatePath.StartsWith('http:')) -or ($armTemplatePath.StartsWith('https:')) ) {
            Write-Host "...via Web path..."
            Write-Host "...New-AzureRmResourceGroupDeployment `
        -ResourceGroupName $resourceName `
        -TemplateUri $armTemplatePath `
        -TemplateParameterUri $armTemplateParameterPath `
    `
        -armTemplateRootUri $armTemplateRootUri `
        -armTemplateRootSas $armTemplateRootSas `
        -armTemplateParameterRootUri $armTemplateParameterRootUri `
        -armTemplateParameterRootSas $armTemplateParameterRootSas `
        -resourceNameTemplate $resourceNameTemplate"

            New-AzureRmResourceGroupDeployment `
                -ResourceGroupName $resourceName `
                -TemplateUri $armTemplatePath `
                -TemplateParameterUri $armTemplateParameterPath `
        `
                -armTemplateRootUri $armTemplateRootUri `
                -armTemplateRootSas $armTemplateRootSas `
                -armTemplateParameterRootUri $armTemplateParameterRootUri `
                -armTemplateParameterRootSas $armTemplateParameterRootSas `
                -resourceNameTemplate $resourceNameTemplate

        }
        else {
            Write-Host "...via File path..."
            Write-Host "...New-AzureRmResourceGroupDeployment `
        -ResourceGroupName $resourceName `
        -TemplateFile $armTemplatePath  `
        -TemplateParameterFile $armTemplateParameterPath `
    `
        -armTemplateRootUri $armTemplateRootUri `
        -armTemplateRootSas $armTemplateRootSas `
        -armTemplateParameterRootUri $armTemplateParameterRootUri `
        -armTemplateParameterRootSas $armTemplateParameterRootSas `
        -resourceNameTemplate $resourceNameTemplate"
        

            New-AzureRmResourceGroupDeployment `
                -ResourceGroupName $resourceName `
                -TemplateFile $armTemplatePath  `
                -TemplateParameterFile $armTemplateParameterPath `
        `
                -armTemplateRootUri $armTemplateRootUri `
                -armTemplateRootSas $armTemplateRootSas `
                -armTemplateParameterRootUri $armTemplateParameterRootUri `
                -armTemplateParameterRootSas $armTemplateParameterRootSas `
                -resourceNameTemplate $resourceNameTemplate

        }
        Write-Host "...Resources Deployment complete."
    }

    # Know that Setting Variables does not update the Global till the end of this 
    # task, before the next (that's why I didn't put them above the invocation of the ARM templates - as
    # they won't yet be available... (ie, different behaviour than when you use the Drop/Drop deploy ARM Template task, which can refer 
    # to them, as they are in a different Task)
    # TIP: You have to name the vars as they were registered ('with dots, not dashes)
    Write-Host "Updating Global Env Variables for next tasks..."
    Write-Host "##vso[task.setvariable variable=custom_task_vars_envIdentifier;]$envIdentifier"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_resourceNameTemplate;]$resourceNameTemplate"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_defaultResourceLocation;]$defaultResourceLocation"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplatePath;]$armTemplatePath"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplateParameterPath;]$armTemplateParameterPath"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplateRootUri;]$armTemplateRootUri"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplateRootSas;]$armTemplateRootSas"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplateParameterRootUri;]$armTemplateParameterRootUri"
    Write-Host "##vso[task.setvariable variable=custom_task_vars_armTemplateParameterRootSas;]$armTemplateParameterRootSas"



    Write-Host "Task Complete."
  
}

# Invoke Method
Provision-Variables
