#Saiba mais em https://blogs.technet.microsoft.com/sharepoint_foxhole/2010/06/21/disableloopbackcheck-lets-do-it-the-right-way/
New-ItemProperty HKLM:\System\CurrentControlSet\Control\Lsa -Name "DisableLoopbackCheck" -Value "1" -PropertyType dword
