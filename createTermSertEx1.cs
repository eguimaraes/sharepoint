using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;


namespace ekis.util.termstore.adm.create
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site=new SPSite("")){

                using (SPWeb web = site.AllWebs[""]) { 

                TaxonomySession session = new TaxonomySession(web,true);

                TermStore termStore = session.TermStores[0];

                Group grupo=termStore.CreateGroup("");

                TermSet termSet = grupo.CreateTermSet("");

                Term term= termSet.CreateTerm("teste1",1033);                

                 termStore.CommitAll();
                    
                   


                    

                }

            }


        }
    }
}
