﻿using System;
using System.Threading.Channels;
using KPI_lab6;
using KPI_lab6.Lib;

namespace KPI_lab6.ConsoleApp
{
    class Program
    {
        static String standartUserPath = @"../../../../Resources/Users";
        static String standartCourcesPath = @"../../../../Resources/Cources";

        static void Main(string[] args)
        {
            Console.WriteLine();

            String inputStr = "";
            while (inputStr != "1" && inputStr != "2")
            {
                Console.Clear();
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Log In");
                Console.WriteLine("Please choose your variant:");
                inputStr = Console.ReadLine();
            }

            User currentUser;
            if (inputStr == "1")
            {
                currentUser=RegisterUser();
            }
            else if (inputStr == "2")
            {
                Console.WriteLine("Log In");
            }
        }

        private static User RegisterUser()
        {
            Console.WriteLine("Input users name: ");
            String name = Console.ReadLine();

            if (FileManager.CheckFile(standartUserPath, name + ".us"))
            {
                Console.WriteLine("User already exists!");
                return null;
            }

            Console.WriteLine("Input your password: ");
            String password = Console.ReadLine();

            Console.WriteLine("Confirm your password: ");
            while (Console.ReadLine() != password)
            {
                Console.WriteLine("Try again!");
                Console.WriteLine("Confirm your password: ");
            }

            Console.WriteLine("Completed! ");

            User currUser = new User();
            currUser.RegisterUser(name, password);

            String path = standartUserPath + "/" + name + ".us";

            FileManager.CreateAndWrite(path, password + "\n");
            return currUser;

        }

        private static User OpenUser(String name)
        {
            
        }
    }
}