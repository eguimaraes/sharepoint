using (SPSite site = SPContext.Current.Site)
 {
 using (SPWeb web = site.OpenWeb())
                 {
 // Allow Unsafe Updates to prevent the cross site scripting
 web.AllowUnsafeUpdates = true;
 // Get The SPList
 SPList list = web.Lists["List Name"];
 // Add a new list item
 SPListItem item = list.Items.Add();
 // Set the default Title field
 item["Title"] = "String Value";
 //Set the Lookup Field - Single Value
 item["The Lookup Field Name"] = new SPFieldLookupValue("A 32-bit integer that specifies the ID of the lookup field", "A string that contains the value of the lookup field");
 // Submit your Item
 item.Update();
 web.AllowUnsafeUpdates = false;
                 }
  
 }
