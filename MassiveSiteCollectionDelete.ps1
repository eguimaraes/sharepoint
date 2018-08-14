write-host("Adding SharePoint PS - PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

write-host("Setting for no confirmation prompt");
$ConfirmPreference = 'None'

$urlBase="http://host"

$sites="site1","site0","site2","site13";

foreach($site in $sites){

$url=$urlBase+"/sites/"+$site;
   

write-host("Deleting SiteCollections");

New-SPSite $url -ContentDatabase $cdb -OwnerAlias "domain\user";

write-host("Deleting Content DB");

$cdb="WSS_Content_"+$site;

New-SPContentDatabase $cdb -WebApplication $urlBase



}