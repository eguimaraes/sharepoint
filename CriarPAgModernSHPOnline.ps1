$SiteURL = "https://crescent.sharepoint.com/sites/Intranet"
Connect-PnPOnline -Url $SiteURL -Interactive # -Credentials (Get-Credential)
  

$Page = Add-PnPPage -Name "News" -LayoutType Article
 

Set-PnPPage -Identity $Page -Title "News" -CommentsEnabled:$False -HeaderType Default
 

Add-PnPPageSection -Page $Page -SectionTemplate OneColumn
 

Add-PnPPageTextPart -Page $Page -Text "Welcome To News Portal" -Section 1 -Column 1
 

Add-PnPPageWebPart -Page $Page -DefaultWebPartType News -Section 1 -Column 1
 

Add-PnPPageWebPart -Page $Page -DefaultWebPartType List -Section 1 -Column 1 -WebPartProperties @{ selectedListId = "21b99d39-834f-4991-b5f9-bd095fa0633c"}
 

$Page.Publish()


#Read more: https://www.sharepointdiary.com/2019/08/create-modern-page-in-sharepoint-online-using-powershell.html
