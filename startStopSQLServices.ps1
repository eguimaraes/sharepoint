$services=get-service | Where-Object {$_.name.Contains("SQL")}
foreach ($service in $services) {$service.start()}
foreach ($service in $services) {$service.stop()}
