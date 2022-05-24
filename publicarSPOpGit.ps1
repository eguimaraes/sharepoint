$msg=read-host("Digite a mensagem do commit")
git commit -a -m $msg
git push
gulp trust-dev-cert
gulp build
gulp bundle
gulp --ship
gulp build --ship
gulp bundle --ship
gulp package-solution
gulp package-solution --production
gulp package-solution --ship
gulp trust-dev-cert
