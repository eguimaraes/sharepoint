//https://docs.microsoft.com/en-us/sharepoint/dev/sp-add-ins/complete-basic-operations-using-sharepoint-client-library-code
// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

// We want to retrieve the web's title and description.
context.Load(web, w => w.Title, w => w.Description);

// Execute the query to server.
context.ExecuteQuery();

// Now, only the web's title and description are available. If you
// try to print out other properties, the code will throw
// an exception because other properties aren't available.
label1.Text = web.Title;
label1.Text = web. Description;
