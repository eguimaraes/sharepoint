using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;
using System.Net;
using System.IO;
namespace TableauWP.PlatinumTableauWP
{
    public partial class PlatinumTableauWPUserControl : UserControl
    {
        private HtmlGenericControl _iframe = null;
        private String _tabserver = "";
        private String _tabpath = "";
        private Boolean _tabtoolbar = true;
        private Boolean _tabtrusted = false;
        private Boolean _tabimage = false;
        private Boolean _tabssl = false;
        private String _tabimgw = "";
        private String _tabimgh = "";
        private Label _lbl = null;


        protected void Page_Load(object sender, EventArgs e)
        {

            

           


        }



        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            string server = "http://3333333";

            string user = "user_dc";

            string token = GetTableauTicket(server, user);

            string src = server + "/trusted/" + token + "/views/viewURL:showVizHome=no&:embed=true";

            _iframe = new HtmlGenericControl("iframe");

            this.Controls.Add(_iframe);

            _iframe.Attributes.Add("width", "1600px");
            _iframe.Attributes.Add("height", "1500px");
            _iframe.Attributes.Add("scrolling", "auto");
            _iframe.Attributes.Add("frameborder", "0");
            _iframe.Attributes.Add("src",src);

            base.CreateChildControls();
        }


        string GetTableauTicket(string tabserver, string tabuser)
        {
            ASCIIEncoding enc = new ASCIIEncoding();
            string postData = "username=" + tabuser + "&client_ip=" + Page.Request.UserHostAddress;
            byte[] data = enc.GetBytes(postData);

            try
            {
                            

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(tabserver + "/trusted");

                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;

            
                Stream outStream = req.GetRequestStream();
                outStream.Write(data, 0, data.Length);
                outStream.Close();

            
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader inStream = new StreamReader(res.GetResponseStream(), enc);
                string resString = inStream.ReadToEnd();
                inStream.Close();

                return resString;
            }
            
            catch (Exception ex)
            {
                
                return ex.ToString();
            }
        }


    }
}
