using System;
using static GameOfLifeKata.Cell;

namespace GameOfLifeKata
{
    public class Grid
    {
        private readonly Random _random;
        private readonly Array _stateValues;
        public int Rows { get; }
        public int Columns { get; }
        public Cell[,] Cells { get; private set; }

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _random = new Random();
            _stateValues = Enum.GetValues(typeof(StateType));
        }

        public void Initialize()
        {
            Cells = new Cell[Rows, Columns];

            for (int eachColumn = 0; eachColumn < Columns; eachColumn++)
            {
                for (int eachRow = 0; eachRow < Rows; eachRow++)
                {
                    SetCellState(eachRow, eachColumn);
                }
            }
        }

        protected virtual void SetCellState(int eachRow, int eachColumn)
        {
            Cells[eachRow, eachColumn] = new Cell(eachRow, eachColumn, GenerateRandomState());
        }

        private StateType GenerateRandomState()
        {
            StateType randomState = (StateType) _stateValues.GetValue(_random.Next(_stateValues.Length));
            return randomState;
        }

        public StateType GetCellState(int xCoordinate, int yCoordinate)
        {
            return Cells[xCoordinate, yCoordinate].State;
        }
    }
}