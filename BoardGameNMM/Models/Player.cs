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
        public int PiecesInHand { get; set; }
        public int PiecesOnBoard { get; set; }
    }
}
