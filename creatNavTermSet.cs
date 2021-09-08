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
            
            termStore.CommitAll();
            
            NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
                StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);
            
            termStore.CommitAll();

            navTermSet.IsNavigationTermSet = true;
            
            navTermSet.TargetUrlForChildTerms.Value = "/en/Pages/default.aspx";
            
            NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
           
            term1.SimpleLinkUrl = "http://h9j/pt/Paginas/default.aspx";
            termStore.CommitAll();
            /*
            NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl, Guid.NewGuid());

            term2.FriendlyUrlSegment.Value = "PAgInicial";
           
            term2.TargetUrl.Value = "/en/Pages/default.aspx";
               */        
            

            termStore.CommitAll();
            
            return navTermSet;
        }
    }
}
    
