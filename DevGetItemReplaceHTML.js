function GetItem(list,title,field,obj,prefixosufixo){
var retorno  
var siteUrl=_spPageContextInfo.webAbsoluteUrl;
var clientContext = new SP.ClientContext(siteUrl);
var web = clientContext.get_web();
var oList = clientContext.get_web().get_lists().getByTitle(list);
var camlQuery = new SP.CamlQuery();
camlQuery.set_viewXml('<View><Query><Where><Eq><FieldRef Name=\'Title\'/><Value Type=\'Text\'>"+title+"</Value></Eq></Where></Query><RowLimit>1000</RowLimit></View>');
  this.collListItem = oList.getItems(camlQuery);
        
    clientContext.load(collListItem);
  
  
clientContext.load(web); 
clientContext.load(oList);
  clientContext.load(collListItem);
  
clientContext.executeQueryAsync(
function () {

var listItemEnumerator = collListItem.getEnumerator();        
    while (listItemEnumerator.moveNext()) {
        var oListItem = listItemEnumerator.get_current();
      
         document.getElementById(obj).innerHTML=sufixo+oListItem.get_item(field)+prefixo;
          
      
           break; 
    }
        },

                    function () {alert('Erro') } 
  
  
  
  )

}
