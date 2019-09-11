
namespace GameOfLifeKata
{
    public class Cell
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public StateType State { get; private set; }

        public Cell(int xCoordinate, int yCoordinate, StateType state)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            State = (StateType) state;
        }

        public void Next(int neighbours)
        {
            if (neighbours == 2 && State == StateType.ALIVE)
            {
                State = StateType.ALIVE;
            }
            else
            {
                State = neighbours == 3 ? StateType.ALIVE : StateType.DEAD;
            }
        }

        public enum StateType
        {
            DEAD,
            ALIVE
        }
    }
}