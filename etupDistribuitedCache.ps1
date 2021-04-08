Stop-SPDistributedCacheServiceInstance -Graceful

$instanceName ="SPDistributedCacheService Name=AppFabricCachingService" 
$serviceInstance = Get-SPServiceInstance | ? {($_.service.tostring()) -eq $instanceName -and ($_.server.name) -eq $env:computername} 
$serviceInstance.delete()

Remove-SPDistributedCacheServiceInstance

Add-SPDistributedCacheServiceInstance 

Update-SPDistributedCacheSize 
