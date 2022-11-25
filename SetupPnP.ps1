Install-Module -Name "PnP.PowerShell"
Install-Module -Name "Microsoft.PowerShell.SecretManagement" -AllowPrerelease
Install-Module -Name "Microsoft.PowerShell.SecretStore" -AllowPrerelease
Register-SecretVault -Name "SecretStore" -ModuleName "Microsoft.PowerShell.SecretStore" -DefaultVault
Set-SecretStoreConfiguration -Authentication None
Set-Secret -Name [yourlabel] -Secret (Get-Credential)
