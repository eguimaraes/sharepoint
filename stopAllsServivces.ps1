iisreset /stop
Stop-Service -Name "MSSQLSERVER"
$services=get-service;
foreach($service in $services){

if ($service.DisplayName.Contains("SharePoint") -or ($service.name -eq ("MSSQLSERVER"))){

Stop-Service -Name $service.Name


}
