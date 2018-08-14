write-host("Adding SharePoint PS - PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

write-host("Setting for no confirmation prompt");
$ConfirmPreference = 'None'

$urlBase="http://host"

$sites="site1","site0","site2","site13";

foreach($site in $sites){

$url=$urlBase+"/sites/"+$site;
   

write-host("Deleting SiteCollections");

Remove-SPSite -Identity $url -GradualDelete -confirm:$false -ErrorAction SilentlyContinue

write-host("Deleting Content DB");

$cdb="WSS_Content_"+$site;

Remove-SPContentDatabase $cdb  -confirm:$false -ErrorAction SilentlyContinue -force



}