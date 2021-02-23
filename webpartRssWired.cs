using System;
using System.IO;
using System.Web;
using System.Net;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;


namespace Exemplo1.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualWebPart1()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            renderRss("https://www.wired.com/feed/rss");

        }

        private void renderRss(string rssUrl)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(GetRss(rssUrl));
            XmlNodeList list = document.GetElementsByTagName("item");
            foreach (XmlNode node in list)
            {
                Node2HTML(node);

            }
        }


        private void Node2HTML(XmlNode node)
        {
           

            string imgSrc = node["media:thumbnail"].GetAttribute("url");
            string htmlTemplate= "<div class=\"card t-4 rounded \" style=\"float:left; height:500px;margin-right:10px;margin-bottom:10px;min-width:30%;width:30%;padding:0px\">" +
                "<img class=\"card-img-top\" src=\"" + imgSrc + "\" alt=\"Card image cap\" style=\"margin:auto;height:200px\">" +
                "<div class=\"card-body\">" +
                "<h5 class=\"card-title\">"+ node["title"].InnerText + "</h5>" +
                "<p class=\"card-text\" style=\"min-height:60%\">"+ node["description"].InnerText + "</p>" +
                "<a  href = \""+ node["link"].InnerText + "\" class=\"btn btn-danger  btn-lg\">Ler Artigo" +
                "</a>" +
                "</div>" +
                "</div>";
        
            frameBasico.Controls.Add(new LiteralControl(htmlTemplate));
        }

        

        private static string GetRss(string Rssurl)
        {
            WebRequest request = WebRequest.Create(Rssurl);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusDescription;
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string dados = responseFromServer;
            reader.Close();
            dataStream.Close();
            response.Close();
            return dados;
        }
    }
}
