$snap = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.Powershell'}
if ($snap -eq $null) {
Add-PSSnapin Microsoft.SharePoint.Powershell
}
