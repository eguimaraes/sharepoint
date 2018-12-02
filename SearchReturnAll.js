//Original em https://gist.github.com/vgrem/520df74f8251506ca2e9

function search(webUrl,queryText,rowLimit,startRow,allResults)
{
    var allResults = allResults || [];
    var url = webUrl + "/_api/search/query?querytext='" + queryText + "'&rowlimit=" + rowLimit + "'&startrow=" + startRow;
    return $.getJSON(url).then(function(data) {
           var relevantResults = data.PrimaryQueryResult.RelevantResults;
           allResults = allResults.concat(relevantResults.Table.Rows);
           if (relevantResults.TotalRows > startRow + relevantResults.RowCount) {
               return search(webUrl,queryText,rowLimit,startRow+relevantResults.RowCount,allResults);
           }    
           return allResults;
    });
}
