namespace Classes
{
    using Interfaces;

    public class Player : IPlayer
    {
        private int mineRadius;

        public Player(string name, int mineRadius)
        {
            Name = name;
            this.mineRadius = mineRadius;
        }

        public int CompareTo(Player other)
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; private set; }

        public int Radius { get; private set; }

        public int Score { get; set; }
    }
}
