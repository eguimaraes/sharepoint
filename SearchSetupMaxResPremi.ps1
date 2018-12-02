#original em https://sharepoint.stackexchange.com/questions/208462/sharepoint-search-js-returns-only-500-search-results/208464
$ssa = Get-SPEnterpriseSearchServiceApplication
$ssa.MaxRowLimit = 10000
$ssa.Update()
