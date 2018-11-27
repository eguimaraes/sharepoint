
//Original http://www.sharepointpals.com/post/How-to-Create-Terms-in-TermStore-if-not-exists-using-C-Patterns-and-Practices-in-SharePoint-Office-365
namespace Office365.Console
 {
  
  
     class Program
     {
         static void Main(string[] args)
         {
  
             AddTaxonomyEntry();
             System.Console.ReadLine();
         }
  
         public static void AddTaxonomyEntry()
         {
             try
             {
                 OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
  
                 string siteUrl = "https://sppalsmvp.sharepoint.com/sites/DeveloperSite";
                 string userName = "Sathish@*****.onmicrosoft.com";
                 string password = "********";
  
                 using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(siteUrl, userName, password))
                 {
                     Web web = ctx.Web;
                     ctx.Load(web);
                     ctx.Load(web.Lists);
                     ctx.ExecuteQueryRetry();
                     List list = web.Lists.GetByTitle("List1");
                     ctx.Load(list);
                     ctx.ExecuteQueryRetry();
  
                     var tags = new string[] { "Term1", "Term2" };
  
                     var tagsString = EnsureTerms(tags, siteUrl, list.Id, "MyTaxonomyField",ctx);
  
   
                 }
             }
             catch (Exception ex) { }
         }
  
         public static string EnsureTerms(string[] termStrings, string targetUrl, Guid listId, string fieldName, ClientContext clientContext)
         {
             try
             {
                 //Get the List Object
                 var list = clientContext.Web.Lists.GetById(listId);
                 var field = list.Fields.GetByInternalNameOrTitle(fieldName);
                   
                 //Get the Taxonomy Field
                 var taxKeywordField = list.Context.CastTo<TaxonomyField>(field);
                 clientContext.Load(taxKeywordField);
                 clientContext.ExecuteQueryRetry();
                 clientContext.Load(taxKeywordField, f => f.TermSetId, f => f.SspId);
                 clientContext.ExecuteQueryRetry();
  
                 //From the TaxonomyField, get the TermSetID in which we are going to create the Terms.
                 var ssspId = taxKeywordField.SspId;
                 var termSetId = taxKeywordField.TermSetId;
  
                 //Get the TAxonomy Session
                 var taxSession = TaxonomySession.GetTaxonomySession(clientContext);
                 clientContext.Load(taxSession);
                 clientContext.ExecuteQueryRetry();
  
                 //Get the TermStore
                 var termStores = taxSession.TermStores;
                 clientContext.LoadQuery(termStores.Where(t => t.Id == ssspId));
                 clientContext.Load(termStores);
                 clientContext.ExecuteQueryRetry();
  
                 var termStore = termStores.FirstOrDefault(s => s.Id == ssspId);
                 clientContext.Load(termStore);
                 clientContext.ExecuteQueryRetry();
                  
                 //Get the TermSet
                 var termSet = termStore.GetTermSet(termSetId);
  
                 var allTerms = new List<Term>();
  
                 Func<string, Term> EnsureTerm = (term) =>
                 {
                     try
                     {
                         var allTermsInTermSet = termSet.GetAllTerms();
                         var results = clientContext.LoadQuery(allTermsInTermSet.Where(k => k.Name == term));
                         clientContext.ExecuteQueryRetry();
  
                         if (results != null)
                         {
                             var result = results.FirstOrDefault();
                             if (result != null)
                             {
                                 clientContext.Load(result, t => t.Name, t => t.Id);
                                 clientContext.ExecuteQueryRetry();
                                 return result;
                             }
                         }
  
                         clientContext.Load(termSet);
                         clientContext.ExecuteQueryRetry();
                         var newTerm = termSet.CreateTerm(term, termStore.DefaultLanguage, Guid.NewGuid());
                         termStore.CommitAll();
                         clientContext.Load(newTerm);
                         clientContext.Load(newTerm, t => t.Name, t => t.Id);
                         clientContext.ExecuteQueryRetry();
  
                         return newTerm;
                     }
                     catch (Exception ex)
                     {
                         if (ex.Message == "The data is not available. The query may not have been executed.")
                         {
                               
                             clientContext.Load(termSet);
  
                             clientContext.ExecuteQueryRetry();
                             var newTerm = termSet.CreateTerm(term, termStore.DefaultLanguage, Guid.NewGuid());
                             clientContext.Load(newTerm);
                             termStore.CommitAll();
                             clientContext.Load(newTerm);
                             clientContext.ExecuteQueryRetry();
                             clientContext.Load(newTerm, t => t.Name, t => t.Id);
                             clientContext.ExecuteQueryRetry();
                             return newTerm;
  
                         }
                         else
                         {
                               
  
                             throw;
                         }
                     }
                 };
  
                 foreach (string termString in termStrings)
                 {
                     try
                     {
                         Thread.Sleep(1000);
                         if (termString != null)
                         {
                             allTerms.Add(EnsureTerm(termString));
                         }
                     }
                     catch (Exception)
                     {
                         // Log the Exception
                     }
                 }
  
                 return GetTermsString(allTerms);
             }
             catch (Exception ex)
             {
                  //Log the Exception
             }
  
             return string.Empty;
         }
  
         public static string GetTermString(Term term)
         {
  
             if (term == null)
             {
                 new ArgumentNullException("term");
             }
  
  
             return string.Format("-1;#{0}{1}{2}", term.Name, "|", term.Id);
         }
  
         public static string GetTermsString(IEnumerable<Term> terms)
         {
             if (terms == null)
             {
                 new ArgumentNullException("terms");
             }
  
             var termsString = terms.Select(GetTermString).ToList();
             return string.Join(";#", termsString);
         }
     }
 }
