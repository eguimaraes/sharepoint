write-host("Adding SharePoint PS - PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$urlBase="http://host"

$sites="site1","site0","site2","site13";

foreach($site in $sites){

$url=$urlBase+"/sites/"+$site;

$cdb="WSS_Content_"

write-host("Creating SiteCollections");

New-SPSite $url -ContentDatabase $cdb -OwnerAlias "domain\user";

$path=$site+".bak";

Import-SPWeb $url -Path $path -UpdateVersions Overwrite


}
