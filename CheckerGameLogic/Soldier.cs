namespace CheckerGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Soldier
    {
        private char m_Sign;
        private eType m_Type;
        private int m_Col;
        private int m_Row;
        private int m_PlayerID;

        public Soldier(int i_Row, int i_Col, int i_PlayerID, eType i_Type)
        {
            this.m_Row = i_Row;
            this.m_Col = i_Col;
            this.PlayerID = i_PlayerID;
            this.m_Type = i_Type;

            if (i_PlayerID == 1 && i_Type == eType.Soldier)
            {
                this.m_Sign = 'O';
            }
            else if (i_PlayerID == 2 && i_Type == eType.Soldier)
            {
                this.m_Sign = 'X';
            }
        }

        public int PlayerID
        {
            get { return this.m_PlayerID; }
            set { this.m_PlayerID = value; }
        }

        public enum eType
        {
            Wall = 1,
            Soldier = 2,
            King = 3
        }

        public eType Type
        {
            get { return this.m_Type; }
            set { this.m_Type = value; }
        }

        public List<string> GetOptinalMoveWithoutCaptures(Board i_CheckerBoard)
        {
            List<string> optinalMoveWithoutCaptures = new List<string>();
            int rowToMove = 0;
            int colToLeft, colToLRight;

            if (this.m_PlayerID == 1)
            {
                rowToMove = this.m_Row + 1;
            }
            else if (this.m_PlayerID == 2)
            {
                rowToMove = this.m_Row - 1;
            }

            colToLeft = this.m_Col - 1;
            colToLRight = this.m_Col + 1;
            this.addPossibleMove(optinalMoveWithoutCaptures, rowToMove, colToLeft, i_CheckerBoard);
            this.addPossibleMove(optinalMoveWithoutCaptures, rowToMove, colToLRight, i_CheckerBoard);
            if (this.m_Type == eType.King)
            {
                rowToMove = this.m_Row + 1 == rowToMove ? this.m_Row - 1 : this.m_Row + 1;
                this.addPossibleMove(optinalMoveWithoutCaptures, rowToMove, colToLeft, i_CheckerBoard);
                this.addPossibleMove(optinalMoveWithoutCaptures, rowToMove, colToLRight, i_CheckerBoard);
            }

            return optinalMoveWithoutCaptures;
        }

        public void Update(int i_RowToMove, int i_ColToMove, int i_boardSize)
        {
            this.m_Row = i_RowToMove;
            this.m_Col = i_ColToMove;
            if (this.m_PlayerID == 1 && i_RowToMove == i_boardSize)
            {
                this.m_Type = eType.King;
                this.m_Sign = 'Q';
            }

            if (this.m_PlayerID == 2 && i_RowToMove == 1)
            {
                this.m_Type = eType.King;
                this.m_Sign = 'Z';
            }
        }

        public List<string> GetCaptures(Board i_CheckerBoard)
        {
            List<string> optinalCaptures = new List<string>();
            int rowToMove = 0;
            int rowToEat = 0;
            int colToLeft, colToLRight;

            if (this.m_PlayerID == 1)
            {
                rowToMove = this.m_Row + 2;
                rowToEat = this.m_Row + 1;
            }
            else if (this.m_PlayerID == 2)
            {
                rowToMove = this.m_Row - 2;
                rowToEat = this.m_Row - 1;
            }

            colToLeft = this.m_Col - 2;
            int colToEatLeft = this.m_Col - 1;
            colToLRight = this.m_Col + 2;
            int colToEatRight = this.m_Col + 1;

            this.addPossibleCapture(optinalCaptures, rowToMove, colToLeft, rowToEat, colToEatLeft, i_CheckerBoard);
            this.addPossibleCapture(optinalCaptures, rowToMove, colToLRight, rowToEat, colToEatRight, i_CheckerBoard);

            if (this.m_Type == eType.King)
            {
                rowToMove = this.m_Row + 2 == rowToMove ? this.m_Row - 2 : this.m_Row + 2;
                rowToEat = this.m_Row + 1 == rowToEat ? this.m_Row - 1 : this.m_Row + 1;
                this.addPossibleCapture(optinalCaptures, rowToMove, colToLeft, rowToEat, colToEatLeft, i_CheckerBoard);
                this.addPossibleCapture(optinalCaptures, rowToMove, colToLRight, rowToEat, colToEatRight, i_CheckerBoard);
            }

            return optinalCaptures;
        }

        private void addPossibleMove(List<string> o_PossiblesMoves, int i_RowToMove, int i_ColToMove, Board i_CheckerBoard)
        {
            StringBuilder possibleMove = new StringBuilder();

            if (i_CheckerBoard.CheckerBoard[i_RowToMove, i_ColToMove] == null)
            {
                possibleMove.Append((char)(this.m_Col + 'A' - 1));
                possibleMove.Append((char)(this.m_Row + 'a' - 1));
                possibleMove.Append('>');
                possibleMove.Append((char)(i_ColToMove + 'A' - 1));
                possibleMove.Append((char)(i_RowToMove + 'a' - 1));

                o_PossiblesMoves.Add(possibleMove.ToString());
            }
        }

        private void addPossibleCapture(List<string> o_PossiblesCaptures, int i_RowToMove, int i_ColToMove, int i_RowToEat, int i_ColToEat,  Board i_CheckerBoard)
        {
            StringBuilder possibleMove = new StringBuilder();
            Soldier soldierToEat = i_CheckerBoard.CheckerBoard[i_RowToEat, i_ColToEat];

            if (soldierToEat != null && (soldierToEat.Type == eType.Soldier || soldierToEat.Type == eType.King) && soldierToEat.PlayerID != this.m_PlayerID && i_CheckerBoard.CheckerBoard[i_RowToMove, i_ColToMove] == null)
            {
                possibleMove.Append((char)(this.m_Col + 'A' - 1));
                possibleMove.Append((char)(this.m_Row + 'a' - 1));
                possibleMove.Append('>');
                possibleMove.Append((char)(i_ColToMove + 'A' - 1));
                possibleMove.Append((char)(i_RowToMove + 'a' - 1));

                o_PossiblesCaptures.Add(possibleMove.ToString());
            }
        }
    }
}
