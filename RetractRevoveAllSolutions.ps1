$solutions=Get-SPSolution
foreach ($solution in $solutions){ 
uninstall-SPSolution $solution -Confirm:$false -AllWebApplications
remove-spsolution $solution -Confirm:$false
}
