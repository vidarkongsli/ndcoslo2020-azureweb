$x = az webapp deployment source config-local-git | ConvertFrom-Json
$y = az webapp deployment list-publishing-profiles | ConvertFrom-Json

"https://$($y[0].userName):$($y[0].userPwd)@$($x.url -split '@' | select-object -last 1)"
