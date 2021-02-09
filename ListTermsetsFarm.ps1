$url = read-host "Digite a Url"
$MMS= read-host "Digite o Nome da service application de Metadados Gerenciados"
$web = Get-SPWeb $url
$taxonomySession = Get-SPTaxonomySession -Site $web.Site
$termStore = $taxonomySession.TermStores[$MMS];
foreach($item in $termStore.Groups){
if($item.Name -eq "Marketing")
{
$group = $item
}
}
Write-Host "---->: " $group.Name

$termset = $group.TermSets["nomeTermset"];
$guid = New-Object System.Guid("guidtermset");
$term = $termset.GetTerm($guid);


Write-Host $term.Name;

}
