#https://itgroove.net/mmman/2012/12/07/search-host-controller-service-in-starting-state-sharepoint-2013-8/
$acl = Get-Acl HKLM:\System\CurrentControlSet\Control\ComputerName        
$person = [System.Security.Principal.NTAccount] "Users"
$access = [System.Security.AccessControl.RegistryRights]::FullControl
$inheritance = [System.Security.AccessControl.InheritanceFlags] "ContainerInherit, ObjectInherit"
$propagation = [System.Security.AccessControl.PropagationFlags]::None         
$type = [System.Security.AccessControl.AccessControlType]::Allow         
$rule = New-Object System.Security.AccessControl.RegistryAccessRule($person, $access, $inheritance, $propagation, $type)         
$acl.AddAccessRule($rule)         
Set-Acl HKLM:\System\CurrentControlSet\Control\ComputerName $acl
$sh = Get-SPServiceInstance | ? {$_.TypeName -eq "Search Host Controller Service"}
$sh.Unprovision()         
$sh.Provision($true)
