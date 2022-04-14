 add-pssnapin microsoft.sharepoint.powershell
 $solutions=get-spsolution;
 $webapp=read-host("Digite a URL da webapp");
 foreach ($solution in $solutions){
 
 install-spsolution -Identity $solution.Name -GACDeployment -WebApplication $webapp -force 
 
 
 }
