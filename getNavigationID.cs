#original em https://asishpadhy.com/2018/06/28/update-navigation-programmatically-for-sharepoint-modern-sites-using-sharepoint-csom/
foreach (int id in navIds)
{
    NavigationNode nodeToDelete = web.Navigation.GetNodeById(id);
    contextAsset.Load(nodeToDelete);
    contextAsset.ExecuteQuery();
    nodeToDelete.DeleteObject();
    contextAsset.ExecuteQuery();
}
