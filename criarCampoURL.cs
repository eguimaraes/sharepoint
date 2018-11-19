//http://chrisdomino.com/Blog/Post/Thoughts-On-Programming-Managed-Metadata-With-SharePoint-2013-s-CSOM-Taxonomy-API

item["url field"] = new FieldUrlValue()
{
Description = "description",
Url = "http://chrisdomino.com/blog"
};
...
string url = ((FieldUrlValue)item["url field"]).Url;
