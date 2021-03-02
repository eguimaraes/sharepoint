$hostHeader = "intranet.ekis.com.br"
$url = "http://intranet.ekis.com.br"
$appPoolName = "ekisIntranet"
$appPoolAccount = Get-SPManagedAccount "ekis\adm"
New-SPWebApplication -Name $name -Port $port -HostHeader $hostHeader -URL $url
-ApplicationPool $appPoolName
-ApplicationPoolAccount $appPoolAccount
