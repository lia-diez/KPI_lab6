using System.Collections.Generic;

namespace KPI_lab6.Lib
{
    public class Course
    {
        public string Name;
        private List<Theme> _themes;

        public List<Theme> Themes
        {
            get => _themes;
            set => _themes = value;
        }

        public int CurrentTheme
        {
            get => _currentTheme;
            set => _currentTheme = value;
        }

        private int _percentage;
        private int _currentTheme;

        public Course(string name, int currentTheme)
        {
            Name = name;
            _currentTheme = currentTheme-1;
        }
    }
}