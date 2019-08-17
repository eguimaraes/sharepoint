Get-SPServer
[System.Enum]::GetNames([Microsoft.SharePoint.Administration.SPServerRole])
Set-SPServer -Identity "server" -Role "WebFrontEnd"
Get-SPTimerJob “Timer Job ID”
