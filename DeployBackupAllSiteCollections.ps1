$url=read-host "Digite a URL da WebApplication: ";
$app=Get-SPWebApplication $url
$sites=$app.sites
foreach ($site in $sites){
$path="d:\"+$site.url.replace($url,"");
export-spweb -Identity $url -path $path -Force
}
