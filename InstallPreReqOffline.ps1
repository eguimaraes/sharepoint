New-ItemProperty HKLM:\System\CurrentControlSet\Control\Lsa -Name "DisableLoopbackCheck" -Value "1" -PropertyType dword
$PreRequsInstallerPath= "E:"
$PreRequsFilesPath = "C:\Prereqs"  
Start-Process "$PreRequsInstallerPath\PrerequisiteInstaller.exe" -Wait -ArgumentList "  ` 
              /SQLNCli:`"$PreRequsFilesPath\sqlncli.msi`" ` 
              /idfx11:`"$PreRequsFilesPath\MicrosoftIdentityExtensions-64.msi`" ` 
              /Sync:`"$PreRequsFilesPath\Synchronization.msi`" `                                                                                  
              /AppFabric:`"$PreRequsFilesPath\WindowsServerAppFabricSetup_x64.exe`" ` 
              /kb3092423:`"$PreRequsFilesPath\AppFabric-KB3092423-x64-ENU.exe`" ` 
              /MSIPCClient:`"$PreRequsFilesPath\setup_msipc_x64.exe`" ` 
              /wcfdataservices56:`"$PreRequsFilesPath\WcfDataServices.exe`" ` 
              /odbc:`"$PreRequsFilesPath\msodbcsql.msi`" ` 
              /msvcrt11:`"$PreRequsFilesPath\vc_redist.x64.exe`" ` 
              /msvcrt14:`"$PreRequsFilesPath\vcredist_x64.exe`" ` 
              /dotnetfx:`"$PreRequsFilesPath\NDP452-KB2901907-x86-x64-AllOS-ENU.exe`""
