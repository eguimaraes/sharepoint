#https://docs.microsoft.com/en-us/powershell/module/sharepoint-server/new-spwebapplication?view=sharepoint-server-ps
New-SPWebApplication -Name "Contoso Internet Site" -Port 80 -HostHeader sharepoint.contoso.com -URL "http://www.contoso.com" -ApplicationPool "ContosoAppPool" -ApplicationPoolAccount (Get-SPManagedAccount "DOMAIN\wa")
New-SPWebApplication -Name "Contoso Internet Site" -Port 443 -SecureSocketsLayer -HostHeader sharepoint.contoso.com -URL "https://www.contoso.com:443" -ApplicationPool "ContosoAppPool" -ApplicationPoolAccount (Get-SPManagedAccount "DOMAIN\wa")
$ap = New-SPAuthenticationProvider
New-SPWebApplication -Name "Contoso Internet Site" -URL "https://www.contoso.com"  -Port 443 
-ApplicationPool "ContosoAppPool" 
-ApplicationPoolAccount (Get-SPManagedAccount "DOMAIN\wa") 
-AuthenticationProvider $ap -SecureSocketsLayer

New-SPWebApplication
   -Name <String>
   -ApplicationPool <String>
   [-ApplicationPoolAccount <SPProcessAccountPipeBind>]
   [-ServiceApplicationProxyGroup <SPServiceApplicationProxyGroupPipeBind>]
   [-SecureSocketsLayer]
   [-HostHeader <String>]
   [-Certificate <SPServerCertificatePipeBind>]
   [-UseServerNameIndication]
   [-AllowLegacyEncryption]
   [-Port <UInt32>]
   [-AllowAnonymousAccess]
   [-Path <String>]
   [-Url <String>]
   [-AuthenticationMethod <String>]
   [-AuthenticationProvider <SPAuthenticationProviderPipeBind[]>]
   [-AdditionalClaimProvider <SPClaimProviderPipeBind[]>]
   [-SignInRedirectURL <String>]
   [-SignInRedirectProvider <SPTrustedIdentityTokenIssuerPipeBind>]
   [-UserSettingsProvider <SPUserSettingsProviderPipeBind>]
   [-DatabaseCredentials <PSCredential>]
   [-DatabaseServer <String>]
   [-DatabaseName <String>]
   [-AssignmentCollection <SPAssignmentCollection>]
   [-WhatIf]
   [-Confirm]
   [<CommonParameters>]
   
   
