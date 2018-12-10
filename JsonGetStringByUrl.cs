public string GetItemJson(string URL)
        {
            RespostaJson = "";

            Dictionary<string, object> ItemsJson = new Dictionary<string, object>();

            try
            {

                WebClient WebResource = new WebClient();

                RespostaJson=WebResource.DownloadString(URL);

                
               

            }

            catch (Exception e)
            {
                LogWrite("Erro Utilizando a URL" + URL);

                LogWrite(e);

            }

            
            return RespostaJson;

        }
