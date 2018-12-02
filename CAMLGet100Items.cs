 var q = new CamlQuery() { ViewXml = "<View><Query><Where><And><Gt><FieldRef Name='ID' /><Value Type='Counter'>9000</Value></Gt><Lt><FieldRef Name='ID' /><Value Type='Counter'>10000</Value></Lt></And></Where><OrderBy><FieldRef Name='ID' Ascending='True' /></OrderBy></Query></View>"};
    var r = list.GetItems(q);
    ctx.Load(r);
    
    var q = new SPQuery()
{
    Query = @"<Where><And><Gt><FieldRef Name='ID' /><Value Type='Counter'>9000</Value></Gt><Lt><FieldRef Name='ID' /><Value Type='Counter'>10000</Value></Lt></And></Where><OrderBy><FieldRef Name='ID' Ascending='True' /></OrderBy>"
};


var r = list.GetItems(q);

/*
<Query>
   <Where>
      <And>
         <Gt>
            <FieldRef Name='ID' />
            <Value Type='Counter'>9000</Value>
         </Gt>
         <Lt>
            <FieldRef Name='ID' />
            <Value Type='Counter'>10000</Value>
         </Lt>
      </And>
   </Where>
   <OrderBy>
      <FieldRef Name='ID' Ascending='True' />
   </OrderBy>
</Query>

*/
