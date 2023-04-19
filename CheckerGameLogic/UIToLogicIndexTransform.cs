using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerGameLogic
{
    public static class UIToLogicIndexTransform
    {
        public static string ParseMoveFromUIToBack(string i_Move)
        {
            StringBuilder move = new StringBuilder(i_Move);
            StringBuilder moveToReturn = new StringBuilder();
            
            moveToReturn.Append((char)(move[2] + 'A' - '0'));
            moveToReturn.Append((char)(move[0] + 'a' - '0'));
            moveToReturn.Append(('>'));
            moveToReturn.Append((char)(move[6] + 'A' - '0'));
            moveToReturn.Append((char)(move[4] + 'a' - '0'));
            return moveToReturn.ToString();
        }

        public static int GetRowFirstSoldier(string i_Move)
        {
            StringBuilder move = new StringBuilder(i_Move);
            return (int)(move[0] - '0') + 1;
        }
        public static int GetColFirstSoldier(string i_Move)
        {
            StringBuilder move = new StringBuilder(i_Move);
            return (int)(move[2] - '0') + 1;
        }
        public static int GetRowSeconedSoldier(string i_Move)
        {
            StringBuilder move = new StringBuilder(i_Move);
            return (int)(move[4] - '0') + 1;
        }
        public static int GetColSeconedSoldier(string i_Move)
        {
            StringBuilder move = new StringBuilder(i_Move);
            return (int)(move[6] - '0') + 1;
        }
    }
}
