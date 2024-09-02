namespace GameOfLife.Models
{
    public class Grid
    {

        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] Cells { get; set; }

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cells[i, j] = new Cell(false); // Todas las celdas empiezan muertas
                }
            }
        }

        public void NextGeneration()
        {
            var newCells = new Cell[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int aliveNeighbors = CountAliveNeighbors(i, j);
                    bool shouldLive = Cells[i, j].IsAlive;

                    if (shouldLive && (aliveNeighbors < 2 || aliveNeighbors > 3))
                    {
                        shouldLive = false; // Muere por subpoblación o sobrepoblación
                    }
                    else if (!shouldLive && aliveNeighbors == 3)
                    {
                        shouldLive = true; // Nace una nueva célula viva
                    }

                    newCells[i, j] = new Cell(shouldLive);
                }
            }

            Cells = newCells; // Actualiza la cuadrícula con el nuevo estado
        }

        private int CountAliveNeighbors(int row, int col)
        {
            int aliveCount = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // Ignora la celda actual

                    int newRow = row + i;
                    int newCol = col + j;

                    if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns && Cells[newRow, newCol].IsAlive)
                    {
                        aliveCount++;
                    }
                }
            }

            return aliveCount;
        }

        public void Reset(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cells[i, j] = new Cell(false); // Todas las celdas empiezan muertas
                }
            }
        }


    }
}
