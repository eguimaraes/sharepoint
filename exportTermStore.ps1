#https://sharepoint-tricks.com/export-sharepoint-term-set-with-powershell-to-csv/
$userName = 'contoso'
$password = 'pw' | ConvertTo-SecureString -Force -AsPlainText
$cred = New-Object -typename System.Management.Automation.PSCredential($userName, $password)
$siteCollectionUrl = "https://contoso.sharepoint.com/sites/site"
[System.Collections.ArrayList] $completeTerm = [System.Collections.ArrayList]::new()


$termGroup = "People"
$termSet = "Department"

Connect-PnPOnline $siteCollectionUrl -Credentials $cred 
$termStores = Get-PnPTerm -TermGroup $termGroup -TermSet $termSet -IncludeChildTerms 
$completeTerm = @()

foreach ($termStore in $termStores) {
 $completeTerm += New-Object PsObject -Property @{
  "Term Set Name" = $termSet;
  "Level 1 Term"  = $termStore.Name;
 }
 if ($termStore.TermsCount -gt 0) {
  foreach ($termStoreChild in $termStore.Terms) {
   $completeTerm += New-Object PsObject -Property @{ 
    "Term Set Name" = $termSet;
    "Level 1 Term"  = $termStore.Name;
    "Level 2 Term"  = $termStoreChild.Name;
   }	
  }
 }
}

$completeTerm | Select-Object "Term Set Name", "Term Set Description", "LCID", "Available for Tagging", "Term Description", "Level 1 Term", "Level 2 Term", "Level 3 Term", "Level 4 Term" | Export-Csv "./TermSet.csv" -NoTypeInformation
