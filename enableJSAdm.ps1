$nome=Read-Host("Digite a URL Base");
$AdminSiteURL="https://"+$nome+"-admin.sharepoint.com"
$SiteURL="https://"+$nome+".sharepoint.com"   
Connect-SPOService -URL $AdminSiteURL   
Set-SPOSite $SiteURL -DenyAddAndCustomizePages $False

