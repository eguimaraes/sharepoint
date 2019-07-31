    private string getField()
        {
            string Field = "";

            using (SPWeb web = SPContext.Current.Site.RootWeb)
            {

                SPList config = web.Lists["List"];

                SPQuery sPQuery = new SPQuery()
                {
                    Query = @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>REF</Value></Eq></Where>"
                };
                                
                SPListItem sPListItem = config.GetItems()[0];

                tableauID = sPListItem[Valor].ToString();


            }


            return Field;
        }
