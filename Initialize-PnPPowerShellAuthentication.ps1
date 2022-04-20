#https://docs.microsoft.com/en-us/sharepoint/dev/transform/modernize-scanner
Initialize-PnPPowerShellAuthentication -ApplicationName ModernizationScannerApp -Tenant contoso.onmicrosoft.com -Scopes "SPO.Sites.FullControl.All","MSGraph.Group.Read.All"  -OutPath c:\temp -CertificatePassword (ConvertTo-SecureString -String "password" -AsPlainText -Force)
