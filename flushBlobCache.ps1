#https://docs.microsoft.com/en-us/sharepoint/administration/flush-the-blob-cache
$webApp = Get-SPWebApplication "<WebApplicationURL>"
[Microsoft.SharePoint.Publishing.PublishingCache]::FlushBlobCache($webApp)
Write-Host "Flushed the BLOB cache for:" $webApp
