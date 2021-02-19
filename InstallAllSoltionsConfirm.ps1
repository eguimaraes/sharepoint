Add-PSSnapin Microsoft.SharePoint.PowerShell
$webapps="http://maternidadebrasilia/"
foreach($webapp in $webapps){
$cont=read-host "Executando para ",$webapp,"continuar?(s/n)"
if ($cont -eq "s") {
Get-SPSolution | ForEach-Object {If ($_.ContainsWebApplicationResource -eq $False) {
Install-SPSolution -Identity $_ -GACDeployment -Force} else {Install-SPSolution -Identity $_ -WebApplication $webapp -GACDeployment -Force}}
}
}
