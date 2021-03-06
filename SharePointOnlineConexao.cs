
//carregar https://www.nuget.org/packages/Microsoft.SharePointOnline.CSOM/
//Install-Package Microsoft.SharePointOnline.CSOM -Version 16.1.8210.1200
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;

namespace Nem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ClientContext("https://siteURL"))
            {
  

                context.Credentials = new SharePointOnlineCredentials(getUser(),GetPassWord());
                Web web = context.Web;
                context.Load(web.Lists, lists => lists.Include(list => list.Title, list => list.Id));
                context.ExecuteQuery();
                foreach (List list in web.Lists) { Console.WriteLine("List title is: " + list.Title); }
            }

            Console.ReadKey();


        }

        private static SecureString GetPassWord()
        {

            SecureString securePassword = new SecureString();
            string password = "PassWord";
            foreach (char c in password) { securePassword.AppendChar(c); }

            return securePassword;


        }

        private static string getUser()
        {
            return "user@domain";
        }
    }
}
