string dir = @"c:\";
> string[] arquivos = System.IO.Directory.GetFiles(dir);
> foreach (string arquivo in arquivos)
. { Console.WriteLine(arquivo); }
