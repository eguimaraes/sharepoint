Get-SPSolution | ForEach-Object {If ($_.ContainsWebApplicationResource -eq $False) {Install-SPSolution -Identity $_ -GACDeployment} else {Install-SPSolution -Identity $_ -AllWebApplications -GACDeployment}}
