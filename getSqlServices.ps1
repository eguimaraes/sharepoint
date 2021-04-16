$services=get-service | Where-Object {$_.name.Contains("SQL")}

