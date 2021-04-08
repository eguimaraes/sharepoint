#https://www.sharepointdiary.com/2014/09/change-distributed-cache-service-account-in-sharepoint-2013-with-powershell.html

Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue
 
#Get the Farm
$Farm=Get-SPFarm
 
#Get Distributed Cache Service
$CacheService = $Farm.Services | where {$_.Name -eq "AppFabricCachingService"}
 
#Get the Managed account 
$ManagedAccount = Get-SPManagedAccount -Identity "Crescent\SPS_Services"
 
#Set Service Account for Distributed Cache Service
$cacheService.ProcessIdentity.CurrentIdentityType = "SpecificUser"
$cacheService.ProcessIdentity.ManagedAccount = $ManagedAccount
$cacheService.ProcessIdentity.Update()
$cacheService.ProcessIdentity.Deploy()
 
Write-host "Service Account successfully changed for Distributed Service!"

Stop-SPDistributedCacheServiceInstance
Remove-SPDistributedCacheServiceInstance
Add-SPDistributedCacheServiceInstance
