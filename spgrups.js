var siteUrl = '/sites/MySiteCollection ';

function retrieveAllUsersInGroup() {

    var clientContext = new SP.ClientContext(siteUrl);
    var collGroup = clientContext.get_web().get_siteGroups();
    var oGroup = collGroup.getById(7);
    this.collUser = oGroup.get_users();
    clientContext.load(collUser);


    clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
}

function onQuerySucceeded() {

    var userInfo = '';

    var userEnumerator = collUser.getEnumerator();
    while (userEnumerator.moveNext()) {
        var oUser = userEnumerator.get_current();
        this.userInfo += '\nUser: ' + oUser.get_title() + 
            '\nID: ' + oUser.get_id() + 
            '\nEmail: ' + oUser.get_email() + 
            '\nLogin Name: ' + oUser.get_loginName();
    }
      
    alert(userInfo);
}

function onQueryFailed(sender, args) {

    alert('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}
