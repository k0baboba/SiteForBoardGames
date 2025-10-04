using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineMensMorris.Models.Enums;


namespace NineMensMorris.Models
{
    public class Player
    {
        public PieceState PieceColor { get; set; }
        public int PiecesInHand { get; private set; }
        public int PiecesOnBoard { get; private set; }

        public Player(PieceState pieceColor)
        {
            PieceColor = pieceColor;
            PiecesInHand = 9; // Начальное количество фишек в руке
            PiecesOnBoard = 0; // Начальное количество фишек на доске
        }

        public void PlacePiece()
        {
            if (PiecesInHand > 0)
            {
                PiecesInHand--;
                PiecesOnBoard++;
            }
            else
            {
                throw new InvalidOperationException("No pieces left in hand to place.");
            }
        }
    }
}
