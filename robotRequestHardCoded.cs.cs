using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;




namespace RobotResquest
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            string endpont = args[0];


            string postData = new StreamReader(args[1]).ReadToEnd();


            
            WebRequest request = WebRequest.Create(endpont);
            
            request.Method = "POST";


            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            
            request.ContentType = "application/x-www-form-urlencoded";
            
            request.ContentLength = byteArray.Length;
            
            Stream dataStream = request.GetRequestStream();
            
            dataStream.Write(byteArray, 0, byteArray.Length);
            
            dataStream.Close();
            
            WebResponse response = request.GetResponse();
            
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            
            dataStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(dataStream);
            
            string responseFromServer = reader.ReadToEnd();         




            Console.WriteLine(responseFromServer);
            
            reader.Close();
            
            dataStream.Close();
            
            response.Close();





        }
    }
}
