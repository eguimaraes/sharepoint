using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Globalization;


namespace RoboResouces.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Resource.Culture = new CultureInfo("pt-Br");
            Console.WriteLine("{0}:{1}",Resource.Culture.DisplayName, Resource.bomDia);
            Resource.Culture =new CultureInfo("fr-FR");
            Console.WriteLine("{0}:{1}", Resource.Culture.DisplayName, Resource.bomDia);
            Resource.Culture = new CultureInfo("en-US");
            Console.WriteLine("{0}:{1}", Resource.Culture.DisplayName, Resource.bomDia);
            Console.ReadLine();




        }
    }
}
