using Microsoft.SharePoint;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using System;

namespace Exemplo1.Layouts.Exemplo1
{
    public partial class AppPage : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            Table tabelaLista = new Table();
            divtabelaListas.Controls.Add(tabelaLista);

            tabelaLista.CssClass = "table table-striped w-75 p-3 mb-2 border";

            TableCell cellHeader = new TableCell();
            cellHeader.CssClass = "w-50";
            cellHeader.Controls.Add(new LiteralControl($"<span>Nome da Lista</span>"));

            TableCell cellHeader2 = new TableCell();
            cellHeader2.CssClass = "w-50";
            cellHeader2.Controls.Add(new LiteralControl($"<span>Numero de Itens</span>"));

            TableRow row = new TableRow();
            row.Cells.Add(cellHeader);
            row.Cells.Add(cellHeader2);
            tabelaLista.Rows.Add(row);


            SPListCollection listCollection = web.Lists;

            foreach (SPList list in listCollection)
            {
                MostraListas(list, tabelaLista);

            }
        }

        private void MostraListas(SPList list,Table tabelaLista)
        {
            

            TableCell cell = new TableCell();
            cell.CssClass = "col-md-4";
            cell.Controls.Add(new LiteralControl($"<span id='{ list.Title }'>{list.Title}</span>"));

            TableCell cell2 = new TableCell();
            cell2.CssClass = "col-md-4";
            cell2.Controls.Add(new LiteralControl($"<span>{list.ItemCount}</span>"));


            TableRow row = new TableRow();
            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            tabelaLista.Rows.Add(row);
        }
    }
}
