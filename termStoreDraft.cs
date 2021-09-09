 SPSite site = new SPSite(url);

            SPWeb web = site.AllWebs[urlweb];

             TaxonomySession taxonomySession = new TaxonomySession(site);

            if (taxonomySession.TermStores.Count == 0)
                throw new InvalidOperationException("O Serviço de taxonomia não existe");

            TermStore termStore = taxonomySession.TermStores["MMS"];
            
            TermSet existingTermSet = termStore.GetTermSet(NavTermSetId);

            if (existingTermSet != null)
            {
                
                existingTermSet.Delete();
                termStore.CommitAll();
            }

            
            Group siteCollectionGroup = termStore.GetSiteCollectionGroup(web.Site);

            TermSet termSet = siteCollectionGroup.CreateTermSet("Teste533", new Guid("79644E8B-0724-4588-8B9C-F3B6C4043294")/*NavTermSetId*/);
            
            termStore.CommitAll();
            
            NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
                StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);
            
            termStore.CommitAll();

            navTermSet.IsNavigationTermSet = true;
            
            navTermSet.TargetUrlForChildTerms.Value = "/en/Pages/default.aspx";
            
            NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
           
            term1.SimpleLinkUrl = "ffff";

           

            termStore.CommitAll();
           
            NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl, Guid.NewGuid());

            term2.FriendlyUrlSegment.Value = "PAgInicial";
           
            term2.TargetUrl.Value = "/en/Pages/default.aspx";
                   
            

            termStore.CommitAll();
