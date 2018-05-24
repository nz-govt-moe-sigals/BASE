param(
       [String]$Url="http://localhost:2103/api/StatusTest"
)
Write-Host $Url
try 
{ 
	Start-Sleep -Seconds 90
	$request = Invoke-RestMethod -TimeoutSec 600 -Method Get -ContentType application/json -Uri $Url 
	Write-Host  $request.StatusCode
}
catch  {
    $request = $_.Exception.Response 
	Write-Host "Failing the release as backend is not working as intended"
    Write-Host  $request.StatusCode
	Write-Host $_.Exception
	exit -1 
}



