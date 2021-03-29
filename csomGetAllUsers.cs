// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

GroupCollection siteGroups = context.Web.SiteGroups;

// Assume that there is a "Members" group, and the ID=5.
Group membersGroup = siteGroups.GetById(5);
context.Load(membersGroup.Users);
context.ExecuteQuery();

foreach (User member in membersGroup.Users)
{
  // We have all the user info. For example, Title.
  label1.Text = label1.Text + ", " + member.Title;
}
