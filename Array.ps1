$data = @()
$data.count
PS> $data = @('Zero','One','Two','Three')
PS> $data.count
4

PS> $data
Zero
One
Two
Three

$data = @(
    'Zero'
    'One'
    'Two'
    'Three'
)

$data = 'Zero','One','Two','Three'

$data = Write-Output Zero One Two Three
PS> $data = 'Zero','One','Two','Three'
PS> $data[0]
Zero

PS> $data[1]
One

PS> $data[0,2,3]
Zero
Two
Three

PS> $data[3,0,3]
Three
Zero
Three

PS> $data[1..3]
One
Two
Three

PS> $null -eq $data[9000]
True

