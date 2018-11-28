Original em https://sharepointycl.wordpress.com/2018/02/19/copying-taxonomyfieldvalue-values-using-csom/
public static void CopyTaxonomyFieldValue(this ListItem listItem, string fieldName, object value)
{
    if (value is TaxonomyFieldValue taxonomyFieldValue)
    {
        listItem[fieldName] = $"{taxonomyFieldValue.Label}|{taxonomyFieldValue.TermGuid}";
    }
    else
    {
        throw new ArgumentException("Value needs to be a TaxonomyFieldValue object.");
    }
}
 
public static void CopyTaxonomyFieldValueCollection(this ListItem listItem, string fieldName, object value)
{
    if (value is TaxonomyFieldValueCollection taxonomyFieldValues)
    {
        var taxonomyFieldValueArray = taxonomyFieldValues.Select(taxonomyFieldValue => $"{taxonomyFieldValue.Label}|{taxonomyFieldValue.TermGuid}");
        listItem[fieldName] = String.Join(";", taxonomyFieldValueArray);
    }
    else
    {
        throw new ArgumentException("Value needs to be a TaxonomyFieldValueCollection object.");
    }
}
