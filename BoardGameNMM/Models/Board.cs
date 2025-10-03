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
        public Dictionary<string, PieceState> Slots { get; private set; }
        private Dictionary<string, List<string>> _neighbors;
        public Board()
        {
            Slots = new Dictionary<string, PieceState>();
            InitializeBoard();
            InitializeNeighbors();
        }

        private void InitializeBoard()
        {
            // Все 24 позиции в формате A1-G7
            string[] positions = {
            "A1", "A4", "A7",
            "B2", "B4", "B6",
            "C3", "C4", "C5",
            "D1", "D2", "D3", "D5", "D6", "D7",
            "E3", "E4", "E5",
            "F2", "F4", "F6",
            "G1", "G4", "G7"
        };

            foreach (var pos in positions)
            {
                Slots[pos] = PieceState.None;
            }
        }

        private void InitializeNeighbors()
        {
            _neighbors = new Dictionary<string, List<string>>
        {
            {"A1", new List<string> {"A4", "D1"}},
            {"A4", new List<string> {"A1", "A7", "B4"}},
            {"A7", new List<string> {"A4", "D7"}},
            {"B2", new List<string> {"B4", "D2"}},
            {"B4", new List<string> {"A4", "B2", "C4", "B6"}},
            {"B6", new List<string> {"B4", "D6"}},
            {"C3", new List<string> {"C4", "D3" } },
            {"C4", new List<string> {"B4", "C3", "C5"} },
            {"D1", new List<string> {"A1", "D2", "G1"} },
            {"D2", new List<string> {"D1", "B2", "F2", "D3"} },
            {"D3", new List<string> {"D2", "C3", "E3"} },
            {"D5", new List<string> {"C5", "E5", "D6"} },
            {"D6", new List<string> {"D5", "B6", "F6", "D7"} },
            {"D7", new List<string> {"A7", "D6", "G7"} },
            {"E3", new List<string> {"D3", "E4"} },
            {"E4", new List<string> {"E3", "E5", "F4"} },
            {"E5", new List<string> {"E4", "D5"} },
            {"F2", new List<string> {"D2", "F4"} },
            {"F4", new List<string> {"E4", "F2", "F6", "G4"} },
            {"F6", new List<string> {"D6", "F4"} },
            {"G1", new List<string> {"D1", "G4"} },
            {"G4", new List<string> {"G1", "G7", "F4"} },
            {"G7", new List<string> {"D7", "G4"} }
        };
        }

        public bool IsMoveValid(Move move, Player currentPlayer, GamePhase gamePhase)
        {
            string to = move.ToId;
            string from = move.FromId;
            // Общие проверки для всех фаз
            if (!Slots.ContainsKey(to) || Slots[to] != PieceState.None)
                return false;

            switch (gamePhase)
            {
                case GamePhase.Placing:
                    // В фазе расстановки from не используется, только to
                    return true; // Уже проверили что to пустая

                case GamePhase.Moving:
                    return Slots.ContainsKey(from) &&
                           Slots[from] == currentPlayer.PieceColor &&
                           _neighbors[from].Contains(to); // Но у меня нет _neighbors ПОМОГИ МНЕ ПОЖАЛУЙТСА

                case GamePhase.Flying:
                    return Slots.ContainsKey(from) &&
                           Slots[from] == currentPlayer.PieceColor;
                // to уже проверена на пустоту

                default:
                    return false;
            }
        }

        public void ApplyMove(Move move)
        {
            ;
        }

        public bool CheckForMill(int position)
        {
            return false;
        }

        public Dictionary<string, PieceState> GetPositionStates()
        {
            return Slots;
        }
    }
}
