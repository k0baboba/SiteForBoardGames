using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineMensMorris.Models.Enums;

namespace NineMensMorris.Models
{
    public class Board
    {
        private PieceState[] _positions = new PieceState[24];

        public bool IsMoveValid(Move move, Player currentPlayer)
        {
            return false;
        }

        public void ApplyMove(Move move)
        {
            ;
        }

        public bool CheckForMill(int position)
        {
            return false;
        }
    }
}
