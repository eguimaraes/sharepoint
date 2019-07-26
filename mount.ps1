write-host("Adicionando componentes do PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$ConfirmPreference = 'None'

$urlBase="http:/url/";

$sites="nomes","nomes","nomes","nomes","nomes";

foreach($site in $sites){

$cdb="WSS_Content_"+$site;

Mount-SPContentDatabase -Name $cdb -WebApplication $urlBase

write-host("Montando Content Databases - "+$cdb);

}
