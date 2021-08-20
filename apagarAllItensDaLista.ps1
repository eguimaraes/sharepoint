$web=Get-SPWeb url
$list=$web.Lists["titulo"]
$items=$list.Items
foreach ($item in $items){write-host ("Apagando"+$list.Items[0].title); $list.Items[0].Delete();}
