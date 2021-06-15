$site=Get-SPSite "URL"
$web=$site.RootWeb
$list=$web.Lists["List Title"]
while ($list.Items.Count -gt 0){$list.Items[0].Delete();$list.Items.
Count}
