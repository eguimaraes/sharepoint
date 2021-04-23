$servApps=Get-SPServiceApplication
$servApps.name
$servApps.typename
$servApps.ID
Get-SPServiceApplication | Where-Object {$_.typename -eq "Managed Metadata Service"}
$mmservice=Get-SPServiceApplication | Where-Object {$_.typename -eq "Managed Metadata Service"}
$mmservice.Status
$mmservice.Service

