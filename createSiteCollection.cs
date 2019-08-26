#https://tabrezblog.azurewebsites.net/post/2016/10/21/create-site-collection-programmatically
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using Microsoft.SharePoint;

using Microsoft.SharePoint.Administration;

// 1. Create site collection using server object model

namespace CreateSiteCollection

{    

    class Program

    {

        public const string siteUrl = "http://myserver:5263"; //url_Of_your_Web_application
        static void Main(string[] args)

        {

            SPSite site=new SPSite(siteUrl);

            // for create your site collection get object of web application class


            SPWebApplication webapp = site.WebApplication;           

             // for create a brand new site collection use Add() method to add new site collection
            webapp.Sites.Add

                (

                    "/sites/Training",   // site_url ,

                    "Training Site",     // Title,   

                    "SPS 2013 Training",  // Description ,

                    1033,         // us-eng_code,

                    "STS#0",    // type_of_site_template,

                    @"Tabrez Ajaz",   // owner_of_site_collection,

                    "Administrator",  // type

                    "tabrez@xyz.com"  //owner email

                );                                            

            Console.WriteLine("New Site Collection Created Name : Tabrez Site");

            Console.ReadKey();

        }

    }

}
