function AddListItem()  
{  
    var industryVal = $("#Industry").val();  
    var Company = $("#Company").val();  
    $.ajax  
        ({  
        url: _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/GetByTitle('companyInfo')/items",  
        type: "POST",  
        data: JSON.stringify  
        ({  
            __metadata:  
            {  
                type: "SP.Data.TestListItem"  
            },  
            Company: Company,  
            Industry: industryVal  
        }),  
        headers:  
        {  
            "Accept": "application/json;odata=verbose",  
            "Content-Type": "application/json;odata=verbose",  
            "X-RequestDigest": $("#__REQUESTDIGEST").val(),  
            "X-HTTP-Method": "POST"  
        },  
        success: function(data, status, xhr)  
        {  
            retriveListItem();  
        },  
        error: function(xhr, status, error)  
        {  
            $("#ResultDiv").empty().text(data.responseJSON.error);  
        }  
    });  
}  
