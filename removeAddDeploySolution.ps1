$solNmane="Nome da Solução"
$solution=get-spsolution $solNmane
uninstall-spsololution $solution -allwebapplications
while ($solution.deployed){write-host "Aguarde"}
remove-spsolution $solution

$solution=add-spsolution $PWD\$solution
install-spsolution $solution -GACDeployment -AllWebApplications -Force
while (!$solution.deployed){write-host "Aguarde"}
