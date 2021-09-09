//ref https://github.com/SharePoint/sp-dev-docs/blob/master/docs/general-development/how-to-use-code-to-pin-terms-to-navigation-term-sets-in-sharepoint.md
using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;

namespace RobotTermStore
{
    public class termStoreUtils
    {
        public termStoreUtils() { }



        public static void CriarItemNaTermStore(string url)
        {


            using (SPSite site = new SPSite(url))
            {
                
                TaxonomySession session = new TaxonomySession(site);
                
                TermStore termStore = session.TermStores["MMS"];
                               
                
                Group group1 = termStore.CreateGroup("Links1");
               
                TermSet termSet1 = group1.CreateTermSet("TermSet1");
                
                Term term1 = termSet1.CreateTerm("Term1", 1033);
                
                Term term2 = termSet1.CreateTerm("Term2", 1033);
                
                Term term3 = termSet1.CreateTerm("Term3", 1033);
                
                Term term1a = term1.CreateTerm("Term1a", 1033);
                
                Term term1b = term1.CreateTerm("Term1b", 1033);
                
                termStore.CommitAll();

                term1.SetDescription("This is term1", 1033);

                term1.CreateLabel("TermOne", 1033, false);

                term1.CreateLabel("FirstTerm", 1033, false);

                termStore.CommitAll();

               
                term3.Delete();
                
                termStore.CommitAll();


            }
        }
    }
}
    
