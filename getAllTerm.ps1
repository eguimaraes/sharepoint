#https://sharepoint.stackexchange.com/questions/75991/how-to-iterate-through-termstore-in-managed-metadata
$siteCollectionUrl = "http://sp2010:90"
$site =new-object Microsoft.SharePoint.SPSite($siteCollectionUrl)
$session = New-Object Microsoft.SharePoint.Taxonomy.TaxonomySession($site)
$termStore = $session.TermStores[0]
$group = $termStore.Groups["Corporate Taxonomy"]
$termSet = $group.TermSets["Geography"]
$terms = $termSet.GetAllTerms()
foreach ($term in $terms)
{
    if ($term.Name -eq "Durban")
    {
        Write-Host "Drban Found!"
    }
}
