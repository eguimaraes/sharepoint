// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

GroupCollection siteGroups = context.Web.SiteGroups;

// Assume that there is a "Members" group, and the ID=5.
Group membersGroup = siteGroups.GetById(5);

// Let's set up the new user info.
UserCreationInformation userCreationInfo = new UserCreationInformation();
userCreationInfo.Email = "user@domain.com";
userCreationInfo.LoginName = "domain\\user";
userCreationInfo.Title = "Mr User";

// Let's add the user to the group.
User newUser = membersGroup.Users.Add(userCreationInfo);

context.ExecuteQuery();
