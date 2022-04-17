#https://asishpadhy.com/2018/06/28/update-navigation-programmatically-for-sharepoint-modern-sites-using-sharepoint-csom/
using (var context = new ClientContext(<siteURL>))
{
    contextAsset.Credentials = new SharePointOnlineCredentials(UserName, SecurePass);
    Web web = contextAsset.Web;
    contextAsset.Load(web, w => w.Navigation);
    contextAsset.Load(web);
    contextAsset.ExecuteQuery();

    //Start working on Navigation
    NavigationNodeCollection lefthandNav = web.Navigation.QuickLaunch;
    contextAsset.Load(lefthandNav);
    List<int> navIds = new List<int>(); // To be used in Deletion
    contextAsset.ExecuteQuery();

    foreach (NavigationNode nodeLeftHandNav in lefthandNav)
    {
        contextAsset.Load(nodeLeftHandNav.Children);
        contextAsset.ExecuteQuery();
        if (nodeLeftHandNav.Children.Count > 0)
        {
            foreach (NavigationNode nodeLeftHandNavChild1 in nodeLeftHandNav.Children)
            {
                contextAsset.Load(nodeLeftHandNavChild1.Children);
                contextAsset.ExecuteQuery();
                if (nodeLeftHandNavChild1.Children.Count > 0)
                {
                    foreach (NavigationNode nodeLefthandNavChild2 in nodeLeftHandNavChild1.Children)
                    {
                        <Do something>
                        //For deletion
                        if(nodeLefthandNavChild2 == TobeDeleted)
                             navIds.Add(nodeLeftHandNav.Id);
                    }
                }
                else
                {
                   <Do something>
                    //For deletion
                    if(nodeLeftHandNavChild1 == TobeDeleted)
                            navIds.Add(nodeLeftHandNav.Id);
                }
            }
        }
        else
        {
            <Do something>
            //For deletion
            if(nodeLeftHandNavChild1 == TobeDeleted)
                    navIds.Add(nodeLeftHandNav.Id);
        }
    }
}
