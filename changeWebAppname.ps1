$url="url"
$webname = Get-SPWebApplication $url
$webname.Name = "novonome"  
$webname.Update()  
