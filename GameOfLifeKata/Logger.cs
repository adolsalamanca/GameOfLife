using System;

namespace GameOfLifeKata
{
    public interface ILogger
    {
        void PrintLine(string stringMessage);
        void Print(string stringMessage);
    }

    public class Logger : ILogger
    {
        public void PrintLine(string stringMessage)
        {
            Console.WriteLine(stringMessage);
        }

        public void Print(string stringMessage)
        {
            Console.Write(stringMessage);
        }
    }
}