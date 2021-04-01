#https://www.sharepointdiary.com/2019/05/sharepoint-online-change-ui-modern-experience-classic-using-powershell.html
#Load SharePoint CSOM Assemblies
Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.dll"
Add-Type -Path "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\16\ISAPI\Microsoft.SharePoint.Client.Runtime.dll"
 
#Function to Enable or Disable Feature in SharePoint Online
Function Set-SPOFeatureStatus
{
    [CMDLetBinding()]
    Param
    (
        [Parameter(Mandatory=$True)][Microsoft.SharePoint.Client.ClientContext]$Context,
        [Parameter(Mandatory=$True)][GUID]$FeatureGUID,
        [Parameter(Mandatory=$True)][ValidateSet('Site','Web')][String]$Scope,
        [Parameter(Mandatory=$True)][ValidateSet('Enable','Disable')][String]$Status
    )
    If($Scope -eq "Site")
    {
        #Get the Site
        $Site = $Context.Site
        #Get the Feature Status
        $FeatureStatus =  $Site.Features.GetById($FeatureGuid)
        $FeatureStatus.Retrieve("DefinitionId")
        $Context.Load($FeatureStatus)
        $Context.ExecuteQuery()
 
        If($Status -eq "Enable")
        {
            #Activate the feature if its not enabled already
            If($FeatureStatus.DefinitionId -eq $null)
            {
                #Enable the Feature
                $Site.Features.Add($FeatureGuid, $True, [Microsoft.SharePoint.Client.FeatureDefinitionScope]::None) | Out-Null
                $Context.ExecuteQuery()
                Write-host -f Green "`tFeature has been Enabled at Site Level!"
            }
            Else
            {
                Write-host -f Yellow "`tFeature is Already Enabled at Site Level!"
            }
        }
        Elseif($Status -eq "Disable")
        {
            #De-Activate the feature if its enabled already
            If($FeatureStatus.DefinitionId -ne $null)
            {
                #Disable feature
                $Site.Features.Remove($FeatureGuid, $True) | Out-Null
                $Context.ExecuteQuery()
                Write-host -f Green "`tFeature has been Disabled at Site Level!"
            }
            Else
            {
                Write-host -f Yellow "`tFeature is Already Disabled at Site Level!"
            }
        }
    }
    ElseIf($Scope -eq "Web")
    {
        #Get the web
        $Web = $Context.Web
        #Get the Feature Status
        $FeatureStatus =  $Web.Features.GetById($FeatureGUID)
        $FeatureStatus.Retrieve("DefinitionId")
        $Context.Load($FeatureStatus)
        $Context.ExecuteQuery()
     
        If($Status -eq "Enable")
        {
            #Activate the feature if its not enabled already
            If($FeatureStatus.DefinitionId -eq $null)
            {
                #Enable Feature
                $Web.Features.Add($FeatureGUID, $True, [Microsoft.SharePoint.Client.FeatureDefinitionScope]::None)| Out-Null
                $Context.ExecuteQuery()
                Write-host -f Green "`tFeature has been Enabled at Web Level!"
            }
            Else
            {
                Write-host -f Yellow "`tFeature is Already Enabled at Web Level!"
            }
        }
        ElseIf($Status -eq "Disable")
        {
            #De-Activate the feature if its enabled already
            If($FeatureStatus.DefinitionId -ne $null)
            {
                #Disable Classic Experience feature, which Enables Modern UI
                $Web.Features.Remove($FeatureGUID, $True) | Out-Null               
                $Context.ExecuteQuery()
                Write-host -f Green "`tFeature has been Disabled at Web Level!"  
            }
            Else
            {
                Write-host -f Yellow "`tFeature is Already Disabled at Web Level!"
            }
        }
    }
}
 
