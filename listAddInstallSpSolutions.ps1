$arquivos=ls *.wsp
foreach ($arquivo in $arquivos){
Add-SPSolution -LiteralPath  $PWD.tostring()+"\"+$arquivo.name.tostring()
Install-SPSolution -Identity $arquivo.name.tostring() GACDeployment -AllWebApplications
}
