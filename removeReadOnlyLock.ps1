$Admin =  new-object Microsoft.SharePoint.Administration.SPS
iteAdministration('http://root.toto.com')
$Admin.ClearMaintenanceMode()
$site.MaintenanceMode
