#from https://docs.microsoft.com/en-us/dotnet/api/microsoft.sharepoint.taxonomy.term?view=sharepoint-server
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;
using System.Security.Principal;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace Microsoft.SDK.SharePoint.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length &lt; 1)
            {
                Console.WriteLine("Please add site url as an argument");
                return;
            }
            SPSite site = new SPSite(args[0]);
            if (site != null)
            {
                TermStore termStore = GetATermStore(site);

                if (termStore != null)
                {
                    // creat a group
                    Group group = termStore.CreateGroup("TestData");

                    // test term properties
                    TestTermCodeSamples.TestTermProperties(termStore, group);
                    // test child terms and sort order
                    TestTermCodeSamples.TestGetTerms(termStore, group);
                    // test term operation
                    TestTermCodeSamples.TestTermOperation(termStore, group);
                }
            }
        }

        static TermStore GetATermStore(SPSite site)
        {
            // Get a TaxonomySession from the site
            TaxonomySession session = new TaxonomySession(site);
            TermStore termStore = null;
            // Get a TermStore from the session
            if (session.TermStores != null &amp;&amp; session.TermStores.Count &gt; 0)
            {
                termStore = session.TermStores[0];
            }
            return termStore;
        }
    }

    static class TestTermCodeSamples
    {
        public static void TestGetTerms(TermStore termStore, Group group)
        {
            if (termStore == null)
            {
                throw new System.ArgumentNullException("termStore");
            }
            if (group == null)
            {
                throw new System.ArgumentNullException("group");
            }

            // get current thread lcid
            int lcid = CultureInfo.CurrentCulture.LCID;

            // create term set
            TermSet termSet = group.CreateTermSet("Month");

            // TermSetItem.DoesUserHavePermission method
            // check if the current user has permission to edit the term set
            bool doesUserHavePermission = termSet.DoesUserHavePermissions(TaxonomyRights.EditTermSet);
            Console.WriteLine("The current user " +
                WindowsIdentity.GetCurrent().Name.ToString() +
                (doesUserHavePermission?" has":" does not have") +
                " permission to edit the term set.");

            // create term
            // TermSetItem.CreateTerm(System.String,System.Int32)
            Term term = termSet.CreateTerm("Week", lcid);

            // Create terms
            Term termFri = term.CreateTerm("Fri", lcid);
            Term termMon = term.CreateTerm("Mon", lcid);
            Term termSat = term.CreateTerm("Sat", lcid);
            Term termSun = term.CreateTerm("Sun", lcid);
            Term termThu = term.CreateTerm("Thu", lcid);
            Term termTue = term.CreateTerm("Tue", lcid);
            Term termWed = term.CreateTerm("Wed", lcid);

            // print each term name and id
            PrintTermCollection(term.Terms);

            // define a custom sort order
            // Term.CustomSortOrder
            term.CustomSortOrder = termSun.Id.ToString() + ":" + 
                termMon.Id.ToString() + ":" +
                termTue.Id.ToString() + ":" +
                termWed.Id.ToString() + ":" +
                termThu.Id.ToString() + ":" +
                termFri.Id.ToString() + ":" +
                termSat.Id.ToString();

            // commit term store changes
            termStore.CommitAll();

            // print child terms with paging of 5
            // TermSetItem.GetTerms(int)
            TermCollection retrievedTerms = term.GetTerms(5);
            PrintTermCollection(retrievedTerms);

            // get term starts with 'S'
            // Term.GetTerms
            retrievedTerms = term.GetTerms("S", lcid,
                true /* search default label only */,
                StringMatchOption.StartsWith,
                5, /*maximum results returned*/
                true /*trim term that is not available for tagging */);
            PrintTermCollection(retrievedTerms);
        }

        public static void TestTermOperation(TermStore termStore, Group group)
        {
            if (termStore == null)
            {
                throw new System.ArgumentNullException("termStore");
            }
            if (group == null)
            {
                throw new System.ArgumentNullException("group");
            }

            // get current thread lcid
            int lcid = CultureInfo.CurrentCulture.LCID;

            // create term sets and terms
            TermSet termSetA = group.CreateTermSet("A");
            TermSet termSetB = group.CreateTermSet("B");

            Term termA1 = termSetA.CreateTerm("A1", lcid);
            Term termA2 = termSetA.CreateTerm("A2", lcid);
            Term termB1 = termSetB.CreateTerm("B1", lcid);
            Term termB2 = termSetB.CreateTerm("B2", lcid);

            // Copy, created new term "Copy of A1" under the same parent
            termA1.Copy(false);

            // Move, term "A1" is moved to term set "B"
            termA1.Move(termSetB);

            // Reuse, term "B2" is reused as a child term of term "A2"
            Term reusedCopyofTermB2 = termA2.ReuseTerm(termB2, false);
            // then re-assign source term to the reused copy under term "B2"
            termB2.ReassignSourceTerm(reusedCopyofTermB2);

            // Merge, merge "A1" to "A2", the new merged term is called "A2", 
            // and is reused under both term set "A" and "B"
            Term mergedTerm = termA1.Merge(termA2);
            termStore.CommitAll();

            // Print merged term information
            Console.WriteLine("Merged Terms:");
            Console.WriteLine("Term: " + mergedTerm.Name + ", IsSource: " + 
                mergedTerm.IsSourceTerm + ", Term Set:" + mergedTerm.TermSet.Name);
            foreach (Term term in mergedTerm.ReusedTerms)
            {
                Console.WriteLine("Term: " + term.Name + ", IsSource: " +
                    term.IsSourceTerm + ", Term Set:" + term.TermSet.Name);
            }
            // Print merged term Ids
            foreach (Guid id in mergedTerm.MergedTermIds)
            {
                Console.WriteLine("MergedId: " + id);
            }

            PrintTermCollection(termSetA.Terms);
            PrintTermCollection(termSetB.Terms);
        }

        public static void TestTermProperties(TermStore termStore, Group group)
        {
            if (termStore == null)
            {
                throw new System.ArgumentNullException("termStore");
            }
            if (group == null)
            {
                throw new System.ArgumentNullException("group");
            }

            // get current thread lcid
            int lcid = CultureInfo.CurrentCulture.LCID;

            TermSet termSet = group.CreateTermSet("Term Set");
            try
            {
                Term term = termSet.CreateTerm("Term1", lcid, Guid.NewGuid());

                // Set Description and label
                term.SetDescription("This is the description for the term.", lcid);
                term.CreateLabel("Term Label 1", lcid, false);

                termStore.CommitAll();

                Console.WriteLine("Term description: " + term.GetDescription());
                Console.WriteLine("Term default label: " + term.GetDefaultLabel(lcid));

                // print all term labels for an lcid, include both default and 
                // non-default label
                LabelCollection labels = term.GetAllLabels(lcid);
                foreach (Label label in labels)
                {
                    Console.WriteLine("Term label " + label.Value);
                }

                Console.WriteLine("Term path: " + term.GetPath());
                Console.WriteLine("IsKeyword:" + term.IsKeyword);
                Console.WriteLine("IsRoot:" + term.IsRoot);
                Console.WriteLine("IsAvailableForTagging:" + term.IsAvailableForTagging);
            }
            catch (TermStoreOperationException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        private static void PrintTermCollection(TermCollection terms)
        {
            if (terms == null)
            {
                throw new System.ArgumentNullException("terms");
            }
            Console.WriteLine("Print terms in the term collection ...");
            foreach (Term term in terms)
            {
                Console.WriteLine(term.Name + ":" + term.Id);
            }
        }
    }
}
