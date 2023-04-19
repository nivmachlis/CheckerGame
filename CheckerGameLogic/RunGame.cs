namespace CheckerGame
{
    using System;

    public class RunGame
    {
        private readonly Board m_Board;
        private readonly Player m_Player1;
        private readonly Player m_Player2;
        public event Action<Soldier [,]> onChangeBoard;
        public RunGame(Board i_Board, Player i_Player1, Player i_Player2,Action<Soldier[,]> i_onChangeBoard)
        {
            this.m_Board = i_Board;
            this.m_Player1 = i_Player1;
            this.m_Player2 = i_Player2;
            this.onChangeBoard += i_onChangeBoard;
          
        }

        public Board Board 
        {
            get
            {
                return m_Board;
            }
        }
        public Player Player1 
        {
            get
            {
                return m_Player1;
            }
        }
        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public void InitGame()
        {
            int size = this.m_Board.CheckerBoard.GetLength(0);
            for (int row = 1; row < (size / 2) - 1; row++)
            {
                for (int col = 1; col < size - 1; col++)
                {
                    if ((row % 2 == 1 && col % 2 == 0) || (row % 2 == 0 && col % 2 == 1))
                    {
                        Soldier soldierToAdd = new Soldier(row, col, 1, Soldier.eType.Soldier);
            
                        this.m_Board.CheckerBoard[row, col] = soldierToAdd;
                        this.m_Player1.AddSoldier(soldierToAdd);
                    }
                }
            }

            for (int row = (size / 2) + 1; row < size - 1; row++)
            {
                for (int col = 1; col < size - 1; col++)
                {
                    if ((row % 2 == 0 && col % 2 == 1) || (row % 2 == 1 && col % 2 == 0))
                    {
                        Soldier soldierToAdd = new Soldier(row, col, 2, Soldier.eType.Soldier);
       
                        this.m_Board.CheckerBoard[row, col] = soldierToAdd;
                        this.m_Player2.AddSoldier(soldierToAdd);
                    }
                }
            }
            onChangeBoard.Invoke(m_Board.CheckerBoard);
        }
    }
}
