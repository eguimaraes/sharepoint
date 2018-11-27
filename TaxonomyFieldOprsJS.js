//original em https://www.credera.com/blog/credera-site/editing-multi-value-managed-metadata-fields-with-javascript-in-sharepoint-online/

function addTermToFieldValue(
       termGuidToAdd, //GUID of the term to add to the collection
       termLabelToAdd, //Label of the term to add to the collection
       siteUrl, //Relative URL of the relevant site
       listName, //Title of the relevant list
       listItemId, //ID of the relevant list item
       fieldName) //Internal name of the multi-value managed metadata field
       {
       //Code requires sp.js and sp.taxonomy.js
       SP.SOD.loadMultiple(['sp.js', 'sp.taxonomy.js'], function () {
              //Instantiate the client context
              var ctx = new SP.ClientContext(siteUrl);
              //Load the list item
              var oList = ctx.get_web().get_lists().getByTitle(listName);
              self.oListItem = oList.getItemById(listItemId);
              ctx.load(self.oListItem);

              //Load the managed metadata site column
              var field = oList.get_fields().getByInternalNameOrTitle(fieldName);
              self.txField = ctx.castTo(field, SP.Taxonomy.TaxonomyField);
              ctx.load(self.txField);

              //Run query
              ctx.executeQueryAsync(function () {
              //Get the managed metadata field on the list item
              var listField = self.oListItem.get_item(fieldName);
              var enumerator = listField.getEnumerator();
              //Define variable to contain the string of terms for the field value
              var termStr = "";

              //Iterate through current terms within the field
              while (enumerator.moveNext()) {
                var item = enumerator.get_current();
                var guid = item.get_termGuid();
                var wssId = item.get_wssId();
                var label = item.get_label();
                termStr += wssId + ';#' + label + '|' + guid + ';#';
              }
              //Add new term to the string. Use -1 for WssId.
              termStr += "-1;#" + termLabelToAdd + "|" + termGuidToAdd;

              //Convert the term string to a TaxonomyFieldValueCollection
              var newTerms = new SP.Taxonomy.TaxonomyFieldValueCollection(ctx, termStr, self.txField);
            //Set the field value to the new TaxonomyFieldValueCollection
            self.txField.setFieldValueByValueCollection(self.oListItem, newTerms);
            //Update the list item
            self.oListItem.update();
            ctx.load(self.oListItem);
            //Run query
            ctx.executeQueryAsync(function () {
                     //Success
                     console.log('Field successfully updated.');
               }, function (sender, args) {
                     //Error
                     console.log('An error occurred:' + args.get_message());
               });
            });
       });
}

var guidToAdd = "00000000-0000-0000-000000000000"; //real GUID goes here
var labelToAdd = "Python";
var siteUrl = "https://<domain>.sharepoint.com/sites/employees";
var listName = "Employee List";
var listItemId = 1; //ID for John Doe
var fieldName = "Skills";

function removeTermFromFieldValue(
       termGuidToRemove, 
       siteUrl, 
       listName, 
       listItemId, 
       fieldName) {
       //Code requires sp.js and sp.taxonomy.js
      SP.SOD.loadMultiple(['sp.js', 'sp.taxonomy.js'], function () {
             //Instantiate the client context
             var ctx = new SP.ClientContext(siteUrl);
             //Load the list item
             var oList = ctx.get_web().get_lists().getByTitle(listName);
             self.oListItem = oList.getItemById(listItemId);
             ctx.load(self.oListItem);
 
             //Load the managed metadata site column
             var field = oList.get_fields().getByInternalNameOrTitle(fieldName);
             self.txField = ctx.castTo(field, SP.Taxonomy.TaxonomyField);
             ctx.load(self.txField);

             //Run query
             ctx.executeQueryAsync(function () {
                    //Get the managed metadata field on the list item
                    var listField = self.oListItem.get_item(fieldName);
                    var enumerator = listField.getEnumerator();
                    //Define variable to contain the string of terms for the field value
                    var termStr = "";

                    //Iterate through current terms within the field
                    while (enumerator.moveNext()) {
                           var item = enumerator.get_current();
                           var guid = item.get_termGuid();
                           //As long as the GUID of the current item doesn't match the 
                           //GUID of the one to remove, add it to the term string
                           if (guid != termGuidToRemove) {
                                   var guid = item.get_termGuid();
                                   var wssId = item.get_wssId();
                                   var label = item.get_label();
                                   termStr += wssId + ';#' + label + '|' + guid + ';#';
                           }
                    }

                   //Remove the trailing ";#" characters
                   termStr = termStr.slice(0,-2);
                   //Convert the term string to a TaxonomyFieldValueCollection
                   var newTerms = new SP.Taxonomy.TaxonomyFieldValueCollection(ctx, termStr, self.txField);
                   //Set the field value to the new TaxonomyFieldValueCollection
                   self.txField.setFieldValueByValueCollection(self.oListItem, newTerms);
                   //Update the list item
                   self.oListItem.update();
                   ctx.load(self.oListItem);
                   //Run query
                   ctx.executeQueryAsync(function () {
                          //Success
                          console.log('Field successfully updated.');
                   }, function (sender, args) {
                          //Error
                          console.log('An error occurred:' + args.get_message());
                   });
            });
     });
}
