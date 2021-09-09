//https://docs.microsoft.com/en-us/previous-versions/office/developer/sharepoint-2010/ee832800(v=office.14)?redirectedfrom=MSDN
//
//
using (SPSite site = new SPSite("http://localhost"))
{
//Instantiates a new TaxonomySession for the current site.
TaxonomySession session = new TaxonomySession(site);
//Instantiates the connection named "Managed Metadata Service Connection" for the current session.
TermStore termStore = session.TermStores["Managed Metadata Service Connection"];

// Creates and commits a Group object named Group1, a TermSet object named 
// termSet1, and several Term objects. Term1, Term2, and Term3 are members of 
// termSet1. Term1a and Term1b are children of Term1.
// 
Group group1 = termStore.CreateGroup("Group1");
TermSet termSet1 = group1.CreateTermSet("TermSet1");
Term term1 = termSet1.CreateTerm("Term1", 1033);
Term term2 = termSet1.CreateTerm("Term2", 1033);
Term term3 = termSet1.CreateTerm("Term3", 1033);
Term term1a = term1.CreateTerm("Term1a", 1033);
Term term1b = term1.CreateTerm("Term1b", 1033);
termStore.CommitAll();

// Sets a description and some alternate labels for term1 and commits
// the changes to termStore.
term1.SetDescription("This is term1", 1033);
term1.CreateLabel("TermOne", 1033, false);
term1.CreateLabel("FirstTerm", 1033, false);\
termStore.CommitAll();

// Deletes an unnecessary term, term3, from termStore and commits the change.
term3.Delete();
termStore.CommitAll();
