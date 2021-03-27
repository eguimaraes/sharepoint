using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using Microsoft.SharePoint.Client;

namespace RobotClientSidecarga
{
    class Program
    {
        static void Main(string[] args)
        {

                      
            using (ClientContext clientContext = new ClientContext("urldosite")) { 
                       

            clientContext.Credentials = new NetworkCredential("user", "passwordex")


            Web site = clientContext.Web;

                Console.WriteLine("Digite o nome da lista");

            List lista = site.Lists.GetByTitle(Console.ReadLine());
            
            clientContext.Load(lista);

            clientContext.ExecuteQuery();

          ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
          
            ListItem newItem = lista.AddItem(itemCreateInfo);
            
            newItem["Title"] = "Novo Item";                        
            
            newItem.Update();



            }

        }
    }
}
