$URL=read-host("Digite a URL do Site");
$Arquivo=read-host("Digite nome do arquivo com extensão xml");
Connect-PnPOnline -Url $URL -Interactive
Get-PnPSiteTemplate -Out $Arquivo

