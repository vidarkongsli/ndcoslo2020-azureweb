$x = az webapp deployment source config-local-git --slot pre | ConvertFrom-Json
$y = az webapp deployment list-publishing-profiles --slot pre | ConvertFrom-Json

"https://$($y[0].userName):$($y[0].userPwd)@$($x.url -split '@' | select-object -last 1)"
