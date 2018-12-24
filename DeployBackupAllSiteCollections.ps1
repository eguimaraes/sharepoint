$url=read-host "Digite a URL da WebApplication: ";
$sufixo=read-host "Digite o managed path da SiteCollection: ";
$app=Get-SPWebApplication $url
$sites=$app.sites
foreach ($site in $sites){
$path="d:\\"+$site.url.replace($url+$sufixo,"");
if($path.length==0 -AND $path -eq "d:\\"){"d:\"+$site.RootWeb.title}
write-host $path
read-host
export-spweb -Identity $url -path $path -Force
}
