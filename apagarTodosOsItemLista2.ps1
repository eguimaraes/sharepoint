add-pssnapin microsoft.sharepoint.powershell 
$web=get-spweb $args[0]
$list=$web.lists[$args[1]]
while($list.Items.count -gt 0){
write-host ("Apagando item ID "+$list.Items[0].ID+" Titulo "+ $list.Items[0].title);
$list.Items[0].Delete();};
