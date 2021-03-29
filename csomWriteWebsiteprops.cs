//https://docs.microsoft.com/en-us/sharepoint/dev/sp-add-ins/complete-basic-operations-using-sharepoint-client-library-code
// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

web.Title = "New Title";
web.Description = "New Description";

// Note that the web.Update() doesn't trigger a request to the server.
// Requests are only sent to the server from the client library when
// the ExecuteQuery() method is called.
web.Update();

// Execute the query to server.
context.ExecuteQuery();
