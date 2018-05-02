
[cmdletbinding]
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
        [Parameter(mandatory = $false)] [string]$defaultMasterBranchNameReplacement = "000000",
        [Parameter(mandatory = $false)] [string]$defaultResourceLocationIdentifier = "australiaeast"
    )

    $countLength =  [math]::max($defaultMasterBranchNameReplacement.Length,5)
    
    
    <#
  # README
  This script 

  ## BACKGROUND
  Visual Studio Online (VSO)'s easy, Drag/Drop system to build a Build Definitions has the advantage
  of being easy to drag/drop and put together basic recipes, with a GUI to help determine the
  input parameters -- but it's also at the cost of keeping the recipe version controlled along
  with the deliverable code (don't forget the deliverable is the pipeline that delivers product, 
  not the product itself).
  Since we're developers...writting code is what we do. Including Build Pipelines. 

  The script is heavily annotated to make it more accessible to team members of varying Powershell ability.

  ### PREREQUISITES: VARIABLES
  The script is expecting the following Custom Variable Inputs being set in the Build Definition Variables:
  # OPTIONAL: CUSTOM_COMMON_VARS_ORGIDENTIFIER (eg: 'NZ-MOE')
  # OPTIONAL: CUSTOM_COMMON_VARS_APPIDENTIFIER (eg: 'FOO')
  # OPTIONAL: CUSTOM_VARS_MASTERBRANCHNAMEREPLACEMENT (eg: '0000')
  # OPTIONAL: CUSTOM_VARS_DEFAULTRESOURCELOCATION (eg: 'australiaeast')
  # OPTIONAL: CUSTOM_VARS_ENVIDENTIFIER (eg: BT, DT, ST, UAT, PROD, etc.)
  # REQUIRED: CUSTOM_VARS_RESOURCENAMETEMPLATE (eg: 'MYORG-MYAPP-{BRANCHNAME}-{ENVID}-{RT}')


  ### PREREQUISITE KNOWLEDGE: POWERSHELL
  * Powershell is powerful while remaining easy. That said, a quick primer never hurt:
  * http://skysigal.com/it/ad/powershell/howto/syntax_basics/home 

  ### PREREQUISITE KNOWLEDGE: HOW TO GET CONTEXT INFO WITHIN YOUR SCRIPTS.
  Essentially, by the time this script is invoked, VSO will have pumped into a ton of variables.
  * More info: https://docs.microsoft.com/en-us/vsts/build-release/concepts/definitions/build/variables?tabs=batch#predefined-variables
  * There is an Agent object
  * There is also a Server object
  * There is also a Build object
  * Every Custom Variable (eg: 'CUSTOM_VARS_Foo') you create in a VSO Build Definition will 
    be pumped into this memory space as $ENV:CUSTOM_VARS_FOO (note how it is an Env var, and the dots
    are replaced with '_')
  * you can also pass arguments to the script when you invoke it.

  ### PREREQUISITE KNOWLEDGE: AZURE AUTHENTICATION/SUBSCRIPTION CONTEXT
  Variables are then used to create or privision Resources within a specific target Azure Subscription. 

  ### PREREQUISITES KNOWLEDGE: ARMS
  You can find ARM Templates to look at here: https://azure.microsoft.com/en-us/resources/templates/?sort=Popular


  ### RESOURCES
  * https://github.com/Microsoft/vsts-tasks/blob/master/docs/authoring/commands.md
  * https://docs.microsoft.com/en-gb/vsts/build-release/concepts/definitions/release/variables?tabs=batch#default-variables
  #>


    # Cleanup Variables, Parameters and make local parameters:

    # Get the resourceNameTemplate (eg: 'MYORG-MYAPP-{BRANCHNAME}-{ENVID}-{RT}' )
    $resourceNameTemplate = $env:CUSTOM_COMMON_VARS_RESOURCENAMETEMPLATE;
    if ([string]::IsNullOrWhiteSpace($resourceNameTemplate)) {$resourceNameTemplate = $ENV:CUSTOM_VARS_RESOURCENAMETEMPLATE; }
    if ([string]::IsNullOrWhiteSpace($resourceNameTemplate)) {$resourceNameTemplate = ""; }


    # Get the Org ID|ENTIFIER FROM COMMON OR LOCAL VARS (eg: 'NZ-MOE')
    $orgIdentifier = $ENV:CUSTOM_COMMON_VARS_ORGANISATIONIDENTIFIER
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_COMMON_VARS_ORGIDENTIFIER; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_VARS_ORGANISATIONIDENTIFIER; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_VARS_ORGIDENTIFIER; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_COMMON_VARS_ORGANISATIONID; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_COMMON_VARS_ORGID; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_VARS_ORGANISATIONID; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = $ENV:CUSTOM_VARS_ORGI; }
    if ([string]::IsNullOrEmpty($orgIdentifier)) {$orgIdentifier = ""; }

    # Get the App Id (eg: 'MYAPP')
    $appIdentifier = $ENV:CUSTOM_COMMON_VARS_APPIDENTIFIER
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_COMMON_VARS_SYSTEMIDENTIFIER; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_VARS_APPIDENTIFIER; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_VARS_SYSTEMIDENTIFIER; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_COMMON_VARS_APPID; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_COMMON_VARS_SYSTEMID; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_VARS_APPID; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:CUSTOM_VARS_SYSTEMID; }
    # finally, if no App Id, fall back to the Project Name...
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = $ENV:SYSTEM_TEAMPROJECT; }
    if ([string]::IsNullOrEmpty($appIdentifier)) {$appIdentifier = ""; }



    # the git branch name should be a Userstory:
    $buildSourceBranchName = $ENV:BUILD_SOURCEBRANCHNAME;
    if ([string]::IsNullOrEmpty($buildSourceBranchName)) {$buildSourceBranchName = ""; }
    Write-Host "Branch:$buildSourceBranchName"

    # now replace brnach name if need be. ie replace 'master' with '', '0000' ... or even 'master'.
    if ($buildSourceBranchName -eq "master") {
        Write-Host "Is Master Branch."
        $masterBranchNameReplacement = $ENV:CUSTOM_COMMON_VARS_MASTERBRANCHNAMEREPLACEMENT
        if ([string]::IsNullOrEmpty($masterBranchNameReplacement)) {$masterBranchNameReplacement = $ENV:CUSTOM_VARS_MASTERBRANCHNAMEREPLACEMENT; }
        if ([string]::IsNullOrEmpty($masterBranchNameReplacement)) {$masterBranchNameReplacement = $defaultMasterBranchNameReplacement; }
        $defaultMasterBranchNameReplacement = $defaultMasterBranchNameReplacement.PadLeft($countLength, "0");
        $buildSourceBranchName = $masterBranchNameReplacement; 
    }
    else {
        Write-Host "Is Not Master Branch"
        $userStoryFilter = "(/(us|id)(\d+))"
        $userStoryId = [regex]::match($buildSourceBranchName, $userStoryFilter).Groups[3].Value
        if ([string]::IsNullOrEmpty($userStoryId)) {$userStoryId = ""; }
        $userStoryId = $userStoryId.PadLeft($countLength, "0")
    }

    # Get the ENV ID|DENTIFIER From the local vars. (Eg: BT, DT, ST, UAT, PROD, etc.)
    $envIdentifier = $env:CUSTOM_VARS_ENVIDENTIFIER;
    if ([string]::IsNullOrEmpty($envIdentifier)) {$envIdentifier = $env:CUSTOM_VARS_ENVID; }
    if ([string]::IsNullOrEmpty($envIdentifier)) {$envIdentifier = ""; }

    # default location should be 'australiaeast':
    $defaultResourceLocation = $env:CUSTOM_COMMON_VARS_DEFAULTRESOURCELOCATION;
    if ([string]::IsNullOrEmpty($defaultResourceLocation)) {$defaultResourceLocation = $env:CUSTOM_VARS_DEFAULTRESOURCELOCATION; }
    if ([string]::IsNullOrEmpty($defaultResourceLocation)) {$defaultResourceLocation = $defaultResourceLocationIdentifier; }

    

    # Output System, Build's default and injected Variables:
    Write-Host "Script variables of potential interest:"
    Write-Host "...PSScriptRoot: $PSScriptRoot"

    Write-Host "Agent Variable of potential interests at some point:"
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

    Write-Host ""

    # Output System, Build's default and injected Variables:
    Write-Host "PREREQUISITES: VSTS TASK ENVIRONMENT VARIABLES: "
    Write-Host "* REQUIRED: CUSTOM_VARS_RESOURCENAMETEMPLATE (eg: 'MYORG-MYAPP-{BRANCHNAME}-{ENVID}-{RT}')"
    Write-Host "* OPTIONAL: CUSTOM_COMMON_VARS_ORGIDENTIFIER (eg: 'NZ-MOE')"
    Write-Host "* OPTIONAL: CUSTOM_COMMON_VARS_APPIDENTIFIER (eg: 'FOO')"
    Write-Host "* OPTIONAL: CUSTOM_VARS_MASTERBRANCHNAMEREPLACEMENT (eg: '0000')"
    Write-Host "* OPTIONAL: CUSTOM_VARS_DEFAULTRESOURCELOCATION (eg: 'australiaeast')"
    Write-Host "* OPTIONAL: CUSTOM_VARS_ENVIDENTIFIER (eg: BT, DT, ST, UAT, PROD, etc.)"
      
    Write-Host ""
    
    # Create Name of ResourceGroup
    Write-Host "Solving Resource Group Name Template"
    Write-Host "...resourceNameTemplate (as received): $resourceNameTemplate"

    Write-Host "...Replacing {ORG[ID][ENTIFIER]}  with '$($orgIdentifier)':"
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{ORGANISATIONIDENTIFIER}", $orgIdentifier `
        -replace "{ORGIDENTIFIER}", $orgIdentifier `
        -replace "{ORGID}", $orgIdentifier `
        -replace "{ORG}", $orgIdentifier

    Write-Host "...Replacing {APP[LICATION][ID][ENTIFIER]} with '$($appIdentifier)':"
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{APPLICATIONIDENTIFIER}", $appIdentifier `
        -replace "{APPIDENTIFIER}", $appIdentifier `
        -replace "{APPID}", $appIdentifier `
        -replace "{APP}", $appIdentifier
    
    Write-Host "...Replacing {ENV[ID][ENTIFIER]} with '$($ebvIdentifier)':"
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{ENVIDENTIFIER}", $envIdentifier `
        -replace "{ENVID}", $envIdentifier `
        -replace "{ENV}", $envIdentifier

    Write-Host "...Replacing '{[SOURCE]BRANCH[NAME|ID[DENTIFIER]]}' with '$($buildSourceBranchName)':"
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

    # Use shorthand:
    # And remove final dashes and duplicates:
    $resourceNameTemplate = $resourceNameTemplate `
        -replace "{RESOURCETYPE}", "{RT}" `
        -replace "--", "-"
    
    # $resourceNameTemplate= [Regex]::Replace($resourceNameTemplate.Replace("--", "-"),"(.*)-*$","$1");
    Write-Host "...resourceNameTemplate (cleaned up): $resourceNameTemplate"


    # Make the Resource GroupName:
    $resourceGroupName = ($resourceNameTemplate `
            -replace "{RT}", "" `
            -replace "--", "-").TrimEnd("-")
        

    

    Write-Host "...ResourceGroupName set to $resourceGroupName"

    # Now that ResourceGroup name is created, safe to lowercase the resourcenametemplate:
    $resourceNameTemplate = ($resourceNameTemplate -replace "-", "").ToLower()
    # HACK / FIX: Have to get the token back to the right case.
    $resourceNameTemplate = $resourceNameTemplate -replace "{rt}", "{RT}"

    

    # Saving the updated variables in the globally ENV space, 
    # TIP:
    # Know that Setting Variables does not update the Global till the end of this Task, before the next Task.
    # ie, they consider them as Task Outputs.
    Write-Host "Updating Global Env Variables for next tasks..."
    # TIP: You have to name the vars as they were registered in vsts (with dots, not dashes)
    Write-Host "##vso[task.setvariable variable=CUSTOM_VARS_ENVIDENTIFIER;]$envIdentifier"
    Write-Host "##vso[task.setvariable variable=CUSTOM_VARS_RESOURCEGROUPNAME;]$resourceGroupName"
    Write-Host "##vso[task.setvariable variable=CUSTOM_VARS_RESOURCENAMETEMPLATE;]$resourceNameTemplate"
    Write-Host "##vso[task.setvariable variable=CUSTOM_VARS_DEFAULTRESOURCELOCATION;]$defaultResourceLocation"

    Write-Host "Task Complete."  
}

# --------------------------------------------------
# --------------------------------------------------
# Invoke Method
Provision-Variables -defaultMasterBranchNameReplacement:"000000" -defaultResourceLocationIdentifier "australiaeast"
# --------------------------------------------------
# --------------------------------------------------
