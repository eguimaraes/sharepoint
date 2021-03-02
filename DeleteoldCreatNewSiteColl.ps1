Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction "SilentlyContinue"
$title= "ekis Intranet"
$url = "http://intranet.ekis.com:8889"
$owner = "ekis\Administrator"
$template = "STS#1"
# Apaga a site colection se ela existir
$targetSite = Get-SPSite | Where-Object {$_.Url -eq $url}
if ($targetSite -ne $null) {
Remove-SPSite -Identity targetSite -Confirm:$false
}
$sc = New-SPSite -URL $url -Name $title -OwnerAlias $owner -Template $template
$site = $sc.RootWeb
$site.Title = "Novo Site da Intranet"
$site.Update
