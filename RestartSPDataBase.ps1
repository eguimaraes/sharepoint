#https://docs.microsoft.com/en-us/powershell/module/sharepoint-server/reset-spsites?view=sharepoint-server-ps
$contentdb = Get-SPContentDatabase ContentDbName
Reset-SPSites -Identity $contentDb
