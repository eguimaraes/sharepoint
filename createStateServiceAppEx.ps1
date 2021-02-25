$db = New-SPStateServiceDatabase -Name 'StateSvcDB1'
New-SPStateServiceApplication -Name 'State Service' -Database $db
