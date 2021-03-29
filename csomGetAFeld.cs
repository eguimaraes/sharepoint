// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

SP.List list = context.Web.Lists.GetByTitle("Shared Documents");
SP.Field field = list.Fields.GetByInternalNameOrTitle("Title");
FieldText textField = context.CastTo<FieldText>(field);
context.Load(textField);
context.ExecuteQuery();

// Now, we can access the specific text field properties.
label1.Text = textField.MaxLength;
