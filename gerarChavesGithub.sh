ssh-keygen -t ed25519 -C "email"
Get-Service -Name ssh-agent | Set-Service -StartupType Manual
Start-Service ssh-agent
ssh-add C:\path....
clip < ~/.ssh/id_ed25519.pub
type id_ed25519.pub
notepad  ~/.ssh/id_ed25519.pub
