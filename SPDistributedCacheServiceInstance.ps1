Export-CacheClusterConfig -Path $PWD\AF.XML
#verifique o arquivo para localizarr o registro do cache
Unregister-CacheHost -HostName SP15-WFE.cloudnet.local -ProviderType SPDistributedCacheClusterProvider -ConnectionString \\NOMEsERVER
$SPFarm = Get-SPFarm
$cacheClusterName = "SPDistributedCacheCluster_" + $SPFarm.Id.ToString()

$cacheClusterManager = [Microsoft.SharePoint.DistributedCaching.Utilities.SPDistributedCacheClusterInfoManager]::Local
$cacheClusterInfo = $cacheClusterManager.GetSPDistributedCacheClusterInfo($cacheClusterName);
$instanceName ="SPDistributedCacheService Name=AppFabricCachingService"
$serviceInstance = Get-SPServiceInstance | ? {($_.Service.Tostring()) -eq $instanceName -and ($_.Server.Name) -eq $env:computername}
$serviceInstance.Delete()

Remove-SPDistributedCacheServiceInstance
Add-SPDistributedCacheServiceInstance -Role WebFrontEndWithDistributedCache

Add-SPDistributedCacheServiceInstance -Role SingleServerFarm
Add-SPDistributedCacheServiceInstance -Role DistributedCache
Add-SPDistributedCacheServiceInstance -Role WebFrontEndWithDistributedCache


#opções
#SingleServerFarm
#DistributedCache
#WebFrontEndWithDistributedCache

