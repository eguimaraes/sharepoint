//https://docs.microsoft.com/en-us/dotnet/api/system.security.securestring?view=net-5.0


using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;

public class Example
{
    public static void Main()
    {
       
        SecureString securePwd = new SecureString();
        ConsoleKeyInfo key;

        Console.Write("Digite a Senha: ");
        do {
           key = Console.ReadKey(true);
           
           // Ignore any key out of range.
           if (((int) key.Key) >= 65 && ((int) key.Key <= 90)) {
            
              securePwd.AppendChar(key.KeyChar);
              Console.Write("*");
           }   
       
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        
        try {
            Process.Start("Notepad.exe", "MyUser", securePwd, "MYDOMAIN");
        }
        catch (Win32Exception e) {
            Console.WriteLine(e.Message);
        }
        finally {
           securePwd.Dispose();
        }
    }
}
