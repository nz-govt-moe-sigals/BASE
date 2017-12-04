param (
   [string] $AzureWebsiteName, 
   [string] $ResourceGroup,  
   [hashtable] $appsettings = $null,
   [hashtable] $connectionstrings = $null
)


if ($appsettings -eq $null)
{
  Set-AzureRmWebApp -Name $AzureWebsiteName -ResourceGroupName $ResourceGroup -ConnectionStrings $connectionstrings 
}
elseif ($connectionstrings -eq $null)
{
  Set-AzureRmWebApp -Name $AzureWebsiteName -ResourceGroupName $ResourceGroup -AppSettings $appsettings 
}
else
{
Set-AzureRmWebApp -Name $AzureWebsiteName -ResourceGroupName $ResourceGroup -AppSettings $appsettings -ConnectionStrings $connectionstrings 
}