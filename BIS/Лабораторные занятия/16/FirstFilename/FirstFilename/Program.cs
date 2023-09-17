using System;
using System.IO;

namespace FirstFilename
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var files = Directory.GetFiles(currentDirectory);

            if (files.Length > 0)
            {
                Console.WriteLine(Path.GetFileName(files[0]));
            }
            else
            {
                Console.WriteLine("There are no files in the current directory.");
            }

            Console.ReadKey();
        }
    }
}
