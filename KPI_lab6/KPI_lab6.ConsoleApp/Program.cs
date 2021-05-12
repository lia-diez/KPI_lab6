using System;
using System.Threading.Channels;
using KPI_lab6;
using KPI_lab6.Lib;

namespace KPI_lab6.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            
            String inputStr = "";
            while (inputStr!="1" && inputStr!="2")
            {
                Console.Clear();
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Log In");
                Console.WriteLine("Please choose your variant:");
                inputStr = Console.ReadLine();
            }

            String standartUserPath = @"../../../../Resources/Users/";
            String standartCourcesPath = @"../../../../Resources/Cources/";

            if (inputStr=="1")
            {
                Console.WriteLine("Input users name: ");
                String name = Console.ReadLine();

                Console.WriteLine("Input your password: ");
                String password = Console.ReadLine();

                Console.WriteLine("Confirm your password: ");
                while (Console.ReadLine()!=password)
                {
                    Console.WriteLine("Try again!");
                    Console.WriteLine("Confirm your password: ");
                }
                Console.WriteLine("Completed! ");
                
                String path = standartUserPath + name + ".user";
                
                FileManager.CreateAndWrite(path, password + "\n");
            }else if (inputStr=="2")
            {
                Console.WriteLine("Log In");
            }
            
            
        }
    }
}