 var palavrasChave = jToken["palavrasChave"]["temas"].ToString();
var JsonObj = JToken.Parse(palavrasChave);
var temasmms= new JProperty("TemasMMS", JsonObj);
jToken.Last.AddAfterSelf(temasmms);
Console.WriteLine(jToken.ToString());
Console.ReadLine();
