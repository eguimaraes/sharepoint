#Original em https://learn.microsoft.com/en-us/powershell/sharepoint/sharepoint-online/connect-sharepoint-online
Get-Module -Name Microsoft.Online.SharePoint.PowerShell -ListAvailable | Select Name,Version
Install-Module -Name Microsoft.Online.SharePoint.PowerShell
Install-Module -Name Microsoft.Online.SharePoint.PowerShell -Scope CurrentUser
Update-Module -Name Microsoft.Online.SharePoint.PowerShell
Connect-SPOService -Url https://contoso-admin.sharepoint.com -Credential admin@contoso.com
Connect-SPOService -Url https://contoso-admin.sharepoint.com
