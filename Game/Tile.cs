namespace TZFE.Game
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int ValueNumber { get; set; }

        public Tile()
        {
            ValueNumber = new Random().NextDouble() > 0.5 ? 2 : 4;
        }
    }
}
