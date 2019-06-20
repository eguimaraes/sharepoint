var siteUrl = '/sites/MySiteCollection';

function deleteListItemDisplayCount() {

    this.clientContext = new SP.ClientContext(siteUrl);
    this.oList = clientContext.get_web().get_lists().getByTitle('Announcements');

    clientContext.load(oList);

    clientContext.executeQueryAsync(Function.createDelegate(this, this.deleteItem), Function.createDelegate(this, this.onQueryFailed));
}

function deleteItem() {

    this.itemId = 58;
    this.startCount = oList.get_itemCount();
    this.oListItem = oList.getItemById(itemId);

    oListItem.deleteObject();

    oList.update();

    clientContext.load(oList);
        
    clientContext.executeQueryAsync(Function.createDelegate(this, this.displayCount), Function.createDelegate(this, this.onQueryFailed));
}

function displayCount() {

    var endCount = oList.get_itemCount();
    var listItemInfo = 'Item deleted: ' + itemId + 
        '\nStart Count: ' +  startCount + ' End Count: ' + endCount;
        
    alert(listItemInfo)
}

function onQueryFailed(sender, args) {

    alert('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}
