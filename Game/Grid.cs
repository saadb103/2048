namespace TZFE.Game
{
    public class Grid
    {
        public int GridSize { get; }
        public string CellSize { get; }
        public string CellGap { get; set; }
        public List<Cell> Cells { get; set; }
        public Grid()
        {
            GridSize = 4;
            CellSize = "15vmin";
            CellGap = "2vmin";
            Cells = new List<Cell>();
            CreateGridCells();
        }

        public List<Cell> GetEmptyCells()
        {
            return Cells.FindAll(cell => cell.Tile == null);
        }

        public Cell GetRandomEmptyCell()
        {
            int randomIndex = (int)Math.Floor(new Random().NextDouble() * GetEmptyCells().Count);
            return GetEmptyCells()[randomIndex];
        }

        public List<List<Cell>> GetCellsByColumn()
        {
            return Cells.Aggregate(new List<List<Cell>>(), (cellGrid, cell) =>
            {
                if (cellGrid.Count < GridSize)
                {
                    cellGrid.Insert(cell.X, new List<Cell>());
                }

                cellGrid[cell.X].Insert(cell.Y, cell);
                return cellGrid;
            });
        }

        public List<List<Cell>> GetCellsByRow()
        {
            return Cells.Aggregate(new List<List<Cell>>(), (cellgrid, cell) =>
            {
                if (cellgrid.Count < GridSize)
                {
                    cellgrid.Insert(cell.X, new List<Cell>());
                }

                cellgrid[cell.Y].Insert(cell.X, cell);
                return cellgrid;
            });
        }
        private void CreateGridCells()
        {
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                Cells.Add(new Cell(i % GridSize, (int)Math.Floor((decimal)i / GridSize)));
            }
        }
    }
}
