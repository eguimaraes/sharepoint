#enable
$service=[Microsoft.SharePoint.Administration.SPWebService]::ContentService
$addsetting=$service.DeveloperDashboardSettings
$addsetting.DisplayLevel=[Microsoft.SharePoint.Administration.SPDeveloperDashboardLevel]::OnDemand
$addsetting.update()

#disable
$service=[Microsoft.SharePoint.Administration.SPWebService]::ContentService
$addsetting=$service.DeveloperDashboardSettings
$addsetting.DisplayLevel=[Microsoft.SharePoint.Administration.SPDeveloperDashboardLevel]::off

$addsetting.update()
