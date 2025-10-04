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
            _player1 = new Player (PieceState.White);
            _player2 = new Player (PieceState.Black);
            
            _currentPlayer = Random.Shared.Next(0, 2) == 0 ? _player1 : _player2;
            _currentPhase = GamePhase.Placing;
        }

        public void MakeMove(Move move)
        {
            if (!_board.IsMoveValid(move, _currentPlayer))
                throw new InvalidOperationException("Invalid move.");
            
            _board.ApplyMove(move, _currentPlayer);

            if (_currentPhase == GamePhase.Placing) _currentPlayer.PlacePiece();

            if (_board.CheckForMill(move.ToId, _currentPlayer.PieceColor))
            {
                // TODO: Handle mill formation
            }

            MoveId++;
            SwitchPlayer();

            if (_player1.PiecesInHand == 0 && _player2.PiecesInHand == 0)
            {
                _currentPhase = GamePhase.Moving;
            }
        }

        public void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }
    }
}
