$AdminSiteURL="https://"+$args[0]+".sharepoint.com"
$SiteURL="https://"+$args[0]+".sharepoint.com"   
Connect-SPOService -URL $AdminSiteURL   
Set-SPOSite $SiteURL -DenyAddAndCustomizePages $False
