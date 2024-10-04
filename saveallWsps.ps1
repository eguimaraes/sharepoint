# PowerShell Script to Save All Solutions in a SharePoint On-Premises Farm
$solutions = Get-SPSolution
$savePath = "C:\Backup\SharePointSolutions\"
 
if (-Not (Test-Path -Path $savePath)) {
    New-Item -ItemType Directory -Path $savePath
}
 
foreach ($solution in $solutions) {
    $fileName = $solution.SolutionFile.Name
    $solution.SolutionFile.SaveAs("$savePath\$fileName")
    Write-Host "Saved: $fileName"
}