using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;

namespace Exemplo1.Layouts.Exemplos
{
    public partial class CarregaControles : LayoutsPageBase
    {

        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/Exemplo1/MostraListas.ascx";
                
       protected void Page_Load(object sender, EventArgs e)
       {
            frame.Controls.Add(this.Page.LoadControl(_ascxPath));


        }
    }
}
