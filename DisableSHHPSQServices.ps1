$services=get-service;
foreach($service in $services){

if ($service.DisplayName.Contains("SharePoint") -or $service.DisplayName.Contains("SQL Serve") ){

write-host ("Desligando e Desabilitando:"+$service.DisplayName)
Stop-Service -Name $service.Name
Set-Service $service.Name -startupType Disabled


}

}
