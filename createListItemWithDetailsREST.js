function createListItemWithDetails(listName, siteUrl, title, success, failure) {
 
    var itemType = GetItemTypeForListName(listName);
    var item = {
        "__metadata": { "type": itemType },
        "Title": title
    };
 
    $.ajax({
        url: siteUrl + "/_api/web/lists/getbytitle('" + listName + "')/items",
        type: "POST",
        contentType: "application/json;odata=verbose",
        data: JSON.stringify(item),
        headers: {
            "Accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val()
        },
        success: function (data) {
            success(data);
        },
        error: function (data) {
            failure(data);
        }
    });
}
