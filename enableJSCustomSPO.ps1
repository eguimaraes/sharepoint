$AdminSiteURL=Read-Host("Digite a URL ADM");
$SiteURL=Read-Host("Digite a URL do site");
Connect-SPOService -URL $AdminSiteURL   
Set-SPOSite $SiteURL -DenyAddAndCustomizePages $False
