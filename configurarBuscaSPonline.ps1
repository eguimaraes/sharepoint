#https://microsoft-search.github.io/pnp-modern-search/installation/
#https://github.com/microsoft-search/pnp-modern-search/releases
#https://pnp.github.io/powershell/index.html



Install-Module -Name PnP.PowerShell
connect-PnPOnline
Set-PnPSearchSettings -SearchScope -Site

