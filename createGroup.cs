using (var spSite = new SPSite("SiteURL"))
{
        using (var web = spSite.OpenWeb())
        {
                var groupName = "Group Name";
                var groupDescription = "Group Description";
                var groupOwner = "contoso\jbloggs";
                var defaultUser = "contoso\jdoe";
                
                
                web.SiteGroups.Add(groupName, groupOwner, defaultUser, groupDescription);
                
                var group = web.SiteGroups[groupName];
                var spRoleAssignment = new SPRoleAssignment(group);
                var permissionName = "Read";
                
                spRoleAssignment.RoleDefinitionBindings.Add(web.RoleDefinitions[permissionName]);
                web.RoleAssignments.Add(spRoleAssignment);

                web.Update();
        }
}
