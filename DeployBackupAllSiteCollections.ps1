$url=read-host "Digite a URL da WebApplication: ";
$app=Get-SPWebApplication $url
$sites=$app.sites
foreach ($site in $sites){
$path="d:\"+$site.RootWeb.title;
export-spweb -Identity $site.url.replace($url,""); -path $path -Force
}
