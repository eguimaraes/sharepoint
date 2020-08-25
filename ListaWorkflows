function getWorkflows ($url) {
Connect-PnPOnline -Url $url -UseWebLogin
#$site=Get-PnPSite 
#$web=Get-PnPWeb -Includes Webs
$listas=Get-PnPList -Includes WorkflowAssociations

$valor="URL,NomeLista,NomeFluxo,AutoStartChange,AutoStartCreate,Created,Modified,Enabled";
escreveResultados($valor)


foreach($lista in $listas){

if ($lista.WorkflowAssociations.count -gt 0){
   

   $valor=$url+","+$lista.Title+","+$lista.WorkflowAssociations.name+","+$lista.WorkflowAssociations.AutoStartChange+","+$lista.WorkflowAssociations.AutoStartCreate+","+$lista.WorkflowAssociations.Created+","+$lista.WorkflowAssociations.Modified+","+$lista.WorkflowAssociations.Enabled;

     escreveResultados($valor)
     
     }
        
        }

        Disconnect-PnPOnline

        }


        
        function leSites($path){
        
        $sites=Get-Content -Path $path

        foreach ($site in $sites){

        Write-Host($site);

        #Read-Host("Aguarde")

        getWorkflows ($site)
        
        }
        
        
        }


        function escreveResultados($valor){
        
        Add-Content -Path "workflows.txt" -Value $valor
        
        }



    leSites("sites.txt")
