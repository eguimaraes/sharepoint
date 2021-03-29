// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

// Retrieve all lists from the server.
// For each list, retrieve Title and Id.
context.Load(web.Lists,
             lists => lists.Include(list => list.Title,
                                    list => list.Id));

// Execute query.
context.ExecuteQuery();

// Enumerate the web.Lists.
foreach (List list in web.Lists)
{
  label1.Text = label1.Text + ", " + list.Title;
}
