using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KPI_lab6.Lib
{
    public class FileManager
    {
        private string Path;

        public FileManager(string path)
        {
            Path = path;
        }

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
        
        
    }
}