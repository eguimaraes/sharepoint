Get-SPContentDatabase | ?{$_.NeedsUpgrade –eq $true} | Upgrade-SPContentDatabase -Confirm:$false
psconfig.exe -cmd upgrade -inplace b2b
