New-SPWebApplication -Name "PortalName" -URL "http://portsl:portNr" -ApplicationPool "WebAppName" -ApplicationPoolAccount (Get-SPManagedAccount "domain\user")
