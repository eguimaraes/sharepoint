#Original em https://blogs.technet.microsoft.com/fromthefield/2016/01/19/o365-create-labels-on-managed-metadata-terms-using-csom-in-powershell-from-a-csv-file/

$User = "<Tenant Admin>"

$TenantURL = "<URL of SharePoint Admin Center>"

$Site = "<URL of Site Collection that exists in the tenant>"

$GroupName = "<Term Group Name that contains the target Term Set>"

$TermSetName = "<Target Term Set Name>"

 

#Add references to SharePoint client assemblies and authenticate to Office 365 site - required for CSOM

Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.dll"

Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"

Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.Taxonomy.dll"

$Password = Read-Host -Prompt "Please enter your password" -AsSecureString

try

{

 

#Bind to the Managed Metadata Service within the target instance of SPO

$Context = New-Object Microsoft.SharePoint.Client.ClientContext($Site)

$Creds = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($User,$Password)

$Context.Credentials = $Creds

$MMS = [Microsoft.SharePoint.Client.Taxonomy.TaxonomySession]::GetTaxonomySession($Context)

$Context.Load($MMS)

$Context.ExecuteQuery()

 

#Retrieve all of the Term Stores from the Managed Metadata Service

$TermStores = $MMS.TermStores

$Context.Load($TermStores)

$Context.ExecuteQuery()

 

#Bind to the Term Store you want to perform configurations against

$TermStore = $TermStores[0]

$Context.Load($TermStore)

$Context.ExecuteQuery()

 

#Bind to the Term Group you want to perform configurations against

$Group = $TermStore.Groups.GetByName($GroupName)

$Context.Load($Group)

$Context.ExecuteQuery()

 

#Bind to Term Set you want to perform configurations against

$TermSet = $Group.TermSets.GetByName($TermSetName)

$Context.Load($TermSet)

$Context.ExecuteQuery()

 

#Bind to Terms within the Term Set

$Terms = $TermSet.Terms

$Context.Load($Terms)

$Context.ExecuteQuery()

 

#Specify path to CSV input file that contains;

#The names of the Terms within the Term Set to configure,

#The values for the "Other Labels" property to apply for each Term in the Term Set

$path = "<Specify path to CSV file>"

 

#Import and load the CSV input file into the PowerShell Session

$csv = import-csv -path $path

 

#Process entries in the CSV

foreach($line in $csv){

 

#Get Terms by Name using the values supplied in the "TermNames" column of the CSV file.

$Term = $Terms.GetByName($line.TermNames)

$Context.Load($Term)

$Context.ExecuteQuery()

 

#Add "Other Labels" to Terms using the values supplied in the ("TermLabel1","TermLabel2" & "TermLabel3" columns of the CSV file.

$AddTermLabel = $term.CreateLabel($line.TermLabel1, 1033, $False)

$AddTermLabel = $term.CreateLabel($line.TermLabel2, 1033, $False)

$AddTermLabel = $term.CreateLabel($line.TermLabel3, 1033, $False)

$Context.Load($Terms)

$Context.ExecuteQuery()

}

}

 

catch

{

    write-host "Caught an exception:" -ForegroundColor Red

    write-host "Exception Type: $($_.Exception.GetType().FullName)" -ForegroundColor Red

    write-host "Exception Message: $($_.Exception.Message)" -ForegroundColor Red

}

finally

{

    write-host ""

    write-host "Term Labels have been successfully updated on the target Terms" -ForegroundColor Green

} 

 

 
