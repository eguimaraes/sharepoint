using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;


namespace ekis.util.termstore.adm.create
{
    class Program

    {
        public static readonly Guid NavTermSetId = new Guid();
        public static readonly Guid TaggingTermSetId = new Guid();
        public const string ServerUrl = "";
        public const string WebUrl = "";
        public const string GroupName = "";
        public const string TermSetName = "";

        static void Main(string[] args)
        {
            using (SPSite site=new SPSite(ServerUrl)){

                using (SPWeb web = site.AllWebs[WebUrl]) { 

                TaxonomySession session = new TaxonomySession(web,true);

                TermStore termStore = session.TermStores[0];

                Group grupo=termStore.CreateGroup(GroupName);

                TermSet termSet = grupo.CreateTermSet(TermSetName);

                NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);

                navTermSet.IsNavigationTermSet = true;
                 
                navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/Topics/Topic.aspx";

                NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
                    
                term1.SimpleLinkUrl = "https://www.bing.com/";

                    Guid term2Guid = new Guid();
                   
                    NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl,   term2Guid);

                    // Verify that the NavigationTermSetView is being applied correctly

                    string expectedTargetUrl = web.ServerRelativeUrl
                        + "/Pages/Topics/Topic.aspx?TermStoreId=" + termStore.Id.ToString()
                        + "&TermSetId=" + NavTermSetId.ToString()
                        + "&TermId=" + term2Guid.ToString();

                    NavigationTerm childTerm = term2.CreateTerm("Term 2 child", NavigationLinkType.FriendlyUrl);

                    // Commit the Taxonomy changes
                    childTerm.GetTaxonomyTerm().TermStore.CommitAll();



                    Term term= termSet.CreateTerm("teste1",1033);                

                 termStore.CommitAll();
                    
                   


                    

                }

            }


        }
    }
}
