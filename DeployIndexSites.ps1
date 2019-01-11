write-host("Gravando no Site de Administração");
$sites="name;ralativeUrl";


$url1="http://url/sites/"
 
 foreach($site in $sites){

 $url=$site.split(";")[2];

 $url2=$url1+"produtos";

$siteAntigo=Get-SPSite $url2;

$web=$siteAntigo.RootWeb;

$list=$web.lists["URL"];

$item=$list.Items.Add();
$item["Title"]=$site.split(";")[0];

$urldocs=$url1+$url+"/SitePages/page.aspx";
$urldocs=$urldocs+" , "+$site.split(";")[0];

$item["URL"]=$urldocs; 
$item.Update();
}
