using System;    
using System.Collections.Generic;    
using System.Linq;    
using System.Text;    
using Microsoft.SharePoint.Client;    
using System.Data;    
using Microsoft.SharePoint;    
namespace ConsoleApplication5 {    
    class Program {    
        static void Main(string[] args) {    
            ClientContext context = new ClientContext("siteName");    
            // ListName - child List of Lookup column    
            List list = context.Web.Lists.GetByTitle("ListName");    
            ListItem item;    
            context.Load(list);    
            context.ExecuteQuery();    
            string strLookupValue = "LookupValue";    
            if (strLookupValue != "") {    
                try {    
                    //LookupList - name of parent list from which we taking value    
                    List lookuplist = context.Web.Lists.GetByTitle("LookupList");    
                    item["LookColumnName"] = GetLookFieldIDS(context, strLookupValue, lookuplist);    
                } catch (Exception e) {    
                    item["LookColumnName"] = "";    
                    Console.WriteLine(e.Message);    
                    Console.ReadLine();    
                }    
            } else {    
                item["LookColumnName"] = "";    
            }    
            item.Update();    
            context.ExecuteQuery();    
        }    
        public static SPFieldLookupValueCollection GetLookFieldIDS(ClientContext context, string lookupValues, List lookupSourceList) {    
            SPFieldLookupValueCollection lookupIds = new SPFieldLookupValueCollection();    
            string[] lookups = lookupValues.Split(new char[] {    
                    ','    
                },    
                StringSplitOptions.RemoveEmptyEntries);    
            foreach(string lookupValue in lookups) {    
                CamlQuery query = new CamlQuery();    
                query.ViewXml = string.Format("<View><Query><Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where></Query></View>", lookupValue);    
                ListItemCollection listItems = lookupSourceList.GetItems(query);    
                context.Load(lookupSourceList);    
                context.Load(listItems);    
                context.ExecuteQuery();    
                foreach(ListItem item in listItems) {    
                    SPFieldLookupValue value = new SPFieldLookupValue(Convert.ToInt32(item["ID"]), item["Title"].ToString());    
                    lookupIds.Add(value);    
                    break;    
                }    
            }    
            return lookupIds;    
        }    
    }    
}    
