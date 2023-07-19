#https://learn.microsoft.com/en-us/powershell/module/pki/new-selfsignedcertificate?view=windowsserver2022-ps

$params = @{
    DnsName = 'www.fabrikam.com', 'www.contoso.com'
    CertStoreLocation = 'Cert:\LocalMachine\My'
}
New-SelfSignedCertificate @params

Set-Location -Path 'Cert:\LocalMachine\My'
PS Cert:\LocalMachine\My> $OldCert = (Get-ChildItem -Path E42DBC3B3F2771990A9B3E35D0C3C422779DACD7)
PS Cert:\LocalMachine\My> New-SelfSignedCertificate -CloneCert $OldCert

$params = @{
    Type = 'Custom'
    Subject = 'E=patti.fuller@contoso.com,CN=Patti Fuller'
    TextExtension = @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.4',
        '2.5.29.17={text}email=patti.fuller@contoso.com&upn=pattifuller@contoso.com' )
    KeyAlgorithm = 'RSA'
    KeyLength = 2048
    SmimeCapabilities = $true
    CertStoreLocation = 'Cert:\CurrentUser\My'
}
New-SelfSignedCertificate @params

$params = @{
    Type = 'Custom'
    Subject = 'CN=Patti Fuller,OU=UserAccounts,DC=corp,DC=contoso,DC=com'
    TextExtension = @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.2',
        '2.5.29.17={text}upn=pattifuller@contoso.com' )
    KeyUsage = 'DigitalSignature'
    KeyAlgorithm = 'RSA'
    KeyLength = 2048
    CertStoreLocation = 'Cert:\CurrentUser\My'
}
New-SelfSignedCertificate @params

$params = @{
    Type = 'Custom'
    Subject = 'CN=Patti Fuller,OU=UserAccounts,DC=corp,DC=contoso,DC=com'
    TextExtension @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.2',
        '2.5.29.17={text}upn=pattifuller@contoso.com' )
    KeyUsage = 'DigitalSignature'
    KeyAlgorithm = 'ECDSA_nistP256'
    CurveExport = 'CurveName'
    CertStoreLocation = 'Cert:\CurrentUser\My'
}
New-SelfSignedCertificate @params


$params = @{
    Type = 'Custom'
    Provider = 'Microsoft Platform Crypto Provider'
    Subject = 'CN=Patti Fuller'
    TextExtension = @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.2',
        '2.5.29.17={text}upn=pattifuller@contoso.com' )
    KeyExportPolicy = 'NonExportable'
    KeyUsage = 'DigitalSignature'
    KeyAlgorithm = 'RSA'
    KeyLength = 2048
    CertStoreLocation = 'Cert:\CurrentUser\My'
}
New-SelfSignedCertificate @params

$params = @{
    Type = 'Custom'
    Container = 'test*'
    Subject = 'CN=Patti Fuller'
    TextExtension = @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.2',
        '2.5.29.17={text}upn=pattifuller@contoso.com' )
    KeyUsage = 'DigitalSignature'
    KeyAlgorithm = 'RSA'
    KeyLength = 2048
    NotAfter = (Get-Date).AddMonths(6)
}
New-SelfSignedCertificate @params

$params = @{
    Type = 'Custom'
    Subject = 'E=patti.fuller@contoso.com,CN=Patti Fuller'
    TextExtension = @(
        '2.5.29.37={text}1.3.6.1.5.5.7.3.4',
        '2.5.29.17={text}email=patti.fuller@contoso.com&email=pattifuller@contoso.com' )
    KeyAlgorithm = 'RSA'
    KeyLength = 2048
    SmimeCapabilities = $true
    CertStoreLocation = 'Cert:\CurrentUser\My'
}
New-SelfSignedCertificate @params

$params = @{
    Subject = 'localhost'
    TextExtension = @('2.5.29.17={text}DNS=localhost&IPAddress=127.0.0.1&IPAddress=::1')
}
New-SelfSignedCertificate @params


New-SelfSignedCertificate
   [-SecurityDescriptor <FileSecurity>]
   [-TextExtension <String[]>]
   [-Extension <X509Extension[]>]
   [-HardwareKeyUsage <HardwareKeyUsage[]>]
   [-KeyUsageProperty <KeyUsageProperty[]>]
   [-KeyUsage <KeyUsage[]>]
   [-KeyProtection <KeyProtection[]>]
   [-KeyExportPolicy <KeyExportPolicy[]>]
   [-KeyLength <Int32>]
   [-KeyAlgorithm <String>]
   [-SmimeCapabilities]
   [-ExistingKey]
   [-KeyLocation <String>]
   [-SignerReader <String>]
   [-Reader <String>]
   [-SignerPin <SecureString>]
   [-Pin <SecureString>]
   [-KeyDescription <String>]
   [-KeyFriendlyName <String>]
   [-Container <String>]
   [-Provider <String>]
   [-CurveExport <CurveParametersExportType>]
   [-KeySpec <KeySpec>]
   [-Type <CertificateType>]
   [-FriendlyName <String>]
   [-NotAfter <DateTime>]
   [-NotBefore <DateTime>]
   [-SerialNumber <String>]
   [-Subject <String>]
   [-DnsName <String[]>]
   [-SuppressOid <String[]>]
   [-HashAlgorithm <String>]
   [-AlternateSignatureAlgorithm]
   [-TestRoot]
   [-Signer <Certificate>]
   [-CloneCert <Certificate>]
   [-CertStoreLocation <String>]
   [-WhatIf]
   [-Confirm]
   [<CommonParameters>]

