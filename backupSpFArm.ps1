Backup-SPFarm -ShowTree #lista os componentes
Backup-SPFarm -Directory \\file_server\share\Backup -BackupMethod full -ConfigurationOnly
Backup-SPFarm -ShowTree -Item "Microsoft SharePoint Foundation Web Application" -Verbose
Backup-SPFarm -Directory C:\Backup -BackupMethod full -BackupThreads 10 -Force
