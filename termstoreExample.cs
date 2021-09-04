using System;
using System.IO;
using System.Globalization;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;


namespace Microsoft.SDK.SharePointServer.Samples
{
    public static class TaxonomySamples
    {
        public static void UseSession(SPSite site)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Get the default keyword TermStore for the provided site
            TermStore defaultKeywordStore = session.DefaultKeywordsTermStore;
            if (defaultKeywordStore != null)
            {
                Console.WriteLine(defaultKeywordStore.Name);
            }
            else
            {
                Console.WriteLine("Default keyword store is not configured or not configured properly");
            }


            // Get the default site collection TermStore associated with the provide site.
            TermStore defaultSiteCollectionStore = session.DefaultSiteCollectionTermStore;
            if (defaultSiteCollectionStore != null)
            {
                Console.WriteLine(defaultSiteCollectionStore.Name);
            }
            else
            {
                Console.WriteLine("Default site collection TermStore is not configured or not configured properly");
            }


            // Get all the TermStores associated with the provided site.
            TermStoreCollection termStores = session.TermStores;
            Console.WriteLine(termStores.Count);


            // Get all the offline TermStore names
            StringCollection names = session.OfflineTermStoreNames;
            Console.WriteLine(names.Count);


            // Resync the taxonomy hidden list to make sure it is update-to-date
            TaxonomySession.SyncHiddenList(site);
        }


        public static void RetrieveTerm(SPSite site, Guid termId)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Retrieves a Term with the provided Id
            Term term = session.GetTerm(termId);
            Console.WriteLine("Got Term " + term.Name);
        }


        public static void SearchTermsByLabel(SPSite site, string prefix)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Search all Terms that start with the provide prefix from
            // all TermStores associated with the provided site.
            TermCollection terms = session.GetTerms(prefix,
                true, // Only search in default labels
                StringMatchOption.StartsWith,
                5,  // The maximum number of terms returned from each TermStore
                true); // The results should not contain unavailable terms


            Console.WriteLine("The number of matching Terms is " + terms.Count);
        }




        public static void SearchTermsByCustomProperty(SPSite site, 
            string customPropertyName)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Search all Terms that contain a custom property with the provided name
            // from all TermStores associated with the provided site.
            TermCollection terms = session.GetTermsWithCustomProperty(
                customPropertyName,
                true); // The results should not contain unavailable Terms


            Console.WriteLine("The number of matching Terms is " + terms.Count);
        }


        public static void SearchTermSetsByName(SPSite site,
            string termSetName)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Search all TermSets that are using the provided name in current
            // UI LCID from all TermStores associated with the provided site.
            TermSetCollection termSets = session.GetTermSets(termSetName,
                CultureInfo.CurrentUICulture.LCID);


            Console.WriteLine("The number of matching Term Sets is " + termSets.Count);
        }


        public static void SearchTermSetsByTermLabels(SPSite site,
            string[] termLabels)
        {
            TaxonomySession session = new TaxonomySession(site);


            // Returns all TermSet instances from all TermStores that contain terms 
            // with matching labels for all specified strings.
            TermSetCollection termSets = session.GetTermSets(termLabels);
            Console.WriteLine("The number of matching Term Sets is " + termSets.Count);
        }


    }
}
