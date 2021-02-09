function FixNavigation($url)
{
    try
    {
        $web = Get-SPWeb $url;
        Write-Host ([String]::Format("Procesing web {0}",$web.Url)) -foregroundcolor White
        $WebNavSettings = New-Object Microsoft.SharePoint.Publishing.Navigation.WebNavigationSettings($Web);
        $WebNavSettings.GlobalNavigation.Source = "PortalProvider"
        $WebNavSettings.CurrentNavigation.Source = "PortalProvider"
        $WebNavSettings.Update()
        Write-Host ([String]::Format("Updated navigation to Structured {0}",$web.Url)) -foregroundcolor blue
        $web = Get-SPWeb $url;
        $WebNavSettings = New-Object Microsoft.SharePoint.Publishing.Navigation.WebNavigationSettings($Web);
        $WebNavSettings.GlobalNavigation.Source = "TaxonomyProvider"
        $WebNavSettings.CurrentNavigation.Source = "TaxonomyProvider"
        $WebNavSettings.Update()
        Write-Host ([String]::Format("Updated navigation to Structured {0}",$web.Url)) -foregroundcolor green
        if($web.Webs.Count -gt 0)
        {
            foreach($subWeb in $web.Webs)
           {
                #$web.Url
                FixNavigation $subWeb.Url;
            }
        }
    }
    catch
    {
        Write-Host ([String]::Format("Error processing web at $url, with Exception: {0}",   $_.Exception.Message)) -foregroundcolor Red
    }
}
$url = read-host "Digite a URL da web Application:"
FixNavigation($url)
