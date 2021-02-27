using System;
using System.IO;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            var sourcePath = Path.GetTempFileName();
            Console.WriteLine(sourcePath);
            Console.ReadLine();
        }
    }
}