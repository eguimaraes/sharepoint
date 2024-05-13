#Original em https://www.sharepointdiary.com/2022/03/add-column-to-list-in-sharepoint-online-using-powershell.html todos os direitos reservados ao criador

$SiteURL = "https://URL"
$ListName= "Team Projects"
$FieldTitle= "Project ID"
$FieldInternalName ="ProjectID"
$FieldType = "Text"
  
Try {
    #Connect to PnP Online
    Connect-PnPOnline -Url $SiteURL -Interactive
      
    #Add new field to list
    Add-PnPField -List $ListName -DisplayName $FieldTitle -InternalName $FieldInternalName -Type $FieldType -Required -AddToDefaultView -ErrorAction Stop
    Write-host -f Green "New Field '$FieldTitle' Added to the List!"
}
catch {
    write-host "Error: $($_.Exception.Message)" -foregroundcolor Red
}


#Read more: https://www.sharepointdiary.com/2022/03/add-column-to-list-in-sharepoint-online-using-powershell.html#ixzz8a8I1Vll2
