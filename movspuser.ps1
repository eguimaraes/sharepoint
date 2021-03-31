#https://docs.microsoft.com/en-us/powershell/module/sharepoint-server/move-spuser?view=sharepoint-ps

$user = Get-SPUser -Identity "DOMAIN\JaneDoe" -Web https://webUrl
Move-SPUser -Identity $user -NewAlias "Domain\JaneSmith" -IgnoreSid

$user = Get-SPUser -Identity "DomainA\JaneDoe" -Web https://webUrl
Move-SPUser -Identity $user -NewAlias "DomainB\JaneDoe"

$user = Get-SPUser -Identity "i:0#.w|DOMAIN\JaneDoe" -Web https://webUrl
Move-SPUser -Identity $user -NewAlias "i:0#.w|Domain\JaneSmith" -IgnoreSid
