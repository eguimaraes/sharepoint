using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
using HtmlAgilityPack;



using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ekis.util.editpage
{
    class Program
    {
        static void Main(string[] args)
        {
           StreamReader stream = new StreamReader((args.Length>0)?args[0]:"config.json");

            configuracao config=JsonConvert.DeserializeObject<configuracao>(stream.ReadToEnd());

            using (SPSite site=new SPSite(config.siteURL) )
            {
                using (SPWeb web = site.AllWebs[config.webUrl])
                {

                   SPList list = web.Lists[config.lista];

                    foreach (SPListItem item in list.Items) {
                        
                     if (item["PublishingPageContent"]!=null && item["PublishingPageContent"].ToString().IndexOf(config.OldText) > 0) {


                            string cp = item["PublishingPageContent"].ToString();                           

                            HtmlDocument htmlSnippet = new HtmlDocument();

                            htmlSnippet.LoadHtml(cp);

                            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
                            {
                                HtmlAttribute att = link.Attributes["href"];
                                
                                if (att.Value.IndexOf(config.OldText) > 0) {

                                    link.Remove();
                                
                                }
                            }

                            cp = htmlSnippet.DocumentNode.OuterHtml;

                            Console.WriteLine(config.siteURL + config.webUrl + "Paginas" + "/" + item["Nome"]);

                            SPFile arquivo= web.GetFileByUrl(config.siteURL + config.webUrl + "Paginas" + "/" + item["Nome"]);
                           

                            try
                            {
                                if (arquivo.CheckOutStatus == SPFile.SPCheckOutStatus.None) { arquivo.CheckOut(); } else
                                {
                                    arquivo.UndoCheckOut();
                                    arquivo.CheckOut();



                                }

                                    
                            }

                            catch (Exception e) {

                                arquivo.UndoCheckOut();
                                arquivo.CheckOut();


                            
                            }

                            item["PublishingPageContent"] = cp;

                            item.Update();

                            arquivo.CheckIn(config.msg);

                            arquivo.Publish(config.msg);
                            
                            Console.WriteLine("Finalizado "+ arquivo.Url);
                            

                           


                        }
                 
                    
                    }
                }



            }


                Console.WriteLine("Digite qq tecla para continuar");

            Console.ReadLine();         

           


        }
    }
 }
