//https://docs.microsoft.com/en-us/previous-versions/office/sharepoint-csom/ee537029(v=office.15)


using System;
using Microsoft.SharePoint.Client;

namespace Microsoft.SDK.SharePointFoundation.Samples
{
    class AddFieldAsXmlExample
    {
        static void Main()
        {
            string siteUrl = "http://MyServer/sites/MySiteCollection";

            ClientContext clientContext = new ClientContext(siteUrl);
            Web site = clientContext.Web;
            List targetList = site.Lists.GetByTitle("Announcements");
            FieldCollection collField = targetList.Fields;

            string fieldSchema = "<Field Type='Text' DisplayName='NewField' Name='NewField' />";
            collField.AddFieldAsXml(fieldSchema, true, AddFieldOptions.AddToDefaultContentType);

            clientContext.Load(collField);
            clientContext.ExecuteQuery();

            Console.WriteLine("NewField added to Announcements list.\n\nThe following fields are available:\n\n");
            foreach (Field myField in collField)
               Console.WriteLine(myField.Title);
        }
    }
}
