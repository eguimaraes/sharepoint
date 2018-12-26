$url=read-host "Digite a URL da WebApplication: "
$feature=read-host "Digite o Nome da Feature: "
Get-SPFeature | Where-Object { $_.DisplayName -like $feature+"*" }

