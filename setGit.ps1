git config --global user.email "you@example.com"
git config --global user.name "Your Name"
$msg=read-host("Digite a mensagem do commit")
git add . --all;
git commit -a -m $msg;
git push;
