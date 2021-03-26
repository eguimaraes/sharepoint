ClientContext context = new ClientContext("https://{site_url}");
List announcementsList = context.Web.Lists.GetByTitle("Announcements");
ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
ListItem newItem = announcementsList.AddItem(itemCreateInfo);
newItem["Title"] = "My New Item!";
newItem["Body"] = "Hello World!";
newItem.Update();
context.ExecuteQuery();
