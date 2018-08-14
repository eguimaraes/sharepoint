write-host("Adding SharePoint PS - PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$urlBase="http://host"

$sites="site1","site0","site2","site13";

foreach($site in $sites){

$url=$urlBase+"/sites/"+$site;
   
write-host("Creating Content DB");

$cdb="WSS_Content_"+$site;

New-SPContentDatabase $cdb -WebApplication $urlBase

write-host("Creating SiteCollections");

New-SPSite $url -ContentDatabase $cdb -OwnerAlias "domain\user";

}