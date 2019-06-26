$SPSiteUrl = "http://portal.cotyww.com";
$SPSite = Get-SPSite $SPSiteUrl -ErrorAction SilentlyContinue
$SPWebCollection = $SPSite.AllWebs
$linha=[System.IO.StreamWriter] "C:\Scripts\Gruposportall.txt"

foreach($SPWeb in $SPWebCollection){
    foreach($SPGroup in $SPWeb.Groups){
    $linha.WriteLine($SPWeb.Title+" - "+$SPGroup.Name);
    }
}

$linha.close();
