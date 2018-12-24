$url=read-host "Digite a URL da WebApplication: ";
$sufixo=read-host "Digite o managed path da SiteCollection: ";
$app=Get-SPWebApplication $url
$sites=$app.sites
foreach ($site in $sites){
$path="d:\"+$site.url.replace($url+$sufixo,"");
$path=($path.length>0)?$path:$site.title
export-spweb -Identity $url -path $path -Force
}
