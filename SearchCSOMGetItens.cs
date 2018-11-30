  public ClientResult<ResultTableCollection> GetItens(ClientContext clientContext, string keywordQueryTxt) {

            int[] Ids = new int[] { };
           

            KeywordQuery keywordQuery = new KeywordQuery(clientContext);
            keywordQuery.QueryText = keywordQueryTxt;
            SearchExecutor searchExecutor = new SearchExecutor(clientContext);
            ClientResult<ResultTableCollection> results = searchExecutor.ExecuteQuery(keywordQuery);
            clientContext.ExecuteQuery();


            return results;


        }
