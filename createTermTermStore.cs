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



       public static NavigationTermSet CriarItemNaTermStore(string url, string urlweb,Guid NavTermSetId,Guid TaggingTermSetId)
        {
            SPSite site = new SPSite(url);

            SPWeb web = site.AllWebs[urlweb];

             TaxonomySession taxonomySession = new TaxonomySession(site);

            if (taxonomySession.TermStores.Count == 0)
                throw new InvalidOperationException("O Serviço de taxonomia não existe");

            TermStore termStore = taxonomySession.TermStores[0];
            
            TermSet existingTermSet = termStore.GetTermSet(NavTermSetId);

            if (existingTermSet != null)
            {
                
                existingTermSet.Delete();
                termStore.CommitAll();
            }

            
            Group siteCollectionGroup = termStore.GetSiteCollectionGroup(web.Site);
            TermSet termSet = siteCollectionGroup.CreateTermSet("Teste01", NavTermSetId);
            NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
                StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);
            
            navTermSet.IsNavigationTermSet = true;
            
            navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/Topics/Topic.aspx";
            
            NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
           
            term1.SimpleLinkUrl = "https://ekisiot.sharepoint.com/";

            NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl);
            
            NavigationTerm term2a = term2.CreateTerm("Term 2 A", NavigationLinkType.FriendlyUrl);
            
            NavigationTerm term2b = term2.CreateTerm("Term 2 B", NavigationLinkType.FriendlyUrl);
            
            NavigationTerm term3 = navTermSet.CreateTerm("Term 3", NavigationLinkType.FriendlyUrl);
            
            termStore.CommitAll();
            
            return navTermSet;
        }
    }
}
    
