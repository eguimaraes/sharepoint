$solNmane="Nome da Solução"
$solution=get-spsolution $solNmane
uninstall-spsololution $solution -allwebapplications
while ($solution.deployed){write-host "Aguarde"}
remove-spsolution $solution
