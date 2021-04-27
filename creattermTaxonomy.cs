/* https://docs.microsoft.com/en-us/dotnet/api/microsoft.sharepoint.taxonomy.termstore?view=sharepoint-server */

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;

namespace NavigationDemos
{
    public class Class1
    {
        public static readonly Guid NavTermSetId = new Guid("&lt;GUID&gt;");
        public static readonly Guid TaggingTermSetId = new Guid("&lt;GUID&gt;");

        //Creates the sample term set. If it exists, it will be deleted
        public static NavigationTermSet RecreateSampleNavTermSet(TaxonomySession taxonomySession, SPWeb web)
        {
            // Use the first TermStore in the list
            if (taxonomySession.TermStores.Count == 0)
                throw new InvalidOperationException("The Taxonomy Service is offline or missing");

            TermStore termStore = taxonomySession.TermStores[0];

            // Does the TermSet already exist?
            TermSet existingTermSet = termStore.GetTermSet(NavTermSetId);

            if (existingTermSet != null)
            {
                //If the TermSet exists, delete it.
                existingTermSet.Delete();
                termStore.CommitAll();
            }

            // Create a new TermSet
            Group siteCollectionGroup = termStore.GetSiteCollectionGroup(web.Site);
            TermSet termSet = siteCollectionGroup.CreateTermSet("Navigation Demo", NavTermSetId);
            NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
                StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);
            navTermSet.IsNavigationTermSet = true;
            navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/Topics/Topic.aspx";
            NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
            term1.SimpleLinkUrl = "http://www.bing.com/";
            NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl);
            NavigationTerm term2a = term2.CreateTerm("Term 2 A", NavigationLinkType.FriendlyUrl);
            NavigationTerm term2b = term2.CreateTerm("Term 2 B", NavigationLinkType.FriendlyUrl);
            NavigationTerm term3 = navTermSet.CreateTerm("Term 3", NavigationLinkType.FriendlyUrl);
            termStore.CommitAll();
            return navTermSet;
        }
    }
}
