using System;

namespace KPI_lab6.Lib
{
    public class Test
    {
        private string[,] _tasks;
        private int _pointsForTask = 10;
        private int _maxPoint;

        public Test(string[] input)
        {
            _tasks = new string[input.Length, 6];
            for (int i = 0; i < input.Length; i++)
            {
                string[] phrases = input[i].Split('|'); 
                for (int j = 0; j < 6; j++)
                {
                    _tasks[i, j] = phrases[j];
                }
            }

            _maxPoint = input.Length * _pointsForTask;
        }

        public float MakeTest()
        {
            int mark = 0;
            Console.WriteLine("Enter 1 answer for each test: a, b, c or d.");
            for (int i = 0; i < _tasks.GetLength(0); i++)
            {
                Console.WriteLine("Test " + (i+1) + ". " + _tasks[i, 0]);
                Console.WriteLine("a) "+_tasks[i, 1]);
                Console.WriteLine("b) "+_tasks[i, 2]);
                Console.WriteLine("c) "+_tasks[i, 3]);
                Console.WriteLine("d) "+_tasks[i, 4]);
                string answer = Console.ReadLine();
                if (answer == _tasks[i,5])
                {
                    mark += _pointsForTask;
                }
            }

            Console.WriteLine("Your mark is: " + mark);
            return (float)mark / _maxPoint;
        }
    }
}