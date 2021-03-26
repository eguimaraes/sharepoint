using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Microsoft.SharePoint.Client;

namespace RobotClientSidecarga
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite a URL do Site:");

            string siteUrl = Console.ReadLine();

            Console.WriteLine("Digite seu usuário:");

            string user = Console.ReadLine();

            SecureString securePwd = new SecureString();
            
            ConsoleKeyInfo key;

            Console.WriteLine("Digite a senha: ");
           
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range.
                if (((int)key.Key) >= 65 && ((int)key.Key <= 90))
                {
                    // Append the character to the password.
                    securePwd.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);           
           
            using (ClientContext clientContext = new ClientContext(siteUrl)) { 
                       

            clientContext.Credentials = new SharePointOnlineCredentials(user, securePwd);            

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
