using PublishingPage = Microsoft.SharePoint.Publishing.PublishingPage;
using SPListItem = Microsoft.SharePoint.SPListItem;
using SPFile = Microsoft.SharePoint.SPFile;
using SPModerationStatusType = Microsoft.SharePoint.SPModerationStatusType;
using PublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb;
using SPUser = Microsoft.SharePoint.SPUser;
using PageLayout = Microsoft.SharePoint.Publishing.PageLayout;
using PublishingPageCollection = Microsoft.SharePoint.Publishing.PublishingPageCollection;

namespace Microsoft.SDK.SharePointServer.Samples
{
    public static class PublishingPageCodeSamples
    {

        public static void SetPagePropertiesAndApprove(SPListItem listItem, SPUser pageContact)
        {
            // Replace these variable values and input parameters with your own values.
            //
            // New PublishingPage.Title value
            string newTitle = "your Title";
            //
            // New PublishingPage.Description value
            string newDescription = "your Description";
            //
            // The comment to set when the page is checked in, published, and approved.
            string checkInComment = "Your comments";


            // Validate the input parameters.
            //
            if (null == listItem)
            {
                throw new System.ArgumentNullException("listItem");
            }
            if (null == pageContact)
            {
                throw new System.ArgumentNullException("pageContact");
            }

            // Get the PublishingPage wrapper for the SPListItem that was passed in.
            //
            PublishingPage publishingPage = null;
            if (PublishingPage.IsPublishingPage(listItem))
            {
                publishingPage = PublishingPage.GetPublishingPage(listItem);
            }
            else
            {
                throw new System.ArgumentException("This SPListItem is not a PublishingPage", "listItem");
            }


            // Check out the page if it is not checked out yet.
            //
            if (publishingPage.ListItem.File.CheckOutStatus == SPFile.SPCheckOutStatus.None)
            {
                publishingPage.CheckOut();
            }


            // Set and save some properties on the PublishingPage.
            //
            publishingPage.Title = newTitle;
            publishingPage.Description = newDescription;
            publishingPage.Contact = pageContact;
            publishingPage.Update();


            // Publish the page, and approve it if required, so that the updated 
            // values are visible on the published Web site.
            //
            publishingPage.CheckIn(checkInComment);
            SPFile pageFile = publishingPage.ListItem.File;
            pageFile.Publish(checkInComment);
            pageFile.Approve(checkInComment);
        }
    }
}
