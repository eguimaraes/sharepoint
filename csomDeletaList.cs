// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

List list = web.Lists.GetByTitle("My List");
list.DeleteObject();

context.ExecuteQuery();
