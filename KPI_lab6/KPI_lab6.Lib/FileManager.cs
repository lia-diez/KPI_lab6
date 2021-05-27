using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KPI_lab6.Lib
{
    public static class FileManager
    {
        public static string[] GetFiles(String path) => Directory.GetFiles(path).ToArray();

        public static string[] GetDirectories(String path) => Directory.GetDirectories(path).ToArray();

        public static bool CheckFile(string path, string name)
        {
            return String.Join("$", Directory.GetFiles(path)).Contains(path + '\\' + name);
        }

        public static List<string> ReadFile(string filePath)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    data.Add(str);
                }
            }

            return data;
        }

        public static void CreateAndWrite(String path, string text)
        {
            using FileStream fs = new FileStream(path, FileMode.Create);
            byte[] array = System.Text.Encoding.Default.GetBytes(String.Join("\n", text));
            fs.Write(array, 0, array.Length);
        }

        public static void Write(String path, string text)
        {
            using FileStream fs = new FileStream(path, FileMode.Append);
            byte[] array = System.Text.Encoding.Default.GetBytes(String.Join("\n", text));
            fs.Write(array);
        }

        public static User OpenUser(String path, String name)
        {
            using (StreamReader streamReader =
                new StreamReader(new FileStream(path + "/" + name + ".us", FileMode.Open)))
            {
                User user = new User(name, streamReader.ReadLine());
                String line = "";
                while (!String.IsNullOrEmpty(line = streamReader.ReadLine()))
                {
                    String courseName = line.Split('|')[0];
                    int theme = Int32.Parse(line.Split('|')[1]);
                    user.AddCouse(courseName, theme);
                }

                return user;
            }
        }

        public static void GetUsers(String path, int themesNumber)
        {
            string[] userNames = GetFiles(path);
            foreach (var name in userNames)
            {
                using (StreamReader streamReader =
                    new StreamReader(new FileStream(name, FileMode.Open)))
                {
                    streamReader.ReadLine();
                    string line = streamReader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        int theme = Int32.Parse(line.Split('|')[1]);

                        Console.WriteLine("User name is " +
                                          name.Split('\\')[name.Split('\\').Length - 1].Split('.')[0] +
                                          ", grade is " +
                                          ((theme) == 0
                                              ? 0
                                              : (int) Math.Floor((float) (theme) / themesNumber * 100)));
                    }
                }
            }
        }

        public static void AddLection(string coursePath)
        {
            Console.WriteLine("Here is the list of themes:");
            string[] paths = GetDirectories(coursePath);
            for (int i = 0; i < paths.Length; i++)
            {
                Console.WriteLine($"{i}. {paths[i].Split('\\')[paths[i].Split('\\').Length - 1].Split('.')[1]}");
            }

            Console.WriteLine("Choose the theme you wish to append:");
            if (int.TryParse(Console.ReadLine(), out int themeIndex) && themeIndex < paths.Length)
            {
                Console.WriteLine("Enter the name of lection");
                string name = Console.ReadLine();
                Console.WriteLine("Paste lection text");
                String line = "";
                string text = "";
                while (!String.IsNullOrEmpty(line = Console.ReadLine()))
                {
                    text += line + '\n';
                }

                using (StreamWriter streamWriter = new StreamWriter(new FileStream(paths[themeIndex] + "/Lections/" + $"{name}.lec", FileMode.OpenOrCreate)))
                {
                    streamWriter.Write(text);
                }
            }
            else Console.WriteLine("Wrong input");
        }

        public static void AddTheme(string coursePath)
        {
            Console.WriteLine("Enter the name of theme you wish to add in format 'number'. 'name'");
            string name = Console.ReadLine();
            Directory.CreateDirectory(coursePath + '/' + name);
        }
        
        public static void AddTest(string coursePath)
        {
            Console.WriteLine("Here is the list of themes:");
            string[] paths = GetDirectories(coursePath);
            for (int i = 0; i < paths.Length; i++)
            {
                Console.WriteLine($"{i}. {paths[i].Split('\\')[paths[i].Split('\\').Length - 1].Split('.')[1]}");
            }

            Console.WriteLine("Choose the theme you wish to append:");
            if (int.TryParse(Console.ReadLine(), out int themeIndex) && themeIndex < paths.Length)
            {
                Console.WriteLine("Enter the number of tests:");
                int num = int.Parse(Console.ReadLine());
                string text = "";
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("Enter the question");
                    text += Console.ReadLine() + '|';
                    Console.WriteLine("Enter 4 options, separated by enter");
                    String line = "";
                    while (!String.IsNullOrEmpty(line = Console.ReadLine()))
                    {
                        text += line + '|';
                    }

                    Console.WriteLine("Enter right answer - a, b, c or d");
                    line = Console.ReadLine();
                    text += line + '\n';
                }
                
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(paths[themeIndex] + "/" + "test.test", FileMode.Create)))
                {
                    streamWriter.Write(text);
                }
            }
            else Console.WriteLine("Wrong input");
        }

        public static List<Theme> GetThemes(string path)
        {
            List<Theme> themes = new List<Theme>();
            string[] themesNames = GetDirectories(path);
            foreach (var name in themesNames)
            {
                List<Lection> lections = new List<Lection>();
                var files = GetFiles($@"{name}\Lections");
                foreach (var lecpath in files)
                {
                    lections.Add(new Lection(String.Join('\n', ReadFile(lecpath)),
                        lecpath.Split('\\')[lecpath.Split('\\').Length - 1].Split('.')[0]));
                }

                Test test = new Test(ReadFile($@"{name}\test.test").ToArray());
                themes.Add(new Theme(name, lections, test));
            }

            return themes;
        }

        public static string GetNameFromPath(string path)
        {
            return path.Split('\\')[path.Split('\\').Length - 1].Split('.')[0];
        }

        public static void UpdateCurrentTheme(String path, int courseId)
        {
            List<String> data = new List<string>();
            using (StreamReader streamReader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                String input = "";
                while ((input = streamReader.ReadLine()) != null)
                {
                    data.Add(input);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (i == courseId + 1)
                    {
                        String str = data[i];
                        str = str.Split('|')[0] + '|' + (int)(int.Parse(str.Split('|')[1]) + 1)+"";
                        streamWriter.WriteLine(str);
                    }
                    else
                    {
                        streamWriter.WriteLine(data[i]);
                    }
                }
            }
        }
    }
}