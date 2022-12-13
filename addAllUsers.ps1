$SiteURL = Read-Host("URL do site")
Connect-PnPOnline -Url $SiteURL -Interactive
$LoginName = "c:0(.s|true"
$VisitorsGroup = Get-PnPGroup -AssociatedVisitorGroup
Add-PnPGroupMember -LoginName $LoginName -Identity $VisitorsGroup
