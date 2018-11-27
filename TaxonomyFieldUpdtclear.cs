Original at https://unnieayilliath.com/2015/08/24/sharepoint-2013-updateclear-taxonomy-field-value-using-c-csom/

public void UpdateTaxonomyField(ClientContext ctx, List list, ListItem listItem, string fieldName, string fieldValue)
        {
            Field field = list.Fields.GetByInternalNameOrTitle(fieldName);
            TaxonomyField txField = ctx.CastTo<TaxonomyField>(field);
            TaxonomyFieldValue termValue = new TaxonomyFieldValue();
            string[] term = fieldValue.Split('|');
            termValue.Label = term[0];
            termValue.TermGuid = term[1];
            termValue.WssId = -1;
            txField.SetFieldValueByValue(listItem, termValue);
            listItem.Update();
            ctx.Load(listItem);
            ctx.ExecuteQuery();
        }

        public void ClearTaxonomyFieldValue(ClientContext ctx, List list, ListItem listItem, string fieldName)
        {
            Field field = list.Fields.GetByInternalNameOrTitle(fieldName);
            TaxonomyField txField = ctx.CastTo<TaxonomyField>(field);
            txField.ValidateSetValue(listItem, null);
            listItem.Update();
            ctx.Load(listItem);
            ctx.ExecuteQuery();
        }
