Enable-SPSessionStateService -DefaultProvision
Enable-SPSessionStateService -DatabaseName "Session State Database" -DatabaseServer "localhost" -SessionTimeout 120
