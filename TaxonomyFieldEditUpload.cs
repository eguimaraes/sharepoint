//Original at http://www.sharepointpals.com/post/How-to-Update-the-Taxonomy-Field-(Single-Value-or-Multiple-Value)-using-C-Patterns-and-Practices-in-SharePoint-Office-365
public static void AddTaxonomyEntry()
         {
             try
             {
                 OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
  
                 string siteUrl = "https://*****.sharepoint.com/sites/DeveloperSite";
                 string userName = "Sathish@*********.onmicrosoft.com";
                 string password = "******";
  
                 using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(siteUrl, userName, password))
                 {
                     Web web = ctx.Web;
                     ctx.Load(web);
                     ctx.Load(web.Lists);
                     ctx.ExecuteQueryRetry();
                     List list = web.Lists.GetByTitle("List1");
                     ctx.Load(list);
                     ctx.ExecuteQueryRetry();
  
                     var tags = new string[] { "Term2"};
  
                     var tagsString = EnsureTerms(tags, siteUrl, list.Id, "TaxonomyField",ctx);
  
  
                     ListItem listItem = list.AddItem(new ListItemCreationInformation());
                     listItem["Title"] = "Test Title";
                     listItem.Update();
  
                     ctx.Load(listItem);
                     ctx.ExecuteQuery();
  
                     var clientRuntimeContext = listItem.Context;
                      
                     var field = list.Fields.GetByInternalNameOrTitle("TaxonomyField");
                     var taxKeywordField = clientRuntimeContext.CastTo<TaxonomyField>(field);
  
                     TaxonomyFieldValue termValue = new TaxonomyFieldValue();
                     string[] term = tagsString.Split('|');
                     termValue.Label = term[0];
                     termValue.TermGuid = term[1];
                     termValue.WssId = -1;
                     taxKeywordField.SetFieldValueByValue(listItem, termValue);
  
                     taxKeywordField.Update();
  
                     listItem.Update();
                     ctx.Load(listItem);
                     ctx.ExecuteQuery();
                 }
             }
             catch (Exception ex) { }
         }
