$url=read-host "Digite a URL da WebApplication: ";
$prefixo=read-host "Digite o prefixo do Path (Ex. D:\): ";
$sufixo=read-host "Digite o managed path da SiteCollection: ";
$app=Get-SPWebApplication $url
$sites=$app.sites
foreach ($site in $sites){
$path=prefixo+$site.url.replace($url,"").replace($sufixo,"");
if($path -eq prefixo ){$path=prefixo+$site.RootWeb.title}
$path=$path+".bak";
export-spweb -Identity $url -path $path -Force
}
