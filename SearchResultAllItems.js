//http://www.thesharepointguide.com/sharepoint-search-how-to-return-all-results/
var allResults;
function yourFunction() {
  var searchUrl = _spPageContextInfo.webAbsoluteUrl + "/_api/search/postquery";
  postData = {
    'request': {
      '__metadata': { 'type': 'Microsoft.Office.Server.Search.REST.SearchRequest' },
      'Querytext': "sharepoint",
      'RowLimit': '50',
      'SortList':
      {
        'results': [
            {
              'Property': 'Created',
              'Direction': '1'
            }
        ]
      }
    }
  };
  allResults = [];
  searchSharePoint(searchUrl, 0);
}
function searchSharePoint(searchUrl, startRow, allResults) {
  //initialize to empty array if it does not exist
  allResults = allResults || [];
  postData.request.StartRow = startRow;
  $.ajax(
  {
    type: "POST",
    headers: {
      "accept": "application/json;odata=verbose",
      "content-type": "application/json;odata=verbose",
      "X-RequestDigest": $("#__REQUESTDIGEST").val()
    },
    data: JSON.stringify(postData),
    url: searchUrl,
    success: onQuerySuccess,
    error: onQueryFail
  });
}
function onQuerySuccess(data) {
  var searchUrl = _spPageContextInfo.webAbsoluteUrl + "/_api/search/postquery";
  var results = data.d.postquery.PrimaryQueryResult.RelevantResults;
  allResults = allResults.concat(results.Table.Rows.results);
  if (results.TotalRows > postData.request.StartRow + results.RowCount) {
    reportSearch(searchUrl, postData.request.StartRow + results.RowCount, allResults);
  }
  else if (allResults != null && allResults.length > 0) {
    //process allResults
  }
  else {
    if (reportDataTable != null) {
      reportDataTable = [];
    }
    // Show Message No results found
  }
}
function onQueryFail(data, errorCode, errorMessage) {
  //log error message
}
