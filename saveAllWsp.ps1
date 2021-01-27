#Save all WSP
(Get-SPFarm).Solutions | ForEach-Object{$var = (Get-Location).Path + “\” + $_.Name; $_.SolutionFile.SaveAs($var)}
