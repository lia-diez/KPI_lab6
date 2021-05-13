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
                currentUser = LogInUser();
            }

            if (currentUser != null)
            {
                while (true)
                {
                    Console.ReadLine();
                   Courses(currentUser); 
                }
                
            }
        }

        private static User LogInUser(String name = "")
        {
            Console.Clear();
            Console.WriteLine("Logging In...");
            if (name=="")
            {
                Console.WriteLine("Input user name:");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"User name is {name}");
            }
            
            User currentUser = null;
            if (FileManager.CheckFile(standartUserPath, name))
            {
                currentUser = OpenUser(name);
                Console.WriteLine("Input user password: ");
                while (Console.ReadLine() != currentUser.Password)
                {
                    currentUser = OpenUser(name);
                    Console.WriteLine("Input user password: ");
                    while (Console.ReadLine()!=currentUser.Password)
                    {
                        Console.WriteLine("Password is wrong! Try again!");
                    }
                    Console.WriteLine("Completed"); 
                    
                }

                Console.WriteLine("Completed");
            }

            return currentUser;

        }

        private static User RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("Registering...");
            Console.WriteLine("Input users name: ");
            String name = Console.ReadLine();

            if (FileManager.CheckFile(standartUserPath, name + ".us"))
            {
                Console.WriteLine("User already exists!");
                return LogInUser(name);
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

        private static void Courses(User user)
        {
            Console.WriteLine();

            String inputStr = "";
            while (inputStr != "1" && inputStr != "2" && inputStr != "3")
            {
                Console.Clear();
                
                Console.WriteLine("1 - Check my courses");
                Console.WriteLine("2 - Choose course");
                Console.WriteLine("3 - Add new course");
                Console.Write("Please choose your variant:");
                inputStr = Console.ReadLine();
            }

            switch (inputStr)
            {
                case "1":
                {
                    user.GetCourses();
                    break;
                }
                case "2":
                {
                    ChooseCourse(user);
                    break;
                }
                case "3":
                {
                    AddNewCourse(user);
                    break;
                }
            }
        }

        private static void AddNewCourse(User user)
        {
            Console.WriteLine("Here is the list of accessible courses:");
            string[] paths = FileManager.GetDirectories(standartCoursesPath);
            for (int i = 0; i < paths.Length; i++)
            {
                Console.WriteLine($"{i}. {FileManager.GetNameFromPath(paths[i])}");
            }

            Console.WriteLine("Which course do you wish to add?\n");
            if (int.TryParse(Console.ReadLine(), out int courseIndex) && courseIndex < paths.Length)
            {
                FileManager.Write(standartUserPath + "/" + user.Name + ".us",
                    $"\n{FileManager.GetNameFromPath(paths[courseIndex])}|0");
            }
            else Console.WriteLine("Wrong input");
        }

        private static void ChooseCourse(User user)
        {
            Console.Write("Enter the index of the course: ");
            if (int.TryParse(Console.ReadLine(), out int courseIndex) && courseIndex < user.NumberOfCourses)
            {
                user.Courses[courseIndex].Themes =
                    FileManager.GetThemes(standartCoursesPath + '\\' + user.Courses[courseIndex].Name);
                Console.WriteLine("1 - Choose lection");
                Console.WriteLine("2 - Pass test");
                Console.WriteLine("Input your choice: ");
                String input = Console.ReadLine();
                while (input != "1" && input != "2")
                {
                    Console.WriteLine("Wrong answer! Try again: ");
                }

                if (input == "1")
                {
                    var lections = user.GetLections(courseIndex);
                    for (int i = 0; i < lections.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {lections[i].Name}");
                    }

                    Console.WriteLine("Choose lection: ");
                    int lecId = int.Parse(Console.ReadLine()) - 1;
                    Console.Clear();
                    Console.WriteLine(lections[lecId]);
                }

                if (input == "2")
                {
                    float grade = user.GetTest(courseIndex).MakeTest();
                    if (grade >= 0.8)
                    {
                        
                    }
                }
            }
            else Console.WriteLine("Wrong input");
        }

        private static User OpenUser(String name)
        {
            return FileManager.OpenUser(standartUserPath, name);
        }
    }
}