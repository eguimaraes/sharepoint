https://docs.microsoft.com/en-us/previous-versions/office/sharepoint-server/jj252669(v=office.15)?redirectedfrom=MSDN
using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;


namespace NavigationDemos
{
    public class Class1
    {
        public static readonly Guid NavTermSetId = new Guid("<GUID>");
        public static readonly Guid TaggingTermSetId = new Guid("<GUID>");
        public const string ServerUrl = "http:// <ServerURL>";



        public void CreateNavigationTermSet()
        {
            using (SPSite site = new SPSite(ServerUrl))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    TaxonomySession taxonomySession = new TaxonomySession(site, updateCache: true);

                    // Use the first TermStore in the list
                    if (taxonomySession.TermStores.Count == 0)
                        throw new InvalidOperationException("The Taxonomy Service is offline or missing");

                    TermStore termStore = taxonomySession.TermStores[0];

                    // Does the TermSet already exist?
                    TermSet existingTermSet = termStore.GetTermSet(NavTermSetId);
                    if (existingTermSet != null)
                    {
                        existingTermSet.Delete();
                        termStore.CommitAll();
                    }

                    // Create a new TermSet
                    Group siteCollectionGroup = termStore.GetSiteCollectionGroup(site);
                    TermSet termSet = siteCollectionGroup.CreateTermSet("Navigation Demo", NavTermSetId);

                    NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
                        StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);

                    navTermSet.IsNavigationTermSet = true;
                    navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/Topics/Topic.aspx";

                    NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
                    term1.SimpleLinkUrl = "https://www.bing.com/";

                    Guid term2Guid = new Guid("87FAA433-4E3E-4500-AA5B-E04330B12ACD");
                    NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl,
                        term2Guid);

                    // Verify that the NavigationTermSetView is being applied correctly

                    string expectedTargetUrl = web.ServerRelativeUrl
                        + "/Pages/Topics/Topic.aspx?TermStoreId=" + termStore.Id.ToString()
                        + "&TermSetId=" + NavTermSetId.ToString()
                        + "&TermId=" + term2Guid.ToString();

                    NavigationTerm childTerm = term2.CreateTerm("Term 2 child", NavigationLinkType.FriendlyUrl);

                    // Commit the Taxonomy changes
                    childTerm.GetTaxonomyTerm().TermStore.CommitAll();
                }
            }
        }
    }
}
