var siteUrl = '/sites/MySiteCollection ';

function retrieveAllUsersAllGroups() {

    var clientContext = new SP.ClientContext(siteUrl);
    this.collGroup = clientContext.get_web().get_siteGroups();
    clientContext.load(collGroup);
    clientContext.load(collGroup, 'Include(Users)');

    clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
}

function onQuerySucceeded() {

    var userInfo = '';

    var groupEnumerator = collGroup.getEnumerator();
    while (groupEnumerator.moveNext()) {
        var oGroup = groupEnumerator.get_current();
        var collUser = oGroup.get_users();
        var userEnumerator = collUser.getEnumerator();
        while (userEnumerator.moveNext()) {
            var oUser = userEnumerator.get_current();
            this.userInfo += '\nGroup ID: ' + oGroup.get_id() + 
                '\nGroup Title: ' + oGroup.get_title() + 
                '\nUser: ' + oUser.get_title() + 
                '\nLogin Name: ' + oUser.get_loginName();
        }
    }
        
    alert(userInfo);
}

function onQueryFailed(sender, args) {

    alert('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace());
}
