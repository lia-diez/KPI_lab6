﻿using System;
using System.Collections.Generic;

namespace KPI_lab6.Lib
{
    public class User
    {
        private string _login;
        private string _password;
        private List<Course> _courses;

        public void RegisterUser(String login, String password)
        {
            _login = login;
            _password = password;
        }
    }
}