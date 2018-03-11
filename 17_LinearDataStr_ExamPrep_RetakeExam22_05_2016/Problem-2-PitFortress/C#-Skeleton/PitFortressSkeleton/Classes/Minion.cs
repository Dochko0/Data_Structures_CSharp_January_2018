namespace Classes
{
    using Interfaces;

    public class Minion : IMinion
    {
        private int v;

        public Minion(int v, int xCoordinate)
        {
            this.v = v;
            XCoordinate = xCoordinate;
        }

        public int CompareTo(Minion other)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; private set; }

        public int XCoordinate { get; private set; }

        public int Health { get; set; }
    }
}
