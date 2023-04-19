namespace CheckerGame
{
    public class Board
    {
        private readonly Soldier[,] m_CheckerBoard;
        private readonly int m_Size;

        public Board(int i_size)
        {
            this.m_CheckerBoard = new Soldier[i_size + 2, i_size + 2];
            this.m_Size = i_size;
            for (int row = 0; row < i_size + 2; row++)
            {
                for (int col = 0; col < i_size + 2; col++)
                {
                    if (row == 0 || col == 0 || row == i_size + 1 || col == i_size + 1)
                    {
                        this.m_CheckerBoard[row, col] = new Soldier(row, col, 0, Soldier.eType.Wall);
                    }
                }
            }
        }

        public Soldier[,] CheckerBoard
        {
            get { return this.m_CheckerBoard; }
        }

        public int Size
        {
            get { return this.m_Size; }
        }
    }
}
