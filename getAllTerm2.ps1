#https://sharepoint.stackexchange.com/questions/75991/how-to-iterate-through-termstore-in-managed-metadata
$siteCollectionUrl = "http://xxxx"
$site =new-object Microsoft.SharePoint.SPSite($siteCollectionUrl)
$session = New-Object Microsoft.SharePoint.Taxonomy.TaxonomySession($site)
$termStore = $session.TermStores[0]
$group = $termStore.Groups["Corporate Taxonomy"]
$termSet = $group.TermSets["Geography"]
$terms = $termset.Terms

foreach($term in $terms){

   $subterms = $terms.Terms

   foreach($term1 in $subterms){

      Write-Host $term1.Name

   }

}
