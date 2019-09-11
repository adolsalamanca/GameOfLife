using NUnit.Framework;
using static GameOfLifeKata.Cell;

namespace GameOfLifeKata.test
{
    public class GridTest
    {
        private Grid _grid;
        private const int Rows = 5;
        private const int Columns = 7;


        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(Rows, Columns);
        }

        [TearDown]
        public void TearDown()
        {
            _grid = null;
        }

        [Test]
        public void should_create_a_grid_with_specified_rows_and_columns ()
        {
            Assert.AreEqual(_grid.Columns, Columns);
            Assert.AreEqual(_grid.Rows, Rows);
        }

        [Test]
        public void should_create_a_cell_per_row()
        {
            _grid.Initialize();

            Assert.AreEqual(_grid.Cells.Length, Rows*Columns);
        }

        [Test]
        public void should_return_the_state_of_the_cell()
        {
            const int xCoordinate = 0;
            const int yCoordinate = 0;
            _grid.Initialize();

            StateType state = _grid.GetCellState(xCoordinate, yCoordinate);

            Assert.IsNotEmpty(state.ToString());
        }


    }
}