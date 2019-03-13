 public static void UpdateListitemLookup()
 {
            ClientContext clientContext = new ClientContext("http://basesmc2008");
            List list = clientContext.Web.Lists.GetByTitle("tester2");
            FieldCollection fields = list.Fields;
            CamlQuery camlQueryForItem = new CamlQuery();
            camlQueryForItem.ViewXml = @"<View>
                                    <Query>
                                        <Where>
                                            <Eq>
                                                <FieldRef Name='ID'/>
                                                <Value Type='Counter'>6</Value>
                                            </Eq>
                                        </Where>
                                    </Query>
                                </View>";
            ListItemCollection listItems = list.GetItems(camlQueryForItem);
            clientContext.Load(listItems, items => items.Include
                                            (item => item["wlookup"],
                                             item => item["Editor"],
                                             item => item["Title"]));
            clientContext.ExecuteQuery();
            ListItem itemToUpdate = listItems[0];
            FieldLookupValue lv = itemToUpdate["wlookup"] as FieldLookupValue;
            lv.LookupId = 16;
            itemToUpdate["wlookup"] = lv;
            itemToUpdate.Update();
            clientContext.Load(itemToUpdate);
            clientContext.ExecuteQuery();
        }
