$ssa = Get-SPEnterpriseSearchServiceApplication -id “<GUID of your Search>”
$ssa.unprovision(1)
$ssa.Delete() 
