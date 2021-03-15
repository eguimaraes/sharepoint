using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.IO;


namespace RobotCarga
{
    class Program
    {
        static void Main(string[] args)
        {


            StreamReader readerCampos = new StreamReader(args[3]);

            string[] campos = readerCampos.ReadToEnd().Split(',');

            using(SPSite site=new SPSite(args[0]))
            {

                SPList list = site.RootWeb.Lists[args[1]];

                SPListItem item = list.Items.Add();

                StreamReader reader = new StreamReader(args[2]);

                string linha = string.Empty;
               
                while ((linha = reader.ReadLine()) != null)
                {


                    string[] dados = linha.Split(',');
                    
                   for(int i=0;i<campos.Length;i++)
                    {

                        item[campos[i]] = dados[i];

                }

                    item.Update();

                }                


                



            }


        }
    }
}
