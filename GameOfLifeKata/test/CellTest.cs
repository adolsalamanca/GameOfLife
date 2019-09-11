using NUnit.Framework;
using static GameOfLifeKata.Cell;

namespace GameOfLifeKata.test
{
    public class CellTest
    {
        private const int XCoordinate = 0;
        private const int YCoordinate = 0;

        private Cell cell;

            [SetUp]
            public void SetUp()
            {
                cell = new Cell(XCoordinate, YCoordinate, StateType.ALIVE);                
            }

            [TearDown]
            public void TearDown()
            {
                cell = null;
            }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void should_die_if_have_less_than_two_neighbors(int neighbours)
            {
                cell.Next(neighbours);
                
                Assert.AreEqual(cell.State, StateType.DEAD);
            }


        [TestCase(2)]
        [TestCase(3)]
        public void should_be_alive_if_have_two_or_three_neighbors_if_its_alive(int neighbours)
        {
            cell.Next(neighbours);

            Assert.AreEqual(cell.State, StateType.ALIVE);
        }

        [Test]
        public void should_remain_dead_if_has_two_neighbours_only()
        {
            cell = new Cell(XCoordinate, YCoordinate, StateType.DEAD);

            cell.Next(2);

            Assert.AreEqual(cell.State, StateType.DEAD);
        }

    }
}
