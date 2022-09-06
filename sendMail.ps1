$site = New-Object Microsoft.SharePoint.SpSite("https://sharepoint.company.com")

$web = $site.OpenWeb()
 
$mail = [Microsoft.Sharepoint.Utilities.SpUtility]::SendEmail($web,0,0,"support@company.com","Subject of the Mail","mail body")


