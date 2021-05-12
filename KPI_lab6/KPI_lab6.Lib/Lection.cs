using System;

namespace KPI_lab6.Lib
{
    public class Lection
    {
        private string _text;
        private String _name;

        public Lection(string text, String name)
        {
            _text = text;
            _name = name;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}