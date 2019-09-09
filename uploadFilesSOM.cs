  private static void uploadFiles(string siteUrl, string dirOr, string dirDest, string lista)
        {
           using (SPSite site =new SPSite(siteUrl))
            {

                using (SPWeb web = site.RootWeb)
                {


                    SPFolder myLibrary = web.Folders[lista];

                    // Prepare to upload
                    Boolean replaceExistingFiles = true;
                    String fileName = System.IO.Path.GetFileName(dirOr);
                    FileStream fileStream =System.IO.File.OpenRead(dirOr);

                    // Upload document
                    SPFile spfile = myLibrary.Files.Add(dirDest, fileStream, replaceExistingFiles);

                    // Commit 
                    myLibrary.Update();


                }




            }
            

        }
