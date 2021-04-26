$name="NOME OU PARTE DO NOME DA SOLUÇÃO"
$solution=Get-SPSolution | Where-Object {$_.name.contains($name)}
Uninstall-SPSolution $solution -AllWebApplications
Remove-SPSolution $solution
