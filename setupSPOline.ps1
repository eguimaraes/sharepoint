 $AdminSiteURL="https://tenant-admin.sharepoint.com/"
 $SiteURL="site collection URL "
    
 $Cred = Get-Credential
 Connect-SPOService -URL $AdminSiteURL -Credential $Cred
    
 Set-SPOSite -Identity $SiteURL -DenyAddAndCustomizePages $False
