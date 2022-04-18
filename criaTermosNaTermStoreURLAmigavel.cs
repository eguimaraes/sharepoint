using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing.Navigation;


namespace ekis.util.termstore.adm.create
{
    class Program

    {
        

        static void Main(string[] args)
        {
        
        Guid NavTermSetId = new Guid();
        Guid TaggingTermSetId = new Guid();
        string ServerUrl = "";
        string WebUrl = "";
        string GroupName = "";
        string TermSetName = "";
        string URLAmigavel = "";
        string URLReal = "";



        Console.WriteLine("Digite a URL do sitecollection");
       ServerUrl = Console.ReadLine();

       Console.WriteLine("Digite a URL da web");
       WebUrl = Console.ReadLine();

            Console.WriteLine("Digite o GroupName");
            GroupName = Console.ReadLine();

            Console.WriteLine("Digite o TermSetName");
            TermSetName = Console.ReadLine();

            Console.WriteLine("Digite o URLAmigavel");
            URLAmigavel = Console.ReadLine();

            Console.WriteLine("Digite o URLReal");
            URLReal = Console.ReadLine();







            using (SPSite site=new SPSite(ServerUrl)){

                using (SPWeb web = site.AllWebs[WebUrl]) { 

                TaxonomySession session = new TaxonomySession(web,true);                   

                    TermStore termStore = session.TermStores[0];                    

                    Group grupo=(termStore.Groups[GroupName]==null)?termStore.CreateGroup(GroupName): termStore.Groups[GroupName];

                    TermSet termSet =(grupo.TermSets[TermSetName]==null)? grupo.CreateTermSet(TermSetName): grupo.TermSets[TermSetName];

                NavigationTermSet navTermSet =NavigationTermSet.GetAsResolvedByWeb(termSet, web,StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);

                navTermSet.IsNavigationTermSet = true;
                   
                NavigationTerm term = navTermSet.CreateTerm(URLAmigavel, NavigationLinkType.FriendlyUrl);

                 term.TargetUrl.Value = URLReal;

                 termStore.CommitAll();


                    Console.WriteLine("Verifique se os termos foram criados e pressione qq tecla para continuar");
                    URLReal = Console.ReadLine();



                }

            }


        }
    }





}
