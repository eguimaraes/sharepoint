function GetItem(list,title,field){
var retorno  
var siteUrl=_spPageContextInfo.webAbsoluteUrl;
var clientContext = new SP.ClientContext(siteUrl);
var web = clientContext.get_web();
var oList = clientContext.get_web().get_lists().getByTitle(list);
var camlQuery = new SP.CamlQuery();
  camlQuery.set_viewXml("<View><Query>Where><Eq><FieldRef Name=\"Title\" /><Value Type=\"Text\">"+title+"</Value></Eq></Where></Query><RowLimit>10</RowLimit></View>");
alert(camlQuery.text);
  var collListItem = oList.getItems(camlQuery);
clientContext.load(web); 
clientContext.load(oList);
  clientContext.load(collListItem);
  
clientContext.executeQueryAsync(
function () {

var listItemEnumerator = collListItem.getEnumerator();        
    while (listItemEnumerator.moveNext()) {
        var oListItem = listItemEnumerator.get_current();
      
           retorno= oListItem.get_item(field);
            alert(retorno);
    }

                    },

                    function () {alert('Erro') } 
  
  
  
  )
return retorno
}
