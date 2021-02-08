$url=url
$site=get-spsite $url
$web=$site.RootWeb
 $topnavigation = $web.Navigation.TopNavigationBar 
 foreach($node in $topnavigation) {$node.Title}
