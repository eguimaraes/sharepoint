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


namespace ekis.util.termstore.adm.create
{
    class Program

    {
        

        static void Main(string[] args)
        {

        string[] confiRaw = { };


       if (args.Length == 0) { 



        Console.WriteLine("Digite a URL do sitecollection");
       confiRaw[0] = Console.ReadLine();

       Console.WriteLine("Digite a URL da web");
                confiRaw[1] = Console.ReadLine();

            Console.WriteLine("Digite o GroupName");
                confiRaw[2] = Console.ReadLine();

            Console.WriteLine("Digite o TermSetName");
                confiRaw[3] = Console.ReadLine();

            Console.WriteLine("Digite o URLAmigavel");
                confiRaw[4] = Console.ReadLine();

            Console.WriteLine("Digite o URLReal");
                confiRaw[5] = Console.ReadLine();

           

            } else
            {
                StreamReader stream = new StreamReader(args[0]);


                while (stream.Peek()>-1) {

                    confiRaw = stream.ReadLine().Split(';');

                    Console.WriteLine(confiRaw);

                    criaTermos(confiRaw);


                    
                }

               
            }


            Console.WriteLine("Aperte qq tecla para continuar");

            Console.ReadLine();



        }

       static void criaTermos(string[] confiRaw)
        {
         Console.WriteLine("Configurando a Aplicação");
         string ServerUrl = confiRaw[0];
         string WebUrl = confiRaw[1];
         string GroupName = confiRaw[2];
         string TermSetName = confiRaw[3];
         string URLAmigavel = confiRaw[4];
         string URLReal = confiRaw[5];
         

            using (SPSite site = new SPSite(ServerUrl))
            { 
                Console.WriteLine("Obtendo a site collection "+site.Url);
                using (SPWeb web = site.AllWebs[WebUrl])
                {
                    Console.WriteLine("Obtendo a web "+web.Url);

                    TaxonomySession session = new TaxonomySession(web, true);
                                        
                    TermStore termStore = session.TermStores[0];

                    Console.WriteLine("Obtendo a Termstore "+termStore.Name);

                    GroupCollection grp = termStore.Groups;

                    Group grupo = (termStore.Groups[GroupName] == null) ? termStore.CreateGroup(GroupName) : termStore.Groups[GroupName];

                    
                    Console.WriteLine("Obtendo o grupo "+grupo.Name);

                    TermSet termSet = (grupo.TermSets[TermSetName] == null) ? grupo.CreateTermSet(TermSetName) : grupo.TermSets[TermSetName];

                    Console.WriteLine("Obtendo a Termset "+termSet.Name);

                    NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web, StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);

                    navTermSet.IsNavigationTermSet = true;

                    string parentNodeStr = "/";
                    

                    foreach (string urlAmigavelCh in URLAmigavel.Split('/')) {

                     string displayURL =  ServerUrl + "/" + WebUrl + parentNodeStr+ urlAmigavelCh;

                     Console.WriteLine("URL de Destino " + displayURL);

                        NavigationTerm term = null;

                        if (parentNodeStr == "/")
                        {

                            if (navTermSet.FindTermForUrl(displayURL) == null)
                            {
                                term = navTermSet.CreateTerm(urlAmigavelCh, NavigationLinkType.FriendlyUrl);
                                term.TargetUrl.Value = URLReal;

                            }
                            else { term = navTermSet.FindTermForUrl(displayURL); }


                        }

                        else
                        {

                            if (navTermSet.FindTermForUrl(displayURL) == null)
                            {
                                term = navTermSet.FindTermForUrl(displayURL.Replace(urlAmigavelCh, "")).CreateTerm(urlAmigavelCh, NavigationLinkType.FriendlyUrl);
                                term.TargetUrl.Value = URLReal;
                            }

                            else { term = navTermSet.FindTermForUrl(displayURL); }

                        }

                    Console.WriteLine("Obtendo a Termo "+term.TaxonomyName);
                    
                   


                    termStore.CommitAll();

                    Console.WriteLine("Salvando Alterações");



                    Console.WriteLine("Termo criado com sucesso {0}:{1}",term.TaxonomyName,displayURL);

                        parentNodeStr = parentNodeStr+"/"+urlAmigavelCh+"/";


}


                }

            }
        }
    }





}
