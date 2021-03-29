az ad user create --display-name "Abby Brown" \
                  --password "<password>" \
                  --user-principal-name "AbbyB@contoso.com" \
                  --force-change-password-next-login true \
                  --mail-nickname "AbbyB"
