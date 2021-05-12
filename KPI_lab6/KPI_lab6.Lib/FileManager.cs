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

        public List<string> ReadFiles()
        {
            string[] filesList = Directory.GetFiles(Path).ToArray();
            List<string> data = new List<string>();
            foreach (var filePath in filesList)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        data.Add(str);
                    }
                }
            }

            return data;
        }

        public void WriteToFile(string text)
        {
            using (FileStream fs = new FileStream(Path + "\\results.csv", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(String.Join("\n", text));
                fs.Write(array, 0, array.Length);
            }
        }
    }
}