Original em: https://piyushksingh.com/2014/01/19/check-incheck-out-and-publishunpublish-files-in-sharepoint-2013-using-the-client-object-model-c/

string siteUrl = "http://nomeservidor/";
SP.ClientContext ctx = new SP.ClientContext(siteUrl);
ctx.Credentials = new SharePointOnlineCredentials(userName, passWord);
this.ctx.Load(this.ctx.Web);
SP.Web web = this.ctx.Web;
SP.File file = web.getFileByServerRelativeUrl("serverrelativeUrlOfTheFile");
 
//CheckIn the file
file.CheckIn(String.Concat("File CheckingIn at ", DateTime.Now.ToLongDateString()), SP.CheckinType.MajorCheckIn);
 
//CheckOut the File
file.CheckOut();
 
//Publish the file
file.Publish(String.Concat("File Publishing at ", DateTime.Now.ToLongDateString()));
 
//UnPublish the file
file.UnPublish(String.Concat("File UnPublishing at ", DateTime.Now.ToLongDateString()));
