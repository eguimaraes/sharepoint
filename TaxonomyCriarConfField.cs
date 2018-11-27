//original em https://karinebosch.wordpress.com/my-articles/creating-fields-using-csom/
//https://blog.mastykarz.nl/programmatically-creating-site-columns-content-types-app-model/


private void GetTaxonomyFieldInfo(ClientContext clientContext, out Guid termStoreId, out Guid termSetId) {
    termStoreId = Guid.Empty;
    termSetId = Guid.Empty;

    TaxonomySession session = TaxonomySession.GetTaxonomySession(clientContext);
    TermStore termStore = session.GetDefaultSiteCollectionTermStore();
    TermSetCollection termSets = termStore.GetTermSetsByName("SPSNL14", 1033);

    clientContext.Load(termSets, tsc => tsc.Include(ts => ts.Id));
    clientContext.Load(termStore, ts => ts.Id);
    clientContext.ExecuteQuery();

    termStoreId = termStore.Id;
    termSetId = termSets.FirstOrDefault().Id;
}


https://blog.mastykarz.nl/programmatically-creating-site-columns-content-types-app-model/
// Create as a regular field setting the desired type in XML
Field field = rootWeb.Fields.AddFieldAsXml("<Field DisplayName='Session Topics' Name='SessionTopics' ID='{bed14299-afe0-4c75-9e04-92e3d8b39a18}' Group='SharePoint Saturday 2014 Columns' Type='TaxonomyFieldTypeMulti' />", false, AddFieldOptions.AddFieldInternalNameHint);
clientContext.ExecuteQuery();

Guid termStoreId = Guid.Empty;
Guid termSetId = Guid.Empty;
GetTaxonomyFieldInfo(clientContext, out termStoreId, out termSetId);

// Retrieve as Taxonomy Field
TaxonomyField taxonomyField = clientContext.CastTo<TaxonomyField>(field);
taxonomyField.SspId = termStoreId;
taxonomyField.TermSetId = termSetId;
taxonomyField.TargetTemplate = String.Empty;
taxonomyField.AnchorId = Guid.Empty;
taxonomyField.Update();

clientContext.ExecuteQuery();

https://karinebosch.wordpress.com/my-articles/creating-fields-using-csom/
string schemaTaxonomyField = "<Field ID ='<GUID>’ Type='TaxonomyFieldType' Name='ProductCategory' StaticName='ProductCategory' 
    DisplayName='ProductCategory' />"
Field field = demoList.Fields.AddFieldAsXml(schemaTaxonomyField, true, AddFieldOptions.AddFieldInternalNameHint);
clientContext.ExecuteQuery();
Of course, this is not enough; you also have to bind this field to a termset or term in the term store:

Guid termStoreId = Guid.Empty;
Guid termSetId = Guid.Empty;
GetTaxonomyFieldInfo(clientContext, out termStoreId, out termSetId);
 
// Retrieve the field as a Taxonomy Field
TaxonomyField taxonomyField = clientContext.CastTo<TaxonomyField>(field);
taxonomyField.SspId = termStoreId;
taxonomyField.TermSetId = termSetId;
taxonomyField.TargetTemplate = String.Empty;
taxonomyField.AnchorId = Guid.Empty;
taxonomyField.Update();
 
clientContext.ExecuteQuery();



