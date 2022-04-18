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
        public const string WebUrl = "/";
        public const string GroupName = "";
        public const string TermSetName = "";
        public const string URLAmigavel = "";
        public const string URLReal = "";

      

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
                   
                NavigationTerm term2 = navTermSet.CreateTerm(URLAmigavel, NavigationLinkType.FriendlyUrl,new Guid());

                 term2.TargetUrl.Value = URLReal;

                 termStore.CommitAll();
                    
                   


                    

                }

            }


        }
    }
}
