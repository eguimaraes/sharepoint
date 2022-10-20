# Path to the public key of the Azure AD SAML signing certificate (self-signed), downloaded from the Enterprise application in the Azure AD portal
$signingCert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2("C:\AAD app\SharePoint corporate farm.cer")
# Unique realm (corresponds to the "Identifier (Entity ID)" in the Azure AD Enterprise application)
$realm = "urn:sharepoint:federation"
# Login URL copied from the Azure AD enterprise application. Make sure to replace "saml2" with "wsfed" at the end of the URL:
$loginUrl = "https://login.microsoftonline.com/dc38a67a-f981-4e24-ba16-4443ada44484/wsfed"

# Define the claim types used for the authorization
$userIdentifier = New-SPClaimTypeMapping -IncomingClaimType "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name" -IncomingClaimTypeDisplayName "name" -LocalClaimType "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn"
$role = New-SPClaimTypeMapping "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" -IncomingClaimTypeDisplayName "Role" -SameAsIncoming

# Let SharePoint trust the Azure AD signing certificate
New-SPTrustedRootAuthority -Name "Azure AD signing certificate" -Certificate $signingCert

# Create a new SPTrustedIdentityTokenIssuer in SharePoint
$trust = New-SPTrustedIdentityTokenIssuer -Name "AzureADTrust" -Description "Azure AD" -Realm $realm -ImportTrustCertificate $signingCert -ClaimsMappings $userIdentifier, $role -SignInUrl $loginUrl -IdentifierClaim $userIdentifier.InputClaimType

# This script creates a new web application and sets Windows and Azure AD authentication on the Default zone
# URL of the SharePoint site federated with Azure AD
$trustedSharePointSiteUrl = "https://spsites.contoso.local/"
$applicationPoolManagedAccount = "Contoso\spapppool"

$winAp = New-SPAuthenticationProvider -UseWindowsIntegratedAuthentication -DisableKerberos:$true
$sptrust = Get-SPTrustedIdentityTokenIssuer "AzureADTrust"
$trustedAp = New-SPAuthenticationProvider -TrustedIdentityTokenIssuer $sptrust    

New-SPWebApplication -Name "SharePoint - Azure AD" -Port 443 -SecureSocketsLayer -URL $trustedSharePointSiteUrl -ApplicationPool "SharePoint - Azure AD" -ApplicationPoolAccount (Get-SPManagedAccount $applicationPoolManagedAccount) -AuthenticationProvider $winAp, $trustedAp

# This script extends an existing web application to set Azure AD authentication on a new zone
# URL of the default zone of the web application
$webAppDefaultZoneUrl = "http://spsites/"
# URL of the SharePoint site federated with ADFS
$trustedSharePointSiteUrl = "https://spsites.contoso.local/"
$sptrust = Get-SPTrustedIdentityTokenIssuer "AzureADTrust"
$ap = New-SPAuthenticationProvider -TrustedIdentityTokenIssuer $sptrust
$wa = Get-SPWebApplication $webAppDefaultZoneUrl

New-SPWebApplicationExtension -Name "SharePoint - Azure AD" -Identity $wa -SecureSocketsLayer -Zone Internet -Url $trustedSharePointSiteUrl -AuthenticationProvider $ap

New-SelfSignedCertificate -DnsName "spsites.contoso.local" -CertStoreLocation "cert:\LocalMachine\My"

