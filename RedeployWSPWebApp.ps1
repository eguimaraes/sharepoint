$webapp="SharePoint - 8080"
$farm=get-spfarm
$solutions=$farm.Solutions
foreach ($solution in $solutions) {install-spsolution -identity $solution.name -WebApplication $webapp -GACDeployment}
