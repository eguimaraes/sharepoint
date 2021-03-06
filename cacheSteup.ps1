Get-SPDistributedCacheClientSetting -ContainerType DistributedLogonTokenCache
$settings = Get-SPDistributedCacheClientSetting -ContainerType DistributedLogonTokenCache
$settings.MaxConnectionsToServer = 10
Set-SPDistributedCacheClientSetting -ContainerType DistributedLogonTokenCache -DistributedCacheClientSettings $settings
Stop-SPDistributedCacheServiceInstance -Graceful
Update-SPDistributedCacheSize -CacheSizeInMB CacheSize
