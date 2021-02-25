#from https://veronicageek.com/sharepoint/sharepoint-2013/create-the-state-service-application-using-powershell/2018/03/

$ServiceAppName = “State Service Application”
$ServiceAppProxyName = “State Service Application Proxy”
$DBName = “SP2016_State_Service_DB”
 

#Create New State Service application
$StateServiceApp = New-SPStateServiceApplication -Name $ServiceAppName

#Create Database for State Service App
$Database = New-SPStateServiceDatabase -Name $DBName -ServiceApplication $StateServiceApp 
 
#Create Proxy for State Service
New-SPStateServiceApplicationProxy -Name $ServiceAppProxyName -ServiceApplication $StateServiceApp -DefaultProxyGroup 

#Initialize the State Service DB
Initialize-SPStateServiceDatabase -Identity $Database
