$solutionName=Read-Host "Digite o Nome da solução"
$solution=Get-SPSolution $solutionName
Uninstall-SPSolution $solution -AllWebApplications -Confirm:$false
while ($solution.Deployed){write-host "aguarde"}
remove-spsolution $solution
$solution=add-spsolution $PWD\$solutionName
install-spsolutions $Solution  -AllWebApplications -Confirm:$false -GACDeployment
while (!$solution.Deployed){write-host "aguarde"}
