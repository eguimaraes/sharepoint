$arquivos=ls *.wsp
foreach ($arquivo in $arquivos){
Add-SPSolution -LiteralPath  $arquivo.FullName+"\"+$arquivo.name.tostring()
Install-SPSolution -Identity $arquivo.name -GACDeployment -AllWebApplications
}
