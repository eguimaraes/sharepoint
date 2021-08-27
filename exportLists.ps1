 add-pssnapin Microsoft.SharePoint.PowerShell -ErrorAction Ignore
 $web=Get-SPWeb "url"
 $lists=$web.Lists
 $filtro="filtro"
 foreach ($list in $lists){ 

 if($list.Title.Contains( $filtro)){
 
 Write-Host("Exportando " + $list.Title)

 Write-Host($list.RootFolder.ServerRelativePath.ToString())

 $path=$list.RootFolder.ServerRelativePath.ToString().replace("/Lists/","");

 export-spweb -identity $web.Url -ItemUrl $list.RootFolder.ServerRelativePath -Path $PWD\$path


 
 }
 
 }
