/*Original at 
https://www.robin-gueldenpfennig.de/2016/02/get-taxonomy-field-values-with-csom-programmatically/
http://chrisdomino.com/Blog/Post/Thoughts-On-Programming-Managed-Metadata-With-SharePoint-2013-s-CSOM-Taxonomy-API



*/


private const string ChildItems = "_Child_Items_";
private const string ObjectType = "_ObjectType_";
 
public static TaxonomyFieldValue GetTaxonomyFieldValue(this ListItem item, string internalFieldName)
{
    if (item == null) throw new ArgumentNullException("item");
    if (internalFieldName == null) throw new ArgumentNullException("internalFieldName");
 
    if (!item.FieldValues.ContainsKey(internalFieldName))
    {
        throw new ArgumentException(string.Format("The field '{0}' does not exist.", internalFieldName), "internalFieldName");
    }
 
    var value = item[internalFieldName];
    var taxonomyFieldValue = value as TaxonomyFieldValue;
    if (taxonomyFieldValue != null)
    {
        return taxonomyFieldValue;
    }
 
    var dictionary = value as Dictionary<string, object>;
    if (dictionary != null)
    {
        return ConvertDictionaryToTaxonomyFieldValue(dictionary);
    }
 
    throw new InvalidOperationException(
        string.Format(
            "Could not convert value of field '{0}' to a taxonomy vield value. Value is neither a TaxonomyFieldValue nor a Dictionary",
            internalFieldName));
}
 
public static ReadOnlyCollection<TaxonomyFieldValue> GetTaxonomyFieldValueCollection(this ListItem item, string internalFieldName)
{
    if (item == null) throw new ArgumentNullException("item");
    if (internalFieldName == null) throw new ArgumentNullException("internalFieldName");
 
    if (!item.FieldValues.ContainsKey(internalFieldName))
    {
        throw new ArgumentException(string.Format("The field '{0}' does not exist.", internalFieldName), "internalFieldName");
    }
 
    var value = item[internalFieldName];
    var taxonomyFieldValueCollection = value as TaxonomyFieldValueCollection;
    if (taxonomyFieldValueCollection != null)
    {
        return new ReadOnlyCollection<TaxonomyFieldValue>(taxonomyFieldValueCollection.ToList());
    }
 
    var dictionary = value as Dictionary<string, object>;
    if (dictionary != null)
    {
        return new ReadOnlyCollection<TaxonomyFieldValue>(ConvertDictionaryToTaxonomyFieldValueCollection(dictionary));
    }
 
    throw new InvalidOperationException(string.Format(
        "Could not convert value of field '{0}' to a taxonomy vield value. Value is neither a TaxonomyFieldValue nor a Dictionary",
        internalFieldName));
}
 
private static TaxonomyFieldValue ConvertDictionaryToTaxonomyFieldValue(Dictionary<string, object> dictionary)
{
    if (!dictionary.ContainsKey(ObjectType) || !dictionary[ObjectType].Equals("SP.Taxonomy.TaxonomyFieldValue"))
    {
        throw new InvalidOperationException("Dictionary value represents no TaxonomyFieldValue.");
    }
 
    return new TaxonomyFieldValue
    {
        Label = dictionary["Label"].ToString(),
        TermGuid = dictionary["TermGuid"].ToString(),
        WssId = int.Parse(dictionary["WssId"].ToString(), CultureInfo.InvariantCulture)
    };
}
 
private static List<TaxonomyFieldValue> ConvertDictionaryToTaxonomyFieldValueCollection(Dictionary<string, object> dictionary)
{
    if (!dictionary.ContainsKey(ObjectType) || !dictionary[ObjectType].Equals("SP.Taxonomy.TaxonomyFieldValueCollection"))
    {
        throw new InvalidOperationException("Dictionary value represents no TaxonomyFieldValueCollection.");
    }
 
    if (!dictionary.ContainsKey(ChildItems))
    {
        throw new InvalidOperationException(string.Format("Missing '{0}' key in TaxonomyFieldValueCollection field.", ChildItems));
    }
 
    var list = new List<TaxonomyFieldValue>();
    foreach (var value in (object[])dictionary[ChildItems])
    {
        var childDictionary = (Dictionary<string, object>) value;
        list.Add(ConvertDictionaryToTaxonomyFieldValue(childDictionary));
    }
 
    return list;
}
