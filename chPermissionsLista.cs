SPList customList = web.Lists.TryGetList("lista");
if (!customList.HasUniqueRoleAssignments)
{
    customList.BreakRoleInheritance(false, false);
}
customList.Update();
web.Update(); 

SPRoleAssignment roleAssignment = new SPRoleAssignment((SPPrincipal)web.SiteGroups["grupos"]);

roleAssignment.RoleDefinitionBindings.Add(web.RoleDefinitions.GetByType(SPRoleType.Contributor));

customList.RoleAssignments.Add(roleAssignment);

customList.Update();

web.Update();
