Remove-SPDistributedCacheServiceInstance
$SPFarm = Get-SPFarm
 $cacheClusterName = "SPDistributedCacheCluster_" + $SPFarm.Id.ToString()
 $cacheClusterManager = [Microsoft.SharePoint.DistributedCaching.Utilities.SPDistributedCacheClusterInfoManager]::Local
 $cacheClusterInfo = $cacheClusterManager.GetSPDistributedCacheClusterInfo($cacheClusterName);
 $instanceName ="SPDistributedCacheService Name=AppFabricCachingService"
 $serviceInstance = Get-SPServiceInstance | ? {($_.Service.Tostring()) -eq $instanceName -and ($_.Server.Name) -eq $env:computername}
 $serviceInstance.Delete()
