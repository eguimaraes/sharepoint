using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.IO.Pipes;

namespace carregarImagensRemotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest webRequest = HttpWebRequest.Create(args[0]);
            webRequest.Method = "GET";
           WebResponse webResponse= webRequest.GetResponse();
            Stream stream =  webResponse.GetResponseStream();
            FileStream fileStream = new FileStream(args[1], FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
            webResponse.Close();



               
            

        }
    }
}
