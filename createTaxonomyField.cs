//Original at http://programsharepoint.blogspot.com/2013/10/create-managed-metadata-field-using.html

using System;
using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.IO;
 using System.Net;
 using Microsoft.SharePoint.Client;
 using Microsoft.SharePoint.Client.Taxonomy;
 
 namespace CreateSPManagedMetadataField
 {
        class Program
        {
            static void Main(string[] args)
            {
                List<string[]> spSiteColumns = new List<string[]>();
                //Site Column Internal Name, Display Name, Type, Term Set Name
                spSiteColumns.Add(new string[] { "JobTitle", "Job Title", "TaxonomyFieldType", "TermSet1" });
                CreateSPTaxFields(spSiteColumns);
            }
    
            static void CreateSPTaxFields(List<string[]> listOfColumns)
            {
                using (ClientContext clientContext = new ClientContext(ConfigurationConstants.XYZSharepointSiteCollectionUrl))
                {
                    NetworkCredential credentials = new NetworkCredential(ConfigurationConstants.XYZSharepointAdminUserName,
                        ConfigurationConstants.XYZSharepointAdminUserPassword, ConfigurationConstants.XYZSharepointDomain);
                    clientContext.Credentials = credentials;
    
                    Web web = clientContext.Web;
                    clientContext.Load(web, w => w.AvailableFields);
                    clientContext.ExecuteQuery();
                    FieldCollection collFields = web.AvailableFields;
    
                    foreach (string[] spColumn in listOfColumns)
                    {
                        bool spColumnAlreadyCreated = false;
                        foreach (Field spField in collFields)
                        {
                            if (spColumn[0].ToLower() == spField.InternalName.ToLower())
                            {
                                spColumnAlreadyCreated = true;
                                break;
                            }
                        }
                        if (!spColumnAlreadyCreated) // if sharepoint site column not alredy created, create now
                        {
                            string spColumnType = spColumn[2];
                            if (spColumnType == "TaxonomyFieldType")
                            {
                                string columnTaxonomyGenericSchema = @"<Field Type='TaxonomyFieldType' Name='{0}' DisplayName='{1}' ShowField='Term1033'   />";
                                string columnTaxonomySchema = string.Format(columnTaxonomyGenericSchema, spColumn[0], spColumn[1]);
    
                                var session = TaxonomySession.GetTaxonomySession(clientContext);
                                var store = session.TermStores.GetByName(ConfigurationConstants.XYZTermStoreName);
                                var group = store.Groups.GetByName(ConfigurationConstants.XYZTermGroupName);
                                var set = group.TermSets.GetByName(spColumn[3]);
    
                                clientContext.Load(store, s => s.Id);
                                clientContext.Load(set, s => s.Id);
                                clientContext.ExecuteQuery();
    
    
                                var taxField = web.Fields.AddFieldAsXml(columnTaxonomySchema, false, AddFieldOptions.DefaultValue);
                                clientContext.Load(taxField);
                                clientContext.ExecuteQuery();
    
   var taxfield2 = clientContext.CastTo<TaxonomyField>(taxField);
                                taxfield2.SspId = store.Id;
                                taxfield2.TermSetId = set.Id;
                                taxfield2.Update();
                                clientContext.ExecuteQuery();
                                //LogMessages.Instance.LogMessageToTextFile(" Site column " + spColumn[0] + " type " + spColumn[2] + " succesfully created ");
                            }
    
                        }
                        else
                        {
                            //LogMessages.Instance.LogMessageToTextFile(" Site column " + spColumn[0] + " was already created ");
                        }
   }
   }
   }
   public class ConfigurationConstants
            {
                public static string XYZLogFileLocation = @"C:\\LogFile.txt";
                public static string XYZSharepointSiteCollectionUrl = "http://sharepointservername:100/";
                public static string XYZSharepointDomain = "domainName";
                public static string XYZSharepointAdminUserName = "UserName";
                public static string XYZSharepointAdminUserPassword = "Password";
                public static string XYZSharepointSiteColumsGroupName = "XYZ Site Columns";
                public static string XYZTermStoreName = "Managed Metadata Service";
                public static string XYZTermGroupName = "HR";
    
            }
        }
    }
    
