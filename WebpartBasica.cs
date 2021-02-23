using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Exemplo1.WebPartBasica
{
    [ToolboxItemAttribute(false)]
    public class WebPartBasica : WebPart
    {
        protected override void CreateChildControls()
        {
            string iframe = "<iframe src=\"http://www.b3.com.br/pt_br/market-data-e-indices/servicos-de-dados/market-data/cotacoes/?symbol=IBXX\">";
            this.Controls.Add(new LiteralControl(iframe));

        }

               

    }
}
