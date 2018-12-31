function GetItem(title){
var siteUrl=_spPageContextInfo.webAbsoluteUrl;
var clientContext = new SP.ClientContext(siteUrl);
var web = clientContext.get_web();
var oList = clientContext.get_web().get_lists().getByTitle("ListName");
clientContext.load(web); 
clientContext.load(oList);
clientContext.executeQueryAsync(
function () {

                        location.href = web.get_url()+"URLFinal";
                    },

                    function () {alert('Erro')
                    
                    } 
varItem=
}
