// Starting with ClientContext, the constructor requires a URL to the
// server running SharePoint.
ClientContext context = new ClientContext("https://{site_url}");

BasePermissions perm = new BasePermissions();
perm.Set(PermissionKind.CreateAlerts);
perm.Set(PermissionKind.ManageAlerts);

RoleDefinitionCreationInformation creationInfo = new RoleDefinitionCreationInformation();
creationInfo.BasePermissions = perm;
creationInfo.Description = "A role with create and manage alerts permission";
creationInfo.Name = "Alert Manager Role";
creationInfo.Order = 0;
RoleDefinition rd = context.Web.RoleDefinitions.Add(creationInfo);

context.ExecuteQuery();
