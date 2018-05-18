[cmdletbinding]
function Prepare-Project {
    [CmdletBinding()]
    Param (
        [string]$relativePathToProject=".\" ,
        [string]$systemName = "DV_SYSTEM_NAME",
        [string]$moduleName = "DV_MODULE_NAME",
        [string]$copyrightText = "DV_MODULE_COPYRIGHTTEXT"
    )

    $relativePathToProject = (Get-Item -Path $relativePathToProject).FullName

    Write-Host "=================================================="
    Write-Host "Project Provisioner"
    Write-Host "=================================================="
    Write-Host "Current Folder: $relativePathToProject"
    Write-Host "--------------------------------------------------"

    $files = Get-ChildItem -Path:"$relativePathToProject" -Include:"$($moduleName)*.csproj" -Recurse
    
    $tmpCount = $files.Count

    Write-Host "'$($moduleName)*.csproj' files found: " $tmpCount
    if ($tmpCount -eq 0){
        Write-Host -ForegroundColor:Red "Folder did not find any '$($moduleName)*.csproj' files in folder. Aborting as a precaution."
        return
    }

    Write-Host "--------------------------------------------------"
    $systemNameReplacement = Read-Host -Prompt "Input your SYSTEM Name ('$($systemName)'):"

    if ($systemNameReplacement -eq "."){
        Write-Host "Cancelling."
        return
    }
    if ($systemNameReplacement -eq $null) {$systemNameReplacement = ""}
    if (($systemNameReplacement.StartsWith('.')) -or ($systemNameReplacement.EndsWith('.'))) {
        Write-Host -ForegroundColor:Red "As a precaution, System Name cannot end with '.'. Cancelling."
        return
    }
    if ([string]:: IsNullOrWhiteSpace($systemNameReplacement)){
        $systemNameReplacement = $systemName
        Write-Host "No change."
    }

    Write-Host "--------------------------------------------------"
    $moduleNameReplacement = Read-Host -Prompt "Input your MODULE Name ('$($moduleName)'):"
    if ($moduleNameReplacement -eq "."){
        Write-Host "Cancelling."
        return
    }
    if ($moduleNameReplacement -eq $null) {$moduleNameReplacement = ""}
    if (($moduleNameReplacement.StartsWith('.')) -or ($moduleNameReplacement.EndsWith('.'))) {
        Write-Host -ForegroundColor:Red "As a precaution, Module Name cannot end with '.'. Cancelling."
        return
    }
    if ([string]::IsNullOrWhiteSpace($moduleNameReplacement)){
        $moduleNameReplacement = $moduleName
        Write-Host -ForegroundColor:Gray "No change."    
    }
    Write-Host "--------------------------------------------------"
    #Start-Transcript -Path "$($relativePathToProject)\actionsTaken.log" -NoClobber -Append
    Write-Host "Replacing Text within Files..."
    if ($systemNameReplacement -ne $systemName){
        Replace-FileText -folderPath:$relativePathToProject -pattern:$systemName -replace:$systemNameReplacement
    }
    
    if ($moduleNameReplacement -ne $moduleName){
        Replace-FileText -folderPath:$relativePathToProject -pattern:$moduleName  -replace:$moduleNameReplacement    
    }
    #Stop-Transcript
    Write-Host "--------------------------------------------------"

    #Start-Transcript -Path "$($relativePathToProject)\actionsTaken.log" -NoClobber -Append
    Write-Host "Renaming Files..."
    $files | Rename-Item -NewName {$_.name -replace $moduleName,$moduleNameReplacement } -Force
    #Stop-Transcript
    Write-Host "--------------------------------------------------"

    Write-Host -ForegroundColor:Green "Done."    


}

function Replace-FileText($folderPath, $pattern, $replace){

    $exclude = @("*.orig")
    $files = Get-ChildItem -Path $folderPath -Recurse -exclude $exclude 

    foreach ($file in $files){
        Write-Host "............"
        Write-Host "Processing $($file.Name), replacing '$pattern' with '$replace'..."
        $content = Get-Content $($file.FullName) -Raw
        #write replaced content back to the file
        $content -replace $pattern , $replace  | Out-File $($file.FullName) 

        Write-Host "............"
    }

}

Prepare-Project






