$site=get-spsite http://siteURL
$web=$site.RootWeb
$web.Groups | Format-table name,id
$group=$web.Groups.GetByID(GroupId)
new-spuser -Web http://siteURL -UserAlias "domain\UserName" -Group $group
