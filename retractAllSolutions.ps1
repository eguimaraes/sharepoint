Add-PSSnapin Microsoft.SharePoint.PowerShell
$solutions=get-spsolution
foreach ($solution in $solutions) {
uninstall-spsolution $solution -AllWebApplications -Confirm:$false
remove-spsolution $solution -Confirm:$false

 }
