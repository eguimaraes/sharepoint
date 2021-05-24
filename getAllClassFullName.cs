using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace getAssemByName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o path da DLL: ");
            string DLLName = Console.ReadLine();
            Assembly assembly = Assembly.LoadFile(DLLName);
            //var assembly = AssemblyName.GetAssemblyName(DLLName);           
            
            Console.WriteLine(assembly.FullName);           
           
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass)
                {
                   
                        string s = type.AssemblyQualifiedName.ToString();
                        Console.WriteLine($@"O Nome completo da Classe é {s}");
                    
                }
            }

            Console.ReadLine();
            
        }
    }
}
