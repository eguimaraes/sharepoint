
https://docs.microsoft.com/en-us/sharepoint/dev/sp-add-ins/complete-basic-operations-using-sharepoint-client-library-code
// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

// We want to retrieve the web's properties.
context.Load(web);

// Execute the query to the server.
context.ExecuteQuery();

// Now, the web's properties are available and we could display
// web properties, such as title.
label1.Text = web.Title;
