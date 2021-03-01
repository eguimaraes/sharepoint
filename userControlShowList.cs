using System;
using Microsoft.SharePoint;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Exemplo1.ControlTemplates.Exemplos
{
    public partial class MostraListas : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            foreach (SPList list in SPContext.Current.Web.Lists)
            {
                string htmlTemplate = "<div class=\"card t-4 rounded \" style=\"float:left; height:500px;margin-right:10px;margin-bottom:10px;min-width:30%;width:30%;padding:0px\">" +
               "<img class=\"card-img-top\" src=\"" + list.ImageUrl + "\" alt=\"Card image cap\" style=\"margin:auto;height:200px\">" +
               "<div class=\"card-body\">" +
               "<h5 class=\"card-title\">" +list.Title + "</h5>" +
               "<p class=\"card-text\" style=\"min-height:60%\">" + list.Description + "</p>" +
               "<a  href = \"" +list.DefaultViewUrl + "\" class=\"btn btn-danger  btn-lg\">Ver Lista" +
                "<a  href = \"http://shplab/_layouts/15/listedit.aspx?List={" + list.ID + "}\" class=\"btn btn-danger  btn-lg\">Administrar Lista" +
               "</a>" +
               "</div>" +
               "</div>";


                Painel.Controls.Add(new LiteralControl(htmlTemplate));



            }


        }
    }
}
