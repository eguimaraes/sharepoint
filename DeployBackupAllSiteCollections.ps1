$app=Get-SPWebApplication http://sitename
$sites=$app.sites
foreach ($site in $sites){$path="d:\"+$site.RootWeb.title; export-spweb -Identity $site.url -path $path -Force}