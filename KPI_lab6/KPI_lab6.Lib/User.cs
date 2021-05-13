using System;
using System.Collections.Generic;

namespace KPI_lab6.Lib
{
    public class User
    {
        private string _login;

        public string Name => _login;
        private string _password;
        private List<Course> _courses;

        public List<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

        public String Password
        {
            get { return _password; }
        }

        public int NumberOfCourses = 0;

        public User(string login, string password)
        {
            _login = login;
            _password = password;
            _courses = new List<Course>();
        }

        public void AddCouse(String name, int theme = 0)
        {
            _courses.Add(new Course(name, theme));
            NumberOfCourses++;
        }

        public User()
        {
            _courses = new List<Course>();
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
                result += $"{i}. {_courses[i].Name}\n";
            }
            
            if (_courses.Count == 0) Console.WriteLine("You don't have any courses");

            Console.WriteLine(result);
        }

        public List<Lection> GetLections(int id)
        {
            return Courses[id].Themes[Courses[id].CurrentTheme].Lections;
        }
        
        public Test GetTest(int id)
        {
            return Courses[id].Themes[Courses[id].CurrentTheme].Test;
        }
    }
}