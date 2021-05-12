using System;
using System.Threading.Channels;

namespace KPI_lab6.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            
            String inputStr = "";
            while (String.IsNullOrEmpty(inputStr))
            {
                Console.WriteLine("Please choose your variant:");
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Log In");
            }
            
            
        }
    }
}