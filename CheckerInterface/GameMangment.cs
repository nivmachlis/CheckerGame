using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{
    public static class GameMangment
    {
        public static void StartGame()
        {
            FormGameSettings formGameSettings = new FormGameSettings();
            DialogResult dialogResult = formGameSettings.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string player1Name = formGameSettings.GetPlayer1Name();
                string player2Name = formGameSettings.GetPlayer2Name();
                bool isPlayer2Human = formGameSettings.IsPlayer2Human();
                int boardSize = formGameSettings.GetBoardSize();
                FormDamka gameBoard = new FormDamka(player1Name, player2Name, boardSize, isPlayer2Human);
                gameBoard.ShowDialog();
            }
        }

        public static void AnotherGame(string i_Player1Name, string i_Player2Name, int i_BoardSize, bool i_IsPlayer2Human)
        {
            FormDamka gameBoard = new FormDamka(i_Player1Name, i_Player2Name, i_BoardSize, i_IsPlayer2Human);
            gameBoard.ShowDialog();
        }
    }
}
