$webapps="webappurl,webappurl,webappurl"
foreach($webapp in $webapps){
Get-ChildItem | ForEach-Object{Add-SPSolution -LiteralPath $_.Fullname}
Get-SPSolution | ForEach-Object {If ($_.ContainsWebApplicationResource -eq $False) {Install-SPSolution -Identity $_ -GACDeployment} else {Install-SPSolution -Identity $_ -WebApplication $webapp -GACDeployment}}
}
