using System.IO;
using static System.Console;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            string check;
            check = "a";
            if (check != null)
            {
                WriteLine("if içi");
                ReadLine();
            }
            else
            {
                WriteLine("if dışı");
                ReadLine();
            }
        }
    }
}