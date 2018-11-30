//https://sharepoint.stackexchange.com/questions/153705/sharepoint-search-client-object-model-and-server-side-object-model
static void Main(string[] args)
            {
                Guid PeopleSearch = new Guid("b09a7990-05ea-4af9-81ef-edfab16c4e31");
    using(SPSite site = new SPSite("http://portal.conium.com/sites/testSearch"))
                {
     KeywordQuery keywordQuery = new KeywordQuery(site);
                        keywordQuery.SourceId = PeopleSearch;
                        keywordQuery.EnableNicknames = true;
                        keywordQuery.EnablePhonetic = true;
                        keywordQuery.RankingModelId = "D9BFB1A1-9036-4627-83B2-BBD9983AC8A1";
                        keywordQuery.TrimDuplicates = false;
                        keywordQuery.QueryText = "Sps";
    SearchExecutor searchExecutor = new SearchExecutor();
                        ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(keywordQuery);
                        var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
                        var resultTable = resultTables.FirstOrDefault();
    DataTable dataTable = resultTable.Table;
    for (int i = 0; i < rowCount;i++)
                        {
                            Console.WriteLine("Path" + " : {0}",dataTable.Rows[i]["Path"].ToString());
                        }
                 }
           }
