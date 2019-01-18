 public void SaveJson(string url, string pathJson)
        {
            
            StreamWriter streamWriter = new StreamWriter(pathJson, false);
            streamWriter.Write(GetJsonString(url));
            streamWriter.Close();
            streamWriter.Dispose();
            
        }
        
        public string GetJsonString(string url)
        {
            RespostaJson = "";


            try
            {

                using (WebClient WebResource = new WebClient())
                {

                    RespostaJson = WebResource.DownloadString(url);

                }


            }

            catch (Exception e)
            {
                LogWrite("Erro Utilizando a URL" + URL);

                LogWrite(e);

            }

            Encoding enc = new UTF8Encoding(true, true);

            

            string sString = RespostaJson;
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(sString);
            byte[] win1252Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("Windows-1252"), utf8Bytes);
            RespostaJson = Encoding.UTF8.GetString(win1252Bytes);



            return RespostaJson;

        }
