// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

ListCreationInformation creationInfo = new ListCreationInformation();
creationInfo.Title = "My List";
creationInfo.TemplateType = (int)ListTemplateType.Announcements;
List list = web.Lists.Add(creationInfo);
list.Description = "New Description";

list.Update();
context.ExecuteQuery();
