Get-PnPTerm -TermSet "Departments" -TermGroup "Corporate"
Get-PnPTerm -Identity "Finance" -TermSet "Departments" -TermGroup "Corporate"
Get-PnPTerm -Identity ab2af486-e097-4b4a-9444-527b251f1f8d -TermSet "Departments" -TermGroup "Corporate"
Get-PnPTerm -Identity "Small Finance" -TermSet "Departments" -TermGroup "Corporate" -Recursive
$term = Get-PnPTerm -Identity "Small Finance" -TermSet "Departments" -TermGroup "Corporate" -Include Labels
$term.Labels

