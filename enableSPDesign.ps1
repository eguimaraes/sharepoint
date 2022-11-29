#Read more: https://www.sharepointdiary.com
#Read more: https://www.sharepointdiary.com/2018/09/sharepoint-online-enable-sharepoint-designer-using-powershell.html#ixzz7m3VyA2vR

#Config Variables
$SiteURL = "https://crescent.sharepoint.com/sites/retail"
  
Try {
    #Connect to PnP Online
    Connect-PnPOnline -Url $SiteURL -Interactive
      
    #Get the site SharePoint Designer settings
    $Site = Get-pnpsite -Includes AllowDesigner
 
    If($Site.AllowDesigner -eq $false)
    {
        #Enable SharePoint Designer
        $Site.AllowDesigner = $true
        Invoke-PnPQuery
        Write-host "SharePoint Desingner Enabled Successfully!" -f Green
    }
    Else
    {
        Write-host "SharePoint Desingner is already Enabled!" -f Yellow
    }
}
Catch {
    write-host "Error: $($_.Exception.Message)" -foregroundcolor Red
}


#Read more: https://www.sharepointdiary.com/2018/09/sharepoint-online-enable-sharepoint-designer-using-powershell.html#ixzz7m3VyA2vR
