$webApp = Get-SPWebApplication http://myportal.com
$webApp.Provision()

$webApp = Get-SPWebApplication http://myportal.com
$webApp.ProvisionGlobally()
