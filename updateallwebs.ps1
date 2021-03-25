 $url="url";
 
 $site=get-spsite $url;
 
 foreach ($web in $site.AllWebs){
 
 write-host($web.title,$web.url);
 
 foreach($lista in $web.lists)
 {
    $lista.update(); 
 
    $web.update();
 
  }
  
 }
