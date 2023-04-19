namespace CheckerGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private readonly string m_Name;
        private readonly List<Soldier> m_Soliders;
        private readonly ePlayerID m_PlayerID;
        private readonly eOpponent m_Opponent;
        public event Action<Player> Win;
        public event Action<Player, Player> PlayerCantMove;

        public Player(string i_name, ePlayerID i_PlayerID, eOpponent i_Opponent)
        {
            this.m_Name = i_name;
            this.m_PlayerID = i_PlayerID;
            this.m_Opponent = i_Opponent;
            this.m_Soliders = new List<Soldier>();
        }

        public string Name
        {
            get { return this.m_Name; }
        }

        public int NumOfSoldiers
        {
            get { return this.m_Soliders.Count; }
        }

        public void AddSoldier(Soldier i_SoldierToAdd)
        {
            this.m_Soliders.Add(i_SoldierToAdd);
        }

        public enum ePlayerID
        {
            None = 0,
            PlayerOne = 1,
            PlayerTwo = 2
        }

        public enum eOpponent
        {
            Computer = 0,
            Human = 1
        }

        public void Move(Board i_CheckerBoard, Player i_OpponentPlayer, string i_NextMove, out bool o_IsAnotherPossibleCapture)
        {
            o_IsAnotherPossibleCapture = false;
            string move = CheckerGameLogic.UIToLogicIndexTransform.ParseMoveFromUIToBack(i_NextMove);
            /*bool isCapture = false;*/
            int chessBoardSize = i_CheckerBoard.Size;
            int soldierColBeforeMove, soldierRowBeforeMove;
            Soldier soldierToMove;
            Random random = new Random();
            int amountOfCaptures;
            List<string> captures = this.getCaptures(i_CheckerBoard, out amountOfCaptures);
            if (this.m_Opponent == eOpponent.Human)
            {
                soldierColBeforeMove = CheckerGameLogic.UIToLogicIndexTransform.GetColFirstSoldier(i_NextMove);
                soldierRowBeforeMove = CheckerGameLogic.UIToLogicIndexTransform.GetRowFirstSoldier(i_NextMove);
                soldierToMove = i_CheckerBoard.CheckerBoard[soldierRowBeforeMove, soldierColBeforeMove];
            }
            else
            {

                if (amountOfCaptures != 0)
                {
                    int randomIndex = random.Next(0, captures.Count - 1);
                    move = captures[randomIndex];
                    /*isCapture = true;*/
                }
                else
                {
                    List<string> movesWithOutCapture = this.getOptinalMovesWithoutCapture(i_CheckerBoard);
                    if (movesWithOutCapture.Count != 0)
                    {
                        int randomIndex = random.Next(0, movesWithOutCapture.Count - 1);
                        move = movesWithOutCapture[randomIndex];
                    }
                    else
                    {
                        return;
                    }

                }
            }
            soldierColBeforeMove = move[0] - 'A' + 1;
            soldierRowBeforeMove = move[1] - 'a' + 1;
            soldierToMove = i_CheckerBoard.CheckerBoard[soldierRowBeforeMove, soldierColBeforeMove];
            this.moveSoldier(i_CheckerBoard, move);
            if (captures.Contains(move))
            {
                this.destroySoldier(i_CheckerBoard, move, i_OpponentPlayer);
                List<string> soldierCaptures = soldierToMove.GetCaptures(i_CheckerBoard);
                if (soldierCaptures.Count > 0)
                {
                    o_IsAnotherPossibleCapture = true;
                }
                if (i_OpponentPlayer.NumOfSoldiers == 0)
                {
                    this.Win(this);
                }
            }
            if (!this.CanMove(i_CheckerBoard) && !i_OpponentPlayer.CanMove(i_CheckerBoard))
            {
                this.PlayerCantMove(this, i_OpponentPlayer);
            }
        }

        public bool CanMove(Board i_CheckerBoard)
        {
            bool canMove;
            int amountOfPossibleCaptures;
            this.getCaptures(i_CheckerBoard, out amountOfPossibleCaptures);
            List<string> possibleMoves = this.getOptinalMovesWithoutCapture(i_CheckerBoard);
            if (amountOfPossibleCaptures == 0 && possibleMoves.Count == 0)
            {
                canMove = false;
            }
            else
            {
                canMove = true;
            }

            return canMove;
        }

        public int GetScore()
        {
            int score = 0;
            foreach (Soldier soldier in this.m_Soliders)
            {
                if (soldier.Type == Soldier.eType.Soldier)
                {
                    score++;
                }
                else if (soldier.Type == Soldier.eType.King)
                {
                    score += 4;
                }
            }

            return score;
        }

        private List<string> getOptinalMovesWithoutCapture(Board i_CheckerBoard)
        {
            List<string> optinalMovesWithoutCapture = new List<string>();
            List<string> optinalMovesPerSoldierWithoutCapture = new List<string>();
            foreach (Soldier soldier in this.m_Soliders)
            {
                optinalMovesPerSoldierWithoutCapture = soldier.GetOptinalMoveWithoutCaptures(i_CheckerBoard);
                foreach (string optinalMoveString in optinalMovesPerSoldierWithoutCapture)
                {
                    optinalMovesWithoutCapture.Add(optinalMoveString);
                }
            }

            return optinalMovesWithoutCapture;
        }

        private List<string> getCaptures(Board i_CheckerBoard, out int o_AmoutOfCaptures)
        {
            List<string> optinalCaptures = new List<string>();
            List<string> optinalCapturesPerSoldier = new List<string>();
            foreach (Soldier soldier in this.m_Soliders)
            {
                optinalCapturesPerSoldier = soldier.GetCaptures(i_CheckerBoard);
                foreach (string optinalMoveString in optinalCapturesPerSoldier)
                {
                    optinalCaptures.Add(optinalMoveString);
                }
            }

            o_AmoutOfCaptures = optinalCaptures.Count;
            return optinalCaptures;
        }

        private void moveSoldier(Board i_CheckerBoard, string i_nextMove)
        {
            int soldierColBeforeMove = i_nextMove[0] - 'A' + 1;
            int soldierRowBeforeMove = i_nextMove[1] - 'a' + 1;
            int soldierColAfterMove = i_nextMove[3] - 'A' + 1;
            int soldierRowAfterMove = i_nextMove[4] - 'a' + 1;
            Soldier soldierToMove = i_CheckerBoard.CheckerBoard[soldierRowBeforeMove, soldierColBeforeMove];
            i_CheckerBoard.CheckerBoard[soldierRowAfterMove, soldierColAfterMove] = soldierToMove;
            i_CheckerBoard.CheckerBoard[soldierRowBeforeMove, soldierColBeforeMove] = null;
            soldierToMove.Update(soldierRowAfterMove, soldierColAfterMove, i_CheckerBoard.Size);
        }

        private void destroySoldier(Board i_CheckerBoard, string i_NextMove, Player i_Opponenet)
        {
            int soldierColBeforeMove = i_NextMove[0] - 'A' + 1;
            int soldierRowBeforeMove = i_NextMove[1] - 'a' + 1;
            int soldierColAfterMove = i_NextMove[3] - 'A' + 1;
            int soldierRowAfterMove = i_NextMove[4] - 'a' + 1;
            int soldierToRemoveRow = (soldierRowBeforeMove + soldierRowAfterMove) / 2;
            int soldierToRemoveCol = (soldierColBeforeMove + soldierColAfterMove) / 2;
            Soldier soldierToRemove = i_CheckerBoard.CheckerBoard[soldierToRemoveRow, soldierToRemoveCol];
            i_Opponenet.m_Soliders.Remove(soldierToRemove);
            i_CheckerBoard.CheckerBoard[soldierToRemoveRow, soldierToRemoveCol] = null;
        }

        public bool ValidMove(string i_Move, Board i_CheckerBoard, out bool o_isCapture)
        {
            string move = CheckerGameLogic.UIToLogicIndexTransform.ParseMoveFromUIToBack(i_Move);
            int amountOfCaptures;
            List<string> captures = this.getCaptures(i_CheckerBoard, out amountOfCaptures);
            o_isCapture = false;
            if (amountOfCaptures != 0)
            {
                foreach (string possibleCapture in captures)
                {
                    if (possibleCapture.Equals(move))
                    {
                        o_isCapture = true;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                int row = CheckerGameLogic.UIToLogicIndexTransform.GetRowFirstSoldier(i_Move);
                int col = CheckerGameLogic.UIToLogicIndexTransform.GetColFirstSoldier(i_Move);
                Soldier soldierToMove = i_CheckerBoard.CheckerBoard[CheckerGameLogic.UIToLogicIndexTransform.GetRowFirstSoldier(i_Move), CheckerGameLogic.UIToLogicIndexTransform.GetColFirstSoldier(i_Move)];
                List<string> possibleMoveNoCapture = soldierToMove.GetOptinalMoveWithoutCaptures(i_CheckerBoard);
                if (possibleMoveNoCapture.Contains(move))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
