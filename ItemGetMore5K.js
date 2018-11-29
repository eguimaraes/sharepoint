//original em https://codewithrohit.wordpress.com/2017/06/01/sharepoint-rest-api/

//.webAbsoluteUrl + "/_api/web/lists/getbytitle('myList')/items?$top=1000 - menos que 5k

var url = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getbytitle('DocumentList')/items?$top=1000";
    var response = response || [];  // this variable is used for storing list items
    function GetListItems(){
        $.ajax({
            url: url,  
            method: "GET",  
            headers: {  
                "Accept": "application/json; odata=verbose"  
            },
            success: function(data){
                response = response.concat(data.d.results);
                if (data.d.__next) {
                    url = data.d.__next;
                    GetListItems();
                }
            },
            error: function(error){
                   // error handler code goes here
            }
        });
    }