#Function to set UI  experience to Modern or Classic at Site or Web Level
Function Set-SPOUIExperience
{
    [CMDLetBinding()]
    Param
    (
        [String]$SiteURL, 
        [Parameter(Mandatory=$True)][ValidateSet('Modern','Classic')][String]$Experience,
        [Parameter(Mandatory=$True)][ValidateSet('Site','Web')][String]$Scope
    )
 
    Try {
        #Setup the context
        $Ctx = New-Object Microsoft.SharePoint.Client.ClientContext($SiteURL)
        $Ctx.Credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($Cred.Username, $Cred.Password)
 
        #Site Scoped Feature "EnableDefaultListLibrarExperience" - Classic Experience
        $SiteFeatureGuid = New-Object System.Guid "E3540C7D-6BEA-403C-A224-1A12EAFEE4C4"
         
        #Web Scoped Feature "EnableDefaultListLibrarExperience" - Classic Experience
        $WebFeatureGUID = New-Object System.Guid "52E14B6F-B1BB-4969-B89B-C4FAA56745EF"
 
        #Enable or Disable Modern Experience based on the parameters
        If($Scope -eq "Site")
        {
            #Get the web
            $Web = $Ctx.Web
            $Ctx.Load($Web)
            $Ctx.ExecuteQuery()
 
            If($Experience -eq "Modern")
            { 
                #Disable Classic Experience feature at site level
                Write-host -f Green "Enabling Modern Experience at the Site Collection by Disabling Classic UI Feature..."
                Set-SPOFeatureStatus -Context $Ctx -FeatureGUID $SiteFeatureGuid -Scope Site -Status Disable
 
                #Disable Classic Experience feature at web level
                Set-SPOUIExperience $Web.URL -Experience $Experience -Scope Web
 
                #Process each subsite in the site
                $Subsites = $Web.Webs
                $Ctx.Load($Subsites)
                $Ctx.ExecuteQuery()        
                Foreach ($SubSite in $Subsites)
                {
                    #Call the function Recursively
                    Set-SPOUIExperience $SubSite.URL -Experience $Experience -Scope Web
                }
            }
            ElseIf($Experience -eq "Classic")
            {
                #Enable Classic Experience feature at site level
                Write-host -f Green "Enabling Classic Experience at the Site Collection..."
                Set-SPOFeatureStatus -Context $Ctx -FeatureGUID $SiteFeatureGuid -Scope Site -Status Enable                
                 
                #Enable Classic Experience feature at web level
                Set-SPOUIExperience $Web.URL -Experience $Experience -Scope Web
 
                #Process each subsite in the site
                $Subsites = $Web.Webs
                $Ctx.Load($Subsites)
                $Ctx.ExecuteQuery()        
                Foreach ($SubSite in $Subsites)
                {
                    #Call the function Recursively
                    Set-SPOUIExperience $SubSite.URL -Experience $Experience -Scope Web
                }
            }
        }
        ElseIf($Scope -eq "Web")
        {
            If($Experience -eq "Modern")
            {
                #Disable Classic Experience
                Write-host -f Green "Enabling Modern Experience at the Web $($SiteURL) by Disabling Classic UI Feature..."
                Set-SPOFeatureStatus -Context $Ctx -FeatureGUID $WebFeatureGUID -Scope Web -Status Disable                
            }
            ElseIf($Experience -eq "Classic")
            {
                #Enable Classic Experience
                Write-host -f Green "Enabling Classic Experience at the Web $($SiteURL)"
                Set-SPOFeatureStatus -Context $Ctx -FeatureGUID $WebFeatureGUID -Scope Web -Status Enable
            }
        }
    }
    Catch {
        write-host -f Red "Error:" $_.Exception.Message
    }
}
 
#Set Variable
$SiteURL = "https://crescent.sharepoint.com/sites/marketing"
 
#Get Credentials to connect
$Cred = Get-Credential
 
#Call the function to set UI experience
Set-SPOUIExperience -SiteURL $SiteURL -Experience Modern -Scope Site
