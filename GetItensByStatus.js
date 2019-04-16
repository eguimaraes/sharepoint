function GetItem(list, fieldTitle, fieldValue) {
    var retorno;
    var siteUrl = _spPageContextInfo.webAbsoluteUrl;
    var clientContext = new SP.ClientContext(siteUrl);
    var web = clientContext.get_web();
    var oList = clientContext.get_web().get_lists().getByTitle(list);
    var camlQuery = new SP.CamlQuery();
    camlQuery.set_viewXml(ViewXml = "<View><Query><Where><Eq><FieldRef Name='" + fieldTitle + "' /><Value Type='Text'>" + fieldValue + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy></Query></View>");    
    alert(camlQuery.get_viewXml());
    var collListItem = oList.getItems(camlQuery);
    clientContext.load(web);
    clientContext.load(oList);
    clientContext.load(collListItem);

    clientContext.executeQueryAsync(
        function () {

            var listItemEnumerator = collListItem.getEnumerator();
            while (listItemEnumerator.moveNext()) {
                var oListItem = listItemEnumerator.get_current();

                retorno = oListItem.get_item(fieldTitle);
                alert(retorno);
            }

        },

        function () { alert('Erro') }



    )
    return retorno
}
