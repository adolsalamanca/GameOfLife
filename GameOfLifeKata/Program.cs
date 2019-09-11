using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameOfLifeKata.test;

namespace GameOfLifeKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new Logger();
            Grid grid = new Grid(10,10);
            Engine engine = new Engine(grid, logger);

            logger.PrintLine("Game Of life \n");

            while (true)
            {
                engine.NextTurn();
                Thread.Sleep(5000);
            }

            

        }

    }
}
