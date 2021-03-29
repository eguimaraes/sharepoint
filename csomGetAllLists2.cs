// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// The SharePoint web at the URL.
Web web = context.Web;

// Retrieve all lists from the server, and put the return value in another
// collection instead of the web.Lists.
IEnumerable<SP.List> result = context.LoadQuery(
  web.Lists.Include( 
      // For each list, retrieve Title and Id.
      list => list.Title,
      list => list.Id
  )
);

// Execute query.
context.ExecuteQuery();

// Enumerate the result.
foreach (List list in result)
{
  label1.Text = label1.Text + ", " + list.Title;
}
