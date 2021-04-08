$webapp=Get-SPWebApplication
$solutions=ls
foreach ($webapp in $webapps) {
  foreach ($arq in $arqs){   
    $cont=read-host();
    install-spsolution $arq.Name -GACDeployment -Force -WebApplication $webapp  
    
    }
          }


