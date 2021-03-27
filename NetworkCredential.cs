using System.Net
using System.Net.Security;
NetworkCredential myCred = new NetworkCredential(
    SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain);

CredentialCache myCache = new CredentialCache();

myCache.Add(new Uri("www.ekis.com.br"), "Basic", myCred);
myCache.Add(new Uri("app.ekis.com.br"), "Basic", myCred);

WebRequest wr = WebRequest.Create("www.contoso.com");
wr.Credentials = myCache;
