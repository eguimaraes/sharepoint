using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;



using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ekis.util.editpage
{
    class Program
    {
        static void Main(string[] args)
        {
           StreamReader stream = new StreamReader(args[0]);

            configuracao config=JsonConvert.DeserializeObject<configuracao>(stream.ReadToEnd());

            using (SPSite site=new SPSite(config.siteURL) )
            {
                using (SPWeb web = site.AllWebs[config.webUrl])
                {

                   SPList list = web.Lists[config.lista];

                    foreach (SPListItem item in list.Items) {
                        
                     if (item["PublishingPageContent"]!=null && item["PublishingPageContent"].ToString().IndexOf("xxxx") > 0) {


                            string cp = item["PublishingPageContent"].ToString();

                            web.GetFileByUrl(config.siteURL+config.webUrl+"Paginas"+"/"+item["Nome"]).CheckOut();
                            

                            item["PublishingPageContent"] = cp.Replace(config.OldText, "");

                            item.Update();

                            web.GetFileByUrl(config.siteURL + config.webUrl + "Paginas/" + item["Nome"]).CheckIn("Atualização de botão");

                            web.GetFileByUrl(config.siteURL + config.webUrl + "Paginas/" + item["Nome"]).Publish("Atualização de botão");








                            Console.WriteLine(item["PublishingPageContent"]);

                            Console.WriteLine(item["Nome"]);

                            break;



                        }
                 
                    
                    }
                }



            }


                Console.WriteLine("Digite qq tecla para continuar");

            Console.ReadLine();         

           


        }
    }
 }
