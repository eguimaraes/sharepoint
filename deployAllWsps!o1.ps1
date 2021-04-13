add-pssnapin microsoft.sharepoint.powershell

$solutions=ls

$webapps=get-spwebapplication

foreach ($webap in $webapps){

write-host ("Aplicar Todas as soluções (WSP) em "+$webap+"? (s/n)");


if (read-host -eq "s"){

foreach ($solution in $solutions){

-Identity $solution.Name -GACDeployment -WebApplication $webapp -force 
}

}




}
