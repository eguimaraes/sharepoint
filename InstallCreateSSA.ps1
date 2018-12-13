# Based on scripts at http://www.harbar.net/articles/sp2013mt.aspx
# https://www.toddklindt.com/blog/Lists/Posts/Post.aspx?ID=378

# Get App Pool
$saAppPoolName = "Default SharePoint Service App Pool"

# Search Specifics, we are single server farm
$searchServerName = (Get-ChildItem env:computername).value
$serviceAppName = "Search Service Application"
$searchDBName = "SearchService_DB"


# Grab the Appplication Pool for Service Application Endpoint
$saAppPool = Get-SPServiceApplicationPool $saAppPoolName

# Start Search Service Instances
Write-Host "Starting Search Service Instances..."
Start-SPEnterpriseSearchServiceInstance $searchServerName
Start-SPEnterpriseSearchQueryAndSiteSettingsServiceInstance $searchServerName

# Create the Search Service Application and Proxy
Write-Host "Creating Search Service Application and Proxy..."
$searchServiceApp = New-SPEnterpriseSearchServiceApplication -Name $serviceAppName -ApplicationPool $saAppPoolName -DatabaseName $searchDBName
$searchProxy = New-SPEnterpriseSearchServiceApplicationProxy -Name "$serviceAppName Proxy" -SearchApplication $searchServiceApp

# Clone the default Topology (which is empty) and create a new one and then activate it
Write-Host "Configuring Search Component Topology..."
$clone = $searchServiceApp.ActiveTopology.Clone()
$searchServiceInstance = Get-SPEnterpriseSearchServiceInstance
New-SPEnterpriseSearchAdminComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance
New-SPEnterpriseSearchContentProcessingComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance
New-SPEnterpriseSearchAnalyticsProcessingComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance 
New-SPEnterpriseSearchCrawlComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance 
New-SPEnterpriseSearchIndexComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance
New-SPEnterpriseSearchQueryProcessingComponent –SearchTopology $clone -SearchServiceInstance $searchServiceInstance
$clone.Activate()


Write-Host "Search Done!"
