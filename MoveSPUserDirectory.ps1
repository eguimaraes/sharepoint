#https://docs.microsoft.com/en-us/powershell/module/sharepoint-server/move-spuser?view=sharepoint-ps
$url="http://"
$users=get-spuser -web $url

foreach($user in $users){Move-SPUser -Identity $user -NewAlias $user.UserLogin.replace("i\:0\#\.w\|","") -IgnoreSID -confirm:$false}






