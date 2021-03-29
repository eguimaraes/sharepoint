//https://docs.microsoft.com/en-us/sharepoint/dev/sp-add-ins/complete-basic-operations-using-sharepoint-client-library-code
// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

WebCreationInformation creation = new WebCreationInformation();
creation.Url = "web1";
creation.Title = "Hello web1";
Web newWeb = context.Web.Webs.Add(creation);

// Retrieve the new web information.
context.Load(newWeb, w => w.Title);
context.ExecuteQuery();

label1.Text = newWeb.Title;
