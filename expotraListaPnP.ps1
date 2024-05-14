#https://pnp.github.io/powershell/cmdlets/Export-PnPListToProvisioningTemplate.html
$SiteURL = "https:/siteURL"
$site=Connect-PnPOnline -Url $SiteURL -Interactive
Export-PnPListToSiteTemplate -Out template.xml -List "nomedalista"
