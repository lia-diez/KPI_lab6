using System;
using KPI_lab6.Lib;

namespace KPI_lab6.ConsoleApp
{
    class Program
    {
        static String standartUserPath = @"../../../../Resources/Users";
        static String standartCoursesPath = @"../../../../Resources/Courses";
        
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

            User currentUser = null;
            if (inputStr == "1")
            {
                currentUser = RegisterUser();
            }
            else if (inputStr == "2")
            {
                Console.WriteLine("Log In");
                Console.WriteLine("Input user name:");
                String name = Console.ReadLine();

                if (FileManager.CheckFile(standartUserPath, name))
                {
                    currentUser = OpenUser(name);
                    Console.WriteLine("Input user password: ");
                    while (Console.ReadLine()!=currentUser.Password)
                    {
                        Console.WriteLine("Password is wrong! Try again!");
                    }
                    Console.WriteLine("Completed");
                }
                else
                {
                    Console.WriteLine("There is no such user");
                }
            }

            Console.WriteLine("End");
        }

        private static User RegisterUser()
        {
            Console.WriteLine("Input users name: ");
            String name = Console.ReadLine();

            if (FileManager.CheckFile(standartUserPath, name + ".us"))
            {
                Console.WriteLine("User already exists, opens user portfolio...");
                return OpenUser(name);
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

        public static void Courses()
        {
            Console.WriteLine();

            String inputStr = "";
            while (inputStr != "1" && inputStr != "2" && inputStr != "3")
            {
                Console.Clear();
                Console.WriteLine("1 - Check my courses");
                Console.WriteLine("2 - Choose course");
                Console.WriteLine("3 - Add new course");
                Console.WriteLine("Please choose your variant:");
                inputStr = Console.ReadLine();
            }

            switch (inputStr)
            {
                case "1":
                {
                    
                    break;
                }
            }
        }
    }
}