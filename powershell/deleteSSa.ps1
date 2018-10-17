$ssa = Get-SPEnterpriseSearchServiceApplication -id “<GUID of your Search>”
$ssa.unprovision(1)
$ssa.Delete() 
$spapp = Get-SPServiceApplication -Name "Contoso BDC Service"
Remove-SPServiceApplication $spapp -RemoveData
