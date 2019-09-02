using (SPSite site = new SPSite("http://sharepoint.com")) 
   {
    using (SPWeb web = site.RootWeb) 
       {
        SPFolder rootFolder = web.RootFolder;
        rootFolder.WelcomePage = "Pages/HomePage.aspx";
        rootFolder.Update();
      }
   }
