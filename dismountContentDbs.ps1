write-host("Adicionando componentes do PowerShell - Microsoft.SharePoint.PowerShell");

Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$ConfirmPreference = 'None'

$sites="nome","nome","nome","nome","nome","nome","nome","nome","nome";

foreach($site in $sites){

$cdb="WSS_Content_"+$site;

Dismount-SPContentDatabase $cdb

write-host("Desmontando Content Databases - "+$cdb);

}
