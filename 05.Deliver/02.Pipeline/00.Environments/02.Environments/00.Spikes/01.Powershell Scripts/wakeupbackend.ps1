param(
       [String]$Url="http://localhost:2103/api/StatusTest"
)
Write-Host $Url
try 
{ 
	$request = Invoke-RestMethod -Method Get -ContentType application/json -Uri $Url 
	Write-Host  $request.StatusCode
}
catch  {
    $request = $_.Exception.Response 
	Write-Host “Failing the release as backend is not working as intended”
    Write-Host  $request.StatusCode
	exit -1 
}