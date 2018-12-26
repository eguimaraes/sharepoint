$url=read-host "Digite a URL da WebApplication: "
$featureName=read-host "Digite o Nome da Feature: "
$features=Get-SPFeature | Where-Object { $_.DisplayName -like $featureName+"*" }
foreach($feature in $features{

Disable-SPFeature –identity $feature.DisplayName -URL $url



}
