//from https://sharepoint.stackexchange.com/questions/73971/programmatically-building-metadata-navigation
TermSet newTermSet = siteCollectionGroup.CreateTermSet("Term set", NavTermSetId);
NavigationTermSet navTermSet = NavigationTermSet.GetAsResolvedByWeb(newTermSet, parentWeb,
                        StandardNavigationProviderNames.CurrentNavigationTaxonomyProvider);
navTermSet.IsNavigationTermSet = true;
navTermSet.TargetUrlForChildTerms.Value = "~site/Pages/default.aspx";
ts.CommitAll();
