$sites=Get-SPOSite
foreach ($site in $sites){
    
    if($site.Url.Contains("intranet")){
    
    write-host $site.Url



    }


}
