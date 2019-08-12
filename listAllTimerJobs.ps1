Begin 
{ 
      Write-Host "Fetching SharePoint 2013 Farm Timer Jobs.." 
} 
Process 
{ 
      Get-SPWebApplication  | %{$_.JobDefinitions | Select -Unique -Property Name, ID, Status , Schedule} | Where-Object Schedule -Like "*minute*" | Sort-Object -Property Name | ft
} 
End 
{ 

      Write-Host "Execution Completed!!!"
}
