#https://docs.microsoft.com/en-us/powershell/module/sharepoint-server/set-spmanagedaccount?view=sharepoint-ps#:~:text=The%20Set%2DSPManagedAccount%20cmdlet%20sets,Use%20the%20default%20parameter%20set.
$m = Get-SPManagedAccount -Identity "DOMAINx\UserY"
Set-SPManagedAccount -Identity $m -AutoGeneratePassword true
