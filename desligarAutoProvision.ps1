Disable-SPAppAutoProvision
$subscription = Get-SPSiteSubscription https://Contoso.com
Disable-SPAppAutoProvision -SiteSubscription $subscription
