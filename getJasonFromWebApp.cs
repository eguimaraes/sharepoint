 public static JArray obterDados(int opr, string compay)
            
        {
            DateTime dataAtual = DateTime.Now;
            string dataAtualStrF = dataAtual.AddHours(10).ToString("MM-dd-yyyy hh:mm:ss tt", new CultureInfo("en-US"));
            string dataAtualStrI = dataAtual.AddMinutes(-10).ToString("MM-dd-yyyy hh:mm:ss tt", new CultureInfo("en-US"));
            string urlStr = string.Empty;

            switch (opr) {

                case 3:
                    urlStr = getServer() + "URL";
                    break;

                case 1:
                    urlStr = getServer() + "URL"  )";
                    
                    break;

                case 0:
              urlStr= getServer() + "URL";
                    break;
            }

            Console.WriteLine("Chamado a URL:{0}", urlStr);
            WebRequest request = HttpWebRequest.Create(urlStr);
            request.Headers.Add("Authorization", "Basic");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string dadosJsonSting = reader.ReadToEnd();
              JArray dadosJson = JArray.Parse(dadosJsonSting);
            return dadosJson;
            

        }
