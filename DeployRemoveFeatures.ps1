$url=read-host "Digite a URL da WebApplication: "
$featureName=read-host "Digite o Nome da Feature: "
$features=Get-SPFeature | Where-Object { $_.DisplayName -like $featureName+"*" }
foreach($feature in $features){
Disable-SPFeature –identity $feature.DisplayName -URL $url -confirm:$false -force

$sites=get-spsite -Limit all;

foreach($site in $sites){

write-host $site.RootWeb.url;
 
write-host $feature.DisplayName

Disable-SPFeature –identity $feature.DisplayName -URL $site.RootWeb.url -confirm:$false -force


}



}
