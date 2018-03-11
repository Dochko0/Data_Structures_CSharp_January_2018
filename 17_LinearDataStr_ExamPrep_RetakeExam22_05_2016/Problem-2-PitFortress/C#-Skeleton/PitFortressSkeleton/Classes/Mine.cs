namespace Classes
{
    using Interfaces;

    public class Mine : IMine
    {
        private int v;

        public Mine(int v, int xCoordinate, int delay, int damage, Player player)
        {
            this.v = v;
            XCoordinate = xCoordinate;
            Delay = delay;
            Damage = damage;
            Player = player;
        }

        public int CompareTo(Mine other)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; private set; }

        public int Delay { get; set; }

        public int Damage { get; private set; }

        public int XCoordinate { get; private set; }

        public Player Player { get; private set; }
    }
}
