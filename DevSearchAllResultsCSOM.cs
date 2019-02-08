KeywordQuery keywordQuery = new KeywordQuery(siteCollection);
SearchExecutor searchExecutor = new SearchExecutor();
keywordQuery.QueryText = "KQL Query String";
keywordQuery.StartRow = 0;
keywordQuery.RowLimit = 50;
//retrieve the first page of results
ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(keywordQuery);
var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);
var resultTable = resultTables.FirstOrDefault();
DataTable resultDataTable = resultTable.Table;
int currentRowIndex = 0;
//Iterate through the rest of the pages
while (resultTable.TotalRowsIncludingDuplicates > resultDataTable.Rows.Count)
{
    //Update the current row index
    currentRowIndex += resultDataTable.Rows.Count;
    resultTableCollection = GetSearchResults(keywordQuery, currentRowIndex, searchExecutor);
    var searchResults = resultTableCollection.FirstOrDefault();
    if (searchResults.RowCount <= 0)
        break;
    else
        resultDataTable.Merge(searchResults.Table);
}
private ResultTableCollection GetSearchResults(KeywordQuery keywordQuery, int startIndex, SearchExecutor searchExecutor)
{
  ResultTableCollection resultTableCollection = null;
  try
  {
    //keyword search using "Default Provider" .
    keywordQuery.ResultsProvider = SearchProvider.Default;
    keywordQuery.StartRow = startIndex;//gets or sets the first row of information from the search results
    // execute the query and load the results into a collection
    resultTableCollection = searchExecutor.ExecuteQuery(keywordQuery);
  }
  catch (Exception ex)
  {
  }
  return resultTableCollection;
}
