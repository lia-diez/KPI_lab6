using System.Collections.Generic;

namespace KPI_lab6.Lib
{
    public class Theme
    {
        private string _name;
        private List<Lection> _lections;
        private Test _test;
        private int _number;
        private bool _isPassed = false;

        public Theme(string name, List<Lection> lections, Test test)
        {
            _name = name;
            _lections = lections;
            _test = test;
            _number = int.Parse(name.Split('.')[0]);
        }
    }
}