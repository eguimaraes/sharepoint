$web=get-spweb $args[0]
$list=$web.lists[$args[1]]
$items=$list.Items
foreach ($item in $items){
write-host ("Apagando item ID "+$list.Items[0].ID+" Titulo "+ $list.Items[0].title);
$list.Items[0].Delete();};
