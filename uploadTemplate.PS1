#Read more: https://www.sharepointdiary.com/2019/01/import-list-template-in-sharepoint-online-using-powershell.html#ixzz7fQWAoUaX
#Load SharePoint CSOM Assemblies
Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.dll"
Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"
 
#Function to Upload a list template To SharePoint Online using powershell
Function Upload-SPOListTemplate
{
    param
    (
        [string]$SiteURL  = $(throw "Enter the Site URL!"),
        [string]$ListTemplateName = $(throw "Enter the List Template Name!"),
        [string]$ListTemplateFile = $(throw "Enter the File Name to Upload List Template!")
    )
    Try {
        #Get Credentials to connect
        $Cred= Get-Credential
        $Credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($Cred.Username, $Cred.Password)
  
        #Setup the context
        $Ctx = New-Object Microsoft.SharePoint.Client.ClientContext($SiteURL)
        $Ctx.Credentials = $Credentials
         
        #Get the "List Templates" Library
        $List= $Ctx.web.Lists.GetByTitle("List Template Gallery")
        $ListTemplates = $List.GetItems([Microsoft.SharePoint.Client.CamlQuery]::CreateAllItemsQuery())
        $Ctx.Load($ListTemplates)
        $Ctx.ExecuteQuery()
 
        #Check if the Given List Template already exists
        $ListTemplate = $ListTemplates | where { $_["TemplateTitle"] -eq $ListTemplateName }
 
        If($ListTemplate -eq $Null)
        {
            #Get the file from disk
            $FileStream = ([System.IO.FileInfo] (Get-Item $ListTemplateFile)).OpenRead()
            #Get File Name from source file path
            $TemplateFileName = Split-path $ListTemplateFile -leaf
    
            #Upload the File to SharePoint Library
            $FileCreationInfo = New-Object Microsoft.SharePoint.Client.FileCreationInformation
            $FileCreationInfo.Overwrite = $true
            $FileCreationInfo.ContentStream = $FileStream
            $FileCreationInfo.URL = $TemplateFileName
            $FileUploaded = $List.RootFolder.Files.Add($FileCreationInfo)
            $Ctx.Load($FileUploaded)
            $Ctx.ExecuteQuery()
             
            #Set Metadata of the File
            $ListItem = $FileUploaded.ListItemAllFields
            $Listitem["TemplateTitle"] = $ListTemplateName
            $Listitem["FileLeafRef"] = $ListTemplateName
            $ListItem.Update()
            $Ctx.ExecuteQuery()
  
            #Close file stream
            $FileStream.Close()
 
            write-host -f Green "List Template '$ListTemplateFile' Uploaded to $SiteURL"
        }
        else
        {
            Write-host -f Yellow "List Template '$ListTemplateName' Already Exists"
        }
    }
    Catch {
        write-host -f Red "Error Uploading List Template!" $_.Exception.Message
    }
}
 
#Variables
$SiteURL = "https://Crescent.sharepoint.com/"
$ListTemplateName= "Projects Template V4"
$ListTemplateFile = "C:\Temp\CrescentProject.stp"
 
#Call the function to Download the list template
Upload-SPOListTemplate -SiteURL $SiteURL -ListTemplateName $ListTemplateName -ListTemplateFile $ListTemplateFile


#Read more: https://www.sharepointdiary.com/2019/01/import-list-template-in-sharepoint-online-using-powershell.html#ixzz7fQWAoUaX
