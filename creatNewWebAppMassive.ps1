write-host("Adding SharePoint PS - PowerShell - Microsoft.SharePoint.PowerShell");
Add-PSSnapin "Microsoft.SharePoint.PowerShell"
write-host("Carregando Lista de WebApplications");
$webapps=
foreach ($webapp in $webapps){
write-host("configurando WebApplications");
$hostHeader = $webapp
write-host("hostHeader = "+ $webapp);
$url = "http://"+$webapp
write-host("Url = "+ $url);
$appPoolName = $webapp
write-host("appPoolName = "+ $appPoolName);
$name=$webapp;
write-host("name = "+ $name);
$port=80;
write-host("port = "+ $port);
$appPoolAccount = Get-SPManagedAccount "ekis\administrator"
write-host("appPoolAccount = "+ $appPoolAccount);
$DatabaseServer = ""
write-host("DatabaseServer = "+ $DatabaseServer);
$DatabaseName = "WSS_Content_"+$webapp;
write-host("DatabaseName = "+ $DatabaseName);
write-host("Criando WebApplications");
New-SPWebApplication -Name $name -Port $port -HostHeader $hostHeader -URL $url -ApplicationPool $appPoolName -ApplicationPoolAccount $appPoolAccount -DatabaseServer $DatabaseServer -DatabaseName $DatabaseName

}
