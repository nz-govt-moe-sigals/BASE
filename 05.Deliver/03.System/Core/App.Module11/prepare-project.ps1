[cmdletbinding]
function Prepare-Project {
    [CmdletBinding()]
    Param (
        [string]$relativePathToProject = ".\" ,
        [string]$moduleName = "App.Module11"
    )

    $relativePathToProject = (Get-Item -Path $relativePathToProject).FullName

    Write-Host "=================================================="
    Write-Host "Project Provisioner"
    Write-Host "Provisions a folder of *.csproj"
    Write-Host "=================================================="
    Write-Host "Current Folder: $relativePathToProject"
    Write-Host "--------------------------------------------------"
    # If no projects, do not do work...
    $exclude = @("*.dll")
    $files = Get-ChildItem -Path:"$relativePathToProject" -Filter:"$($moduleName)*.csproj" -exclude:$exclude -File -Recurse
    $tmpCount = $files.Count
    if ($tmpCount -eq 0) {
        Write-Host -ForegroundColor:Red "WARNING: Folder did not find any '$($moduleName)*.csproj' files in folder. Type '.' or 'Quit' to Quit."
    }else{
        Write-Host -ForegroundColor:Green  "'$($moduleName)*.csproj' files found: " $tmpCount
    }
    Write-Host "--------------------------------------------------"
    # how many files to look through:
    $exclude = @("bin","*.dll")
    $files = Get-ChildItem -Path:"$relativePathToProject" -exclude:$exclude -Recurse -File
    $tmpCount = $files.Count
    Write-Host -ForegroundColor:Green "Files found: $tmpCount."
    Write-Host "--------------------------------------------------"
    # Ask for replacement Text.
    $moduleNameReplacement = Read-Host -Prompt "Input your MODULE Name ('$($moduleName)'):"

    if ($moduleNameReplacement -eq ".") {
        Write-Host "Cancelling."
        return
    }
    if ($moduleNameReplacement.ToLower() -eq "quit") {
        Write-Host "Cancelling."
        return
    }
    if ($moduleNameReplacement -eq $null) {$moduleNameReplacement = ""}
    if ([string]:: IsNullOrWhiteSpace($moduleNameReplacement)) {
        $moduleNameReplacement = $moduleName
        Write-Host "No change."
    }else{
        if (($moduleNameReplacement.StartsWith('.')) -or ($moduleNameReplacement.EndsWith('.'))) {
            Write-Host -ForegroundColor:Red "As a precaution, Module Name cannot end with '.'. Cancelling."
            return
        }
    }

    Write-Host "--------------------------------------------------"
    if ($moduleNameReplacement -ne $moduleName) {

        Write-Host "Replacing '$($moduleName)' with '$($moduleNameReplacement)' within Files..."
        Replace-FileText -files:$files -pattern:$moduleName  -replace:$moduleNameReplacement    
        Write-Host "Done."

        $classNamePrefix = $moduleName.Replace('.','')
        $classNamePrefixReplacement = $moduleNameReplacement.Replace('.','')

        Write-Host "--------------------------------------------------"
        Write-Host "Replacing '$($classNamePrefix)' with '$($classNamePrefixReplacement)' within Files..."
        Replace-FileText -files:$files -pattern:$classNamePrefix  -replace:$classNamePrefixReplacement    
        Write-Host "Done."

        
    }
    else {
        Write-Host -ForegroundColor:Gray "No change (Module Name is the same)."    
    }
    Write-Host "Done."
    Write-Host "--------------------------------------------------"
    Write-Host "Renaming Directories..."
    if ($moduleNameReplacement -ne $moduleName) {

        $files = Get-ChildItem -Path:"$relativePathToProject" -include:"$($moduleName)*" -Directory -Recurse
        Write-Host "$($files.Count) Directories to rename..."
        foreach ($file in $files) {
            $name = $file.Name; 
            $newName = $name-ireplace [regex]::Escape($moduleName) , $moduleNameReplacement
            if ($newName -ne $name) {
                Rename-Item -path:$file -NewName:$newName -Force
            }else {
                Write-Host "Skip... $name  -- $newName"
            }
        }

        Write-Host "Done."
        Write-Host "--------------------------------------------------"
        Write-Host "Renaming Files..."
        @("*.dll")
        $files = Get-ChildItem -Path:"$relativePathToProject" -filter:"$($moduleName)*" -exclude:$exclude -File -Recurse 
        Write-Host "$($files.Count) Files to rename..."
        foreach ($file in $files) {
            $name = $file.Name; 
            $newName = $name -ireplace [regex]::Escape($moduleName) , $moduleNameReplacement
            if ($newName -ne $name) {
                Rename-Item -path:$file -NewName:$newName -Force
            }else {
                Write-Host "Skip... $name  -- $newName"
            }
        }
    }
    Write-Host "Done."
    Write-Host "--------------------------------------------------"

    Write-Host -ForegroundColor:Green "Done."    


}

function Replace-FileText($files, $pattern, $replace) {
    foreach ($file in $files) {
        #write replaced content back to the file
        try {
            $content = Get-Content $($file.FullName) -Raw
            $content -replace $pattern , $replace  | Out-File $($file.FullName) 
        }
        catch {
            # Write-Debug  $_.Exception.Message
            Write-Host "Error Processing $($file.Name), replacing '$pattern' with '$replace'..."
        }
    }
}

#Prepare-Project








































