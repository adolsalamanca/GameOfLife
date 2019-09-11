using System;
using GameOfLifeKata.test;

namespace GameOfLifeKata
{
    internal class Engine
    {
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private readonly Grid _grid;
        private readonly ILogger _logger;

        public Engine(Grid grid, ILogger logger)
        {
            _grid = grid;
            _logger = logger;
            _grid.Initialize();
            _numberOfRows = grid.Rows;
            _numberOfColumns = grid.Columns;
        }

        public int GetNeighbours(int xPosition, int yPosition)
        {
            int neighbours = 0;

            neighbours += GetUpperNeighbours(xPosition, yPosition);

            neighbours += GetNeighboursOnTheLeft(xPosition, yPosition);

            neighbours += GetBottomNeighbours(xPosition, yPosition);

            neighbours += GetNeighboursOnTheRight(xPosition, yPosition);

            return neighbours;
        }

        private int GetUpperNeighbours(int xPosition, int yPosition)
        {
            int neighbours = 0;
            if (yPosition > 0)
            {
                neighbours += (int)_grid.GetCellState(xPosition, yPosition - 1);

                if (xPosition > 0)
                {
                    neighbours += (int)_grid.GetCellState(xPosition - 1, yPosition - 1);
                }

                if (xPosition < _numberOfColumns - 1)
                {
                    neighbours += (int)_grid.GetCellState(xPosition + 1, yPosition - 1);
                }
            }

            return neighbours;
        }

        private int GetNeighboursOnTheLeft(int xPosition, int yPosition)
        {
            int neighbours = 0;
            if (xPosition != 0)
            {
                neighbours += (int)_grid.GetCellState(xPosition - 1, yPosition);

                if (yPosition < _numberOfRows - 1)
                {
                    neighbours += (int)_grid.GetCellState(xPosition - 1, yPosition + 1);
                }
            }

            return neighbours;
        }

        private int GetBottomNeighbours(int xPosition, int yPosition)
        {
            int neighbours = 0;
            if (yPosition < _numberOfRows - 1)
            {
                neighbours += (int) _grid.GetCellState(xPosition, yPosition + 1);

                if (xPosition < _numberOfColumns - 1)
                {
                    neighbours += (int) _grid.GetCellState(xPosition + 1, yPosition + 1);
                }
            }

            return neighbours;
        }

        private int GetNeighboursOnTheRight(int xPosition, int yPosition)
        {
            int neighbours = 0;
            if (xPosition < _numberOfColumns - 1)
            {
                neighbours += (int)_grid.GetCellState(xPosition + 1, yPosition);
            }

            return neighbours;
        }

        public void NextTurn()
        {
            _logger.PrintLine("____");

            for (int i = 0; i < _grid.Rows; i++)
            {
                for (int j = 0; j < _grid.Columns; j++)
                {
                    _logger.Print("" + (_grid.GetCellState(i, j) != Cell.StateType.DEAD ? "O" : "X"));
                }

                _logger.PrintLine("|");
            }

            int [,] neighbours = GetAllNeighbours();

            foreach (var gridCell in _grid.Cells)
            {
                gridCell.Next(neighbours[gridCell.XCoordinate, gridCell.YCoordinate]);
            }
        }

        private int[,] GetAllNeighbours()
        {
            int[,] neighbours = new int[_numberOfColumns, _numberOfRows];
            foreach (var gridCell in _grid.Cells)
            {
                neighbours[gridCell.XCoordinate, gridCell.YCoordinate] =
                    GetNeighbours(gridCell.XCoordinate, gridCell.YCoordinate);
            }

            return neighbours;
        }
    }

}
