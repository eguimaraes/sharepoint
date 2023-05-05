using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;

namespace TesteListarTermStore
{
    class Program

    {


        static void Main(string[] args)
        {
            Console.WriteLine("Digite a URL da site collection ");
            using (SPSite site = new SPSite(Console.ReadLine()))
            {
                Console.WriteLine("Obtendo a site collection " + site.Url);

                Console.WriteLine("Digite a URL da web");
                using (SPWeb web = site.AllWebs[Console.ReadLine()])
                {

                    Console.WriteLine("Obtendo a web " + web.Url);

                    TaxonomySession session = new TaxonomySession(web, true);
                   
                    TermStore termStore = session.TermStores[0];

                    
                    Console.WriteLine("Obtendo a Termstore " + termStore.Name);

                    GroupCollection grp = termStore.Groups;

                    
                    foreach (Group grupo in grp)
                    {


                        Console.WriteLine(grupo.Name+" : "+ grupo.Id);

                    }
                    Console.ReadLine();

                    Console.WriteLine("Digite o id do grupo ");

                    Guid guidId = new Guid(Console.ReadLine());

                    Group group= grp[guidId];

                    Console.WriteLine(group.Name);

                    Console.WriteLine("Digite o id do TermSet");

                    Guid guidIdTermSet = new Guid(Console.ReadLine());

                    TermSetCollection termSets = group.TermSets;

                   

                    foreach (TermSet termo in termSets)
                    {


                        Console.WriteLine(termo.Name + " : " + termo.Id);


                        
                       
                    }

                    Console.ReadLine() ;

                }

            }
        }
    }
}
