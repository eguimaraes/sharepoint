//https://sharepoint.stackexchange.com/questions/66809/programmatically-building-metadata-navigation-with-friendly-urls


NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(termSet, web,
            StandardNavigationProviderNames.GlobalNavigationTaxonomyProvider);

navTermSet.IsNavigationTermSet = true;
navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/Topics/Topic.aspx";

NavigationTerm term1 = navTermSet.CreateTerm("Term 1", NavigationLinkType.SimpleLink);
term1.SimpleLinkUrl = "http://www.bing.com/";

NavigationTerm term2 = navTermSet.CreateTerm("Term 2", NavigationLinkType.FriendlyUrl);
NavigationTerm term2a = term2.CreateTerm("Term 2 A", NavigationLinkType.FriendlyUrl);
NavigationTerm term2b = term2.CreateTerm("Term 2 B", NavigationLinkType.FriendlyUrl);

NavigationTerm term3 = navTermSet.CreateTerm("Term 3", NavigationLinkType.FriendlyUrl);
