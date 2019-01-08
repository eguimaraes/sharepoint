 var palavrasChave = jToken["info1"]["infochild"].ToString();
var JsonObj = JToken.Parse(palavrasChave);
var CampoSHP= new JProperty("CampoSHP", JsonObj);
jToken.Last.AddAfterSelf(CampoSHP);
Console.WriteLine(jToken.ToString());
Console.ReadLine();
