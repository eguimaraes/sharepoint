.\stopAllServices.ps1

$ServicesNames = @(
    'SQL Server (MSSQLSERVER)'
    'SharePoint Administration'
    'SharePoint Timer Service'   
)

foreach ($ServiceName in $ServicesNames){
$service=Get-Service $ServiceName
Set-Service $service.Name -startupType Manual
Start-Service -Name $service.Name

}

write-host("Aguarde concluir add-pssnapin microsoft.sharepoint.powershell")
add-pssnapin microsoft.sharepoint.powershell
write-host("Aguarde concluir Disable-SPAppAutoProvision")
Disable-SPAppAutoProvision
