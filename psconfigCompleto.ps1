#original em https://blog.stefan-gossner.com/2015/08/20/why-i-prefer-psconfigui-exe-over-psconfig-exe/
#https://learn.microsoft.com/en-us/powershell/module/sharepoint-server/install-spapplicationcontent?view=sharepoint-server-ps
PSConfig.exe -cmd upgrade -inplace b2b -wait -cmd applicationcontent -install -cmd installfeatures -cmd secureresources -cmd services -install
Install-SPApplicationContent
