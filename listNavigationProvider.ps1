
$url=read-host "Digite a URL da Web":
$web = Get-SPWeb $url;
$WebNavSettings = New-Object Microsoft.SharePoint.Publishing.Navigation.WebNavigationSettings($Web);
write-host "Navegação Local" $WebNavSettings.CurrentNavigation
write-host Navegação Global $WebNavSettings.GlobalNavigation
