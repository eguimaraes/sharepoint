function getListItems(listName, siteurl, success, failure) {
    $.ajax({
        url: siteurl + "/_api/web/lists/getbytitle('" + listName + "')/items",
        method: "GET",
        headers: { "Accept": "application/json; odata=verbose" },
        success: function (data) {
            success(data);
        },
        error: function (data) {
            failure(data);
        }
    });
}
