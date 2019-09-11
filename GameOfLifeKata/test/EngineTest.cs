using Moq;
using NUnit.Framework;
using static GameOfLifeKata.Cell;

namespace GameOfLifeKata.test
{
    public class EngineTest
    {
        private Engine _engine;
        private Grid _grid;
        private Mock<ILogger> _logger;
        private const int Rows = 3;
        private const int Columns = 3;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _grid = new TestableGrid(Rows, Columns);
            _engine = new Engine(_grid, _logger.Object);

        }

        [TearDown]
        public void TearDown()
        {
            _grid = null;
            _engine = null;
        }

        [Test]
        public void should_retrieve_neighbours_given_a_cell_in_the_middle_of_the_grid()
        {
            int xPosition = 1;
            int yPosition = 1;

            int neighbours = _engine.GetNeighbours(xPosition, yPosition);

            Assert.AreEqual(8, neighbours);
        }

        [TestCase(0, 0)]
        [TestCase(Columns-1, 0)]
        [TestCase(0, Rows-1)]
        [TestCase(Columns-1, Rows-1)]
        public void should_retrieve_neighbours_given_a_cell_in_the_corners_of_the_grid(int xPosition, int yPosition)
        {
            int neighbours = _engine.GetNeighbours(xPosition, yPosition);

            Assert.AreEqual(3, neighbours);
        }


        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, Rows - 1)]
        [TestCase(Columns -1 , 1)]
        public void should_retrieve_neighbours_given_a_cell_in_the_borders_but_not_in_the_corners(int xPosition, int yPosition)
        {
            int neighbours = _engine.GetNeighbours(xPosition, yPosition);

            Assert.AreEqual(5, neighbours);
        }



        [Test]
        public void should_change_cell_state_when_execute_next_turn()
        {
            _engine.NextTurn();
            int livingCells = 0;

            foreach (var gridCell in _grid.Cells)
            {
                livingCells += (int) gridCell.State;
            }

            Assert.AreEqual(4, livingCells);

        }

    }

    public class TestableGrid : Grid
    {
        public TestableGrid(int rows, int columns) : base(rows, columns)
        {
        }

        protected override void SetCellState(int eachRow, int eachColumn)
        {
            Cells[eachRow, eachColumn] = new Cell(eachRow, eachColumn, StateType.ALIVE);
        }
    }
}