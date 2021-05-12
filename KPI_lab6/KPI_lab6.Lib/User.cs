using System;
using System.Collections.Generic;
using System.Linq;

namespace KPI_lab6.Lib
{
    public class User
    {
       
        private string _login;
        private string _password;
        private List<Course> _courses;

        public String Password {
            get
            {
                return _password;
            }
    }
        public int NumberOfCourses => _courses.Count;

        public User(string login, string password)
        {
            _login = login;
            _password = password;
            _courses = new List<Course>();
        }

        public void AddCouse(String name, int theme=0)
        {
            _courses.Add(new Course(name,theme));
        }

        public User()
        {
        }

        public void RegisterUser(String login, String password)
        {
            _login = login;
            _password = password;
        }

        public void GetCourses()
        {
            string result = "";
            for (int i = 0; i < _courses.Count; i++)
            {
                result += "i" + ". " + _courses[i].Name + '\n';
            }

            Console.WriteLine(result);
        }
    }
}