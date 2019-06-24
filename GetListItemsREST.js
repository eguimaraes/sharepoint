function retriveListItem()  
{  
  
    $.ajax  
    ({  
        url: _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('companyInfo')/items?$select=Company,Industry",  
        type: type,  
        data: data,  
        headers:  
        {  
            "Accept": "application/json;odata=verbose",  
            "Content-Type": "application/json;odata=verbose",  
            "X-RequestDigest": $("#__REQUESTDIGEST").val(),  
            "IF-MATCH": "*",  
            "X-HTTP-Method": null  
        },  
        cache: false,  
        success: function(data)   
        {  
            $("#ResultDiv").empty();  
            for (var i = 0; i < data.d.results.length; i++)   
            {  
                var item = data.d.results[i];  
                $("#ResultDiv").append(item.Company + "\t" + item.Industry + "<br/>");  
            }  
        },  
        error: function(data)  
        {  
            $("#ResultDiv").empty().text(data.responseJSON.error);  
        }  
    });  
}  
