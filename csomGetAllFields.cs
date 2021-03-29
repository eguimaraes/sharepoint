// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

SP.List list = context.Web.Lists.GetByTitle("Shared Documents");
context.Load(list.Fields);

// We must call ExecuteQuery before enumerate list.Fields.
context.ExecuteQuery();

foreach (SP.Field field in list.Fields)
{
  label1.Text = label1.Text + ", " + field.InternalName;
}
