$solutionName=Read-Host "Digite o Nome da solução"
$solution=Get-SPSolution $solutionName
Uninstall-SPSolution $solution -AllWebApplications 
while ($solution.Deployed){write-host "aguarde"}
remove-spsolution $solution 
read-host "aguarde 30 segundos"
$solution=add-spsolution $PWD\$solutionName 
read-host "aguarde 30 segundos"
install-spsolution $solution -AllWebApplications -GACDeployment
while (!$solution.Deployed){write-host "aguarde"}
