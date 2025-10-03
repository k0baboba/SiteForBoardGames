using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineMensMorris.Models.Enums;

namespace NineMensMorris.Models
{
    public class Game
    {
        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;
        private GamePhase _currentPhase;

        public static int MoveId { get; private set; } = 0;
        public Board Board { get { return _board; } }

        public Game()
        {
            _board = new Board();
            _player1 = new Player { PieceColor = PieceState.White, PiecesInHand = 9, PiecesOnBoard = 0 };
            _player2 = new Player { PieceColor = PieceState.Black, PiecesInHand = 9, PiecesOnBoard = 0 };
            
            _currentPlayer = Random.Shared.Next(0, 2) == 0 ? _player1 : _player2;
            _currentPhase = GamePhase.Placing;
        }
    }
}
