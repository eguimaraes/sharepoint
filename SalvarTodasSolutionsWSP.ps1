add-pssnapin microsoft.sharepoint.powershell;

$solutions=get-spsolution;

foreach ($solution in $solutions)
{


Write-Host("Salvando "+$solution.name);

$nome=$PWD.Path+"\"+$solution.name;

Write-Host($name);
$solution.SolutionFile.SaveAs($nome)

}
