namespace KPI_lab6.Lib
{
    public class Test
    {
        private string[,] _tasks;
        private int _pointsForTask;
        private int _maxPoint;

        public Test(string[] input)
        {
            _tasks = new string[input.Length,2];
        }
    }
}