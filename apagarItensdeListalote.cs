using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace ApagarLogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            string siteUrl = args[0];

            string listTitle = args[1];

            int idInicial = Convert.ToInt32(args[2]);

            int TamanhoDoLote = Convert.ToInt32(args[3]);
            
            
            
            using (SPSite site=new SPSite(siteUrl))
            {
                using (SPWeb web = site.RootWeb) { 

                    try {

                        SPList list = web.Lists[listTitle];

                        for (int i=0; i < TamanhoDoLote;i++)
                        {
                            try { 
                        SPListItem item = list.GetItemById(idInicial-i);

                        Console.WriteLine($@"apagando item {item.ID} item {i} de {TamanhoDoLote} faltam {TamanhoDoLote-i}");

                        item.Delete();
                            } catch (Exception ex)
                            {
                                Console.WriteLine("item nao existe");


                            }


                        }
                        





                    } catch (Exception e)
                        {

                            Console.WriteLine(e.ToString());


                        }

                    finally {

                        Console.WriteLine("Encerrado lote");

                       }

                    }



                }



            }
        }
    }

