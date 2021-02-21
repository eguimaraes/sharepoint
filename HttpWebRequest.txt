HttpWebRequest http = HttpWebRequest)WebRequest.Create(“http://localhost:8900/api/default”);
WebResponse response = http.GetResponse();
MemoryStream memoryStream = response.GetResponseStream();
StreamReader streamReader = new StreamReader(memoryStream);
string data = streamReader.ReadToEnd();
