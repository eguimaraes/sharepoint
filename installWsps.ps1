function installWsps {


[CmdletBinding()]
 param (
        $LocalWsps
    )




add-pssnapin microsoft.sharepoint.powershell -ErrorAction SilentlyContinue;
   


$solutions=ls $LocalWsps


$webapps=get-spwebapplication


foreach ($webapp in $webapps){




if ((read-host "Aplicar Todas as soluções (WSP) em $webapp ? (s/n)") -eq "s"){


foreach ($solution in $solutions){


write-host "Solicitando o Deploy de $solution";


write-host ("install-spsolution -Identity $solution.Name -GACDeployment -WebApplication $webapp -force");


#install-spsolution -Identity $solution.Name -GACDeployment -WebApplication $webapp -force 
}


}




}
}
