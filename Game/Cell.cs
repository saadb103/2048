namespace TZFE.Game
{
    public class Cell
    {
        private Tile tile;
        private Tile mergingTile;

        public int X { get; set; }
        public int Y { get; set; }

        public Tile Tile
        {
            get
            {
                return tile;
            }
            set
            {
                tile = value;
                if (value == null) return;
                tile.X = X;
                tile.Y = Y;
            }
        }

        public Tile MergingTile
        {
            get
            {
                return mergingTile;
            }
            set
            {
                mergingTile = value;
                if (value == null) return;
                mergingTile.X = X;
                mergingTile.Y = Y;
            }
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void MergeTiles()
        {
            if (Tile == null || MergingTile == null) return;

            Tile.ValueNumber = Tile.ValueNumber + MergingTile.ValueNumber;
            MergingTile = null;
        }

        public bool CanAcceptMerging(Tile tile)
        {
            var canMerge =
                Tile == null || MergingTile == null && Tile.ValueNumber == tile.ValueNumber;

            return canMerge;
        }
    }
}
