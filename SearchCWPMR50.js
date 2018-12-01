//https://www.eliostruyf.com/getting-past-the-cswp-item-limit-of-50-results/

AddPostRenderCallback(ctx, function() {
    // Get the DataProvider
    var dp = ctx.DataProvider;
    // Retrieve the number of items to show property (max. 50)
    var totalPerPage = dp.get_resultsPerPage();
    // Retrieve all properties
    var properties = dp.get_properties();
    // Check if the total results number is greater than the number of results that can be displayed max. of 50
    // check if the number of results that were retrieved is equal to the number to show
    // Check if the max. item limit (maxItems) is reached
    if (dp.get_totalRows() > totalPerPage && dp.get_rowCount() === totalPerPage && items.length < maxItems) {
        // Set the StartRow (skip results) property to skip the first batch
        properties["StartRow"] = $isNull(properties["StartRow"]) ? totalPerPage : properties["StartRow"] + totalPerPage;
        // Do the new query
        dp.issueQuery();
    } else {
        // Render the results if all are retrieved
        render();
        // Once all the items are rendered, we need to reset the array and delete the StartRow property
        items = [];
        delete properties.StartRow;
    }
});

var ListRenderRenderWrapper = function(itemRenderResult, inCtx, tpl) {
    // Add each search result item to the array
    search.retrieval.add(itemRenderResult);
    return '';
}

render = function () {
    var elm = document.getElementById(elmId);
    if (!$isNull(elm)) {
        // Check if the maximum item limit is exceeded 
        if (items.length > maxItems) {
            console.log(items.length);
            items = items.slice(0, maxItems);
        }
        elm.innerHTML = items.join('');
    }
}
