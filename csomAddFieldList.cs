// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

SP.List list = context.Web.Lists.GetByTitle("Announcements");

SP.Field field = list.Fields.AddFieldAsXml("<Field DisplayName='MyField2' Type='Number' />",
                                           true,
                                           AddFieldOptions.DefaultValue);
SP.FieldNumber fldNumber = context.CastTo<FieldNumber>(field);
fldNumber.MaximumValue = 100;
fldNumber.MinimumValue = 35;
fldNumber.Update();

context.ExecuteQuery();
