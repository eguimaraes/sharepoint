$webapp=Get-SPWebApplication
$solutions=ls *.wsp

foreach ($solution in $solutions){

write-host("Instalando $solution")

Add-SPSolution -LiteralPath $solution


}


