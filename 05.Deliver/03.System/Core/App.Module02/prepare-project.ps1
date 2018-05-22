[cmdletbinding]
function Prepare-Project {
    [CmdletBinding()]
    Param (
        [string]$relativePathToProject = ".\" ,
        [string]$moduleName = "Module02"
    )

    $relativePathToProject = (Get-Item -Path $relativePathToProject).FullName

    $excludeFolders = @("bin","obj")
    $fileFilters = @('*.cs', '*.cshtml', '*.md','*.txt', 'web.config', '*.csproj','*.csproj.user', '*.csproj.DotSettings', '*.ps1')

    Write-Host "=================================================="
    Write-Host "Project Provisioner"
    Write-Host "Provisions a folder of *.csproj"
    Write-Host "=================================================="
    Write-Host "Current Folder: $relativePathToProject"
    Write-Host "--------------------------------------------------"
    # If no projects, show a warning so that user looks before proceeding...
    $tmpCount = (Get-ChildItem -Path:$relativePathToProject -Filter:"$($moduleName)*.csproj" -File -Recurse).Count
    if ($tmpCount -eq 0) {
        Write-Host -ForegroundColor:Red "WARNING: Folder did not find any '$($moduleName)*.csproj' files in folder. Type '.' or 'Quit' to Quit."
    }else{
        Write-Host -ForegroundColor:Green  "'$($moduleName)*.csproj' files found: " $tmpCount
    }
    Write-Host "--------------------------------------------------"
    # how many files overall to look through:
    $tmpCount = (Get-ChildItem -Path:$relativePathToProject -exclude:$excludeFolders -Recurse -File).Count
    $tmpCount2 = (Get-ChildItem -Path:$relativePathToProject -exclude:$excludeFolders -Include:$fileFilters -Recurse -File).Count
    $tmpCount3 = (Get-ChildItem -path:$relativePathToProject -include:$fileFilters -File -Recurse  | Where-Object {$_.PSParentPath -notmatch "bin|obj"}).Count
    Write-Host -ForegroundColor:Green "Files: $($tmpCount) (Filtered: $tmpCount2, $tmpCount3)."

    
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

    if ($moduleNameReplacement -ne $moduleName) {


        Write-Host "--------------------------------------------------"
        Write-Host "Replacing '$($moduleName)' with '$($moduleNameReplacement)' within Files..."
        $files = Get-ChildItem -path:$relativePathToProject -include:$fileFilters -File -Recurse  | Where-Object {$_.PSParentPath -notmatch "bin|obj"}
        Replace-FileText -files:$files -pattern:$moduleName  -replace:$moduleNameReplacement
        Write-Host "Done."

        $classNamePrefix = $moduleName.Replace('.', '')
        $classNamePrefixReplacement = $moduleNameReplacement.Replace('.', '')

        Write-Host "--------------------------------------------------"
        Write-Host "Replacing '$($classNamePrefix)' with '$($classNamePrefixReplacement)' within Files..."
        $files = Get-ChildItem -path:$relativePathToProject -include:$fileFilters -File -Recurse  | Where-Object {$_.PSParentPath -notmatch "bin|obj"}
        Replace-FileText -files:$files -pattern:$classNamePrefix  -replace:$classNamePrefixReplacement    
        Write-Host "Done."
    }
    else {
        Write-Host -ForegroundColor:Gray "No change (Module Name is the same)."    
    }

    Write-Host "Done."
    if ($moduleNameReplacement -ne $moduleName) {

        Write-Host "Done."
        Write-Host "--------------------------------------------------"
        Write-Host "Renaming Files..."
        $files = Get-ChildItem -path:$relativePathToProject -include:$fileFilters -File -Recurse  | Where-Object {$_.PSParentPath -notmatch "bin|obj"}
        Write-Host "$($files.Count) Files to rename...from '$moduleName' to '$moduleNameReplacement'"
        foreach ($file in $files) {
            $name = $file.Name; 
            $newName = $name -ireplace [regex]::Escape($moduleName) , $moduleNameReplacement
            if ($newName -ne $name) {
                Write-Host "Renaming file '$($file.Name)' to '$newName'"
                Rename-Item -path:$file -NewName:$newName -Force
            }
        }


        
        Write-Host "--------------------------------------------------"
        Write-Host "Renaming Directories..."
        $directories = Get-ChildItem -Path:"$relativePathToProject" -Directory -Recurse   | Where-Object{$_.FullName -notmatch "\\(bin|obj)"}  
        Write-Host "$($directories.Count) Directories to rename...from '$moduleName' to '$moduleNameReplacement'"
        foreach ($directory in $directories) {
            $name = $directory.Name; 
            $newName = $name-ireplace [regex]::Escape($moduleName) , $moduleNameReplacement
            if ($newName -ne $name) {
                Write-Host "Renaming directory '$($directory.Name)' to '$newName'"
                Rename-Item -path:$directory -NewName:$newName -Force
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
        try {
            $content = Get-Content $($file.FullName) -Raw 
            $content -replace $pattern , $replace  | Out-File $($file.FullName) -Encoding:UTF8
        }
        catch {
            # Write-Debug  $_.Exception.Message
            Write-Host "Error Processing '$($file.FullName)', replacing '$pattern' with '$replace'..."
        }
    }
}

#Prepare-Project
























































