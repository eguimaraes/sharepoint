add-pssnapin microsoft.sharepoint.powershell;
(Get-SPFarm).Solutions | ForEach-Object{$var = (Get-Location).Path + “\” + $_.Name; $_.SolutionFile.SaveAs($var)}
