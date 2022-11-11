Connect-SPOService -Url URL
$ADGroupID = "guid" - #ver no azureportal
$LoginName = "c:0t`.c`|tenant`|$ADGroupID"

$sites=Get-SPOSite
foreach ($site in $sites){
    
    if($site.Url.Contains("intranet")){
    Set-SPOUser -Site $site.Url -LoginName $LoginName -IsSiteCollectionAdmin $true
    write-host $site.Url



    }


}
