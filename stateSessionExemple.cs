// Storing Username in session.Session[ "UserName" ] = txtUser.Text;  
// Retreiving  
values  
from  
session.// Check whether session variable null  
or not if(Session[ "UserName" ] != null) { // Retreiving UserName  
from  
session lblWelcome.text = "Welcome: +Session[" UserName "];  
}  
else  
{  
//Do something else  
}  

protected void btnSubmit_Click(object sender, EventArgs e)  
{  
   Session["UserName"] = txtUserName.Text.ToString();  
   Response.Redirect("Home.aspx");  
}  

protected void Page_Load(object sender, EventArgs e)   
{  
    if (Session["UserName"] != null && Session["UserName"] != "")   
    {  
        lblUserName.InnerText = Session["UserName"].ToString();  
    }   
    else   
    {  
        lblUserName.InnerText = "Anonymous User";  
    }  
