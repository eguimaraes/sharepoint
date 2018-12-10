 public string GetItemJson(string URL)
        {
            RespostaJson = "";

            Dictionary<string, object> ItemsJson = new Dictionary<string, object>();

            try
            {
                

                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                WebRequest request = WebRequest.Create(new Uri("URL"));

                request.Credentials = CredentialCache.DefaultCredentials;

                
                WebResponse response = request.GetResponse();

                response.ContentType = "application/json";
                                
                SslStream dataStream = new SslStream(response.GetResponseStream(),false);

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                RespostaJson = responseFromServer;

                reader.Close();
                response.Close();

            }

            catch (Exception e)
            {
                LogWrite("Erro Utilizando a URL" + URL);

                LogWrite(e);

            }

            
            return RespostaJson;

        }
