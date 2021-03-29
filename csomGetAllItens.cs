// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

// Assume the web has a list named "Announcements".
List announcementsList = context.Web.Lists.GetByTitle("Announcements");

// This creates a CamlQuery that has a RowLimit of 100, and also specifies Scope="RecursiveAll"
// so that it grabs all list items, regardless of the folder they are in.
CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
ListItemCollection items = announcementsList.GetItems(query);

// Retrieve all items in the ListItemCollection from List.GetItems(Query).
context.Load(items);
context.ExecuteQuery();
foreach (ListItem listItem in items)
{
  // We have all the list item data. For example, Title.
  label1.Text = label1.Text + ", " + listItem["Title"];
}
