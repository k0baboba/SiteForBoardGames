using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineMensMorris.Models.Enums;

namespace NineMensMorris.Models
{
    public class Move
    {
        public string FromId { get; }
        public string ToId { get; }
        public PieceState Piece { get; }
        public GamePhase Phase { get; }

        public Move(string fromId, string toId, PieceState piece, GamePhase phase)
        {
            FromId = fromId;
            ToId = toId;
            Piece = piece;
            Phase = phase;
        }
    }
}
