.\stopAllServices.ps1
$services=get-service
foreach($service in $services){


if ($service.DisplayName.Contains("SharePoint") -or $service.DisplayName.Contains("SQL Serve") -or $service.DisplayName.Contains("Project") ){




$continuar=read-host("Deseja Iniciar:"+$service.DisplayName+"?(s/n)")


if($continuar -eq "s" -or $continuar -eq "S"){ 
write-host("Habilitando e Iniciando" + $service.DisplayName)
Set-Service $service.Name -startupType Manual
Start-Service -Name $service.Name
}


}
};
iisreset 
#add-pssnapin microsoft.sharepoint.powershell 
#Disable-SPAppAutoProvision
