$programFiles = [environment]::getfolderpath("programfiles")

add-type -Path $programFiles'\SharePoint Online Management Shell\' + `
 Microsoft.Online.SharePoint.PowerShell\Microsoft.SharePoint.Client.dll'

Write-Host 'To disable sideLoading, enter Site Url, username and password'
 
$siteurl = Read-Host 'Site Url'
 
$username = Read-Host "User Name"
 
$password = Read-Host -AsSecureString 'Password'
 
if ($siteurl -eq '') {
    $siteurl = 'https://mytenant.sharepoint.com/sites/mysite'
    $username = 'me@mytenant.onmicrosoft.com'
    $password = ConvertTo-SecureString -String 'mypassword!' `
      -AsPlainText -Force
}
 
Try {
    [Microsoft.SharePoint.Client.ClientContext]$cc = `
    New-Object Microsoft.SharePoint.Client.ClientContext($siteurl)
 
    [Microsoft.SharePoint.Client.SharePointOnlineCredentials]$spocreds = `
    New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($username, $password)
 
    $cc.Credentials = $spocreds
 
    $site = $cc.Site;
    
    $sideLoadingEnabled = `
    [Microsoft.SharePoint.Client.appcatalog]::IsAppSideloadingEnabled($cc);
    
    $cc.ExecuteQuery()
    
    if($sideLoadingEnabled.value -eq $false)
    {
      Write-Host -ForegroundColor Green `
        'SideLoading is alreday disabled on site' $siteurl
        }
       else
       {
      Write-Host -ForegroundColor Yellow `
        'Disabling SideLoading feature on site' $siteurl
      $sideLoadingGuid = `
        new-object System.Guid "AE3A1339-61F5-4f8f-81A7-ABD2DA956A7D"
      $site.Features.Remove($sideLoadingGuid, $true);
      $cc.ExecuteQuery();
      Write-Host -ForegroundColor Green `
        'SideLoading disabled on site' $siteurl
        }

} catch {
    Write-Host -ForegroundColor Red `
      'Error encountered when trying to disable side loading features' `
      $siteurl, ':' $Error[0].ToString();
}
