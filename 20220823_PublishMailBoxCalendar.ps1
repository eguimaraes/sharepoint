
$mailbox=Get-MailboxCalendarFolder nome:\Calendar
Set-MailboxCalendarFolder -Identity $mailbox -PublishEnabled $true
