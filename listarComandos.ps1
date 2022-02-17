Get-Command –PSSnapin “Microsoft.SharePoint.PowerShell” | select name, definition | fl > $PWD\comandos.txt
