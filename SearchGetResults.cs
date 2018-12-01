// Original em https://usefulscripts.wordpress.com/2015/09/11/how-to-fetch-all-results-from-sharepoint-search-using-dot-net-managed-csom/

private static ResultTable GetSearchResults(int startIndex,
ClientContext clientContext)
{
ClientResult<ResultTableCollection> results = null;
try
{
KeywordQuery keywordQuery = new KeywordQuery(clientContext);

SearchExecutor searchExecutor = new SearchExecutor(clientContext);

keywordQuery.StartRow = startIndex;//gets or sets the first row of information from the search results

//Specif the ext you want to search
keywordQuery.QueryText = “SharePoint”;

//Specify the number of rows to return, 500 is MAX
keywordQuery.RowLimit = 500;
//Specify the number of rows to return in a page, 500 is MAX
keywordQuery.RowsPerPage = 500;
//Whether to remove duplicate results or not
keywordQuery.TrimDuplicates = false;
//Specify the timeout
keywordQuery.Timeout = 10000; //10 minutes

// execute the query and load the results into a collection
results = searchExecutor.ExecuteQuery(keywordQuery);
clientContext.ExecuteQuery();

return results.Value.FirstOrDefault(v => v.TableType.Equals(KnownTableTypes.RelevantResults));
}
catch (Exception)
{
throw;
}
}


static void Main(string[] args)
{
using (ClientContext clientContext = new ClientContext(“<<YOUR SERVER URL>>”))
{
#region Build Data Dable
DataTable resultDataTable = new DataTable();

DataColumn titleCol = new DataColumn(“Title”);
DataColumn pathCol = new DataColumn(“Path”);

resultDataTable.Columns.Add(titleCol);
resultDataTable.Columns.Add(pathCol);

#endregion

int currentRowIndex = 0;

//Get the first block of results
var resultTable = GetSearchResults(0, clientContext);

if (null != resultTable && resultTable.TotalRowsIncludingDuplicates > 0)
{
while (resultTable.TotalRowsIncludingDuplicates > resultDataTable.Rows.Count)
{
foreach (var resultRow in resultTable.ResultRows)
{
DataRow row = resultDataTable.NewRow();
row[“Title”] = resultRow[“Title”];
row[“Path”] = resultRow[“Path”];
resultDataTable.Rows.Add(row);
}

//Update the current row index
currentRowIndex = resultDataTable.Rows.Count;

resultTable = null;

resultTable = GetSearchResults(currentRowIndex, clientContext);

if (null != resultTable && resultTable.TotalRowsIncludingDuplicates > 0)
{
if (resultTable.RowCount <= 0)
break;
}
else
break;
}
}

Console.WriteLine(“Total Results: {0} “, resultDataTable.Rows.Count);
}
Console.ReadLine();
}

