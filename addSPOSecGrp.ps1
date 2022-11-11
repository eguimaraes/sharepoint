$ADGroupID = "guid"
$LoginName = "c:0t`.c`|tenant`|$ADGroupID"

$sites=Get-SPOSite -Limit ALL
foreach ($site in $sites){
    
    if($site.Url.Contains("intranet")){
    
    Add-SPOUser -Group "nomedoGrupo" -LoginName $LoginName -Site $site.Url
    write-host ("Usuario Adicionado ao site "+$site.Url)



    }
