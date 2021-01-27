Get-ChildItem | ForEach-Object{Add-SPSolution -LiteralPath $_.Fullname}
