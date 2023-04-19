namespace CheckerGame
{
    using System;
    public class InitGame
    {
          public static RunGame setUp(string i_Player1Name, string i_Player2Name, int i_BoardSize, bool i_IsPlayer2Human, Action<Soldier[,]> i_FunctionChangeSoldierLocation)
          {
                Player secondPlayer;

                // create player
                Player firstPlayer = new Player(i_Player1Name, Player.ePlayerID.PlayerOne, Player.eOpponent.Human);

                // init board
                Board gameBoard = new Board(i_BoardSize);

                // choose opponent
                Player.eOpponent opponent = i_IsPlayer2Human == true ? Player.eOpponent.Human : Player.eOpponent.Computer;
                if (opponent == Player.eOpponent.Human)
                {
                    secondPlayer = new Player(i_Player2Name, Player.ePlayerID.PlayerTwo, Player.eOpponent.Human);
                }
                else
                {
                    secondPlayer = new Player("Computer", Player.ePlayerID.PlayerTwo, Player.eOpponent.Computer);
                }

                // create a game
                RunGame checkerGame = new RunGame(gameBoard, firstPlayer, secondPlayer, i_FunctionChangeSoldierLocation);

                // init game
                checkerGame.InitGame();

            // play game
            return checkerGame;
          } 
    }


}
