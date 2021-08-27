$webUrl="url"
$filtro ="dir like"
$files=dir $filtro
foreach ($file in $files) {Import-SPWeb $webUrl -Path $PWD\$file -UpdateVersions Ignore}
