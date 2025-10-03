using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NineMensMorris.Models.Enums;

namespace NineMensMorris.Models
{
    static class BoardToString
    {
        public static void DrawBoard(Dictionary<string, PieceState> board)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\n     A   B   C   D   E   F   G");
            Console.WriteLine("   ╔═══════════════════════════╗");

            string[] template = {
        "1  ║ {A1}───────────{A4}───────────{A7} ║",
        "   ║ │           │           │ ║",
        "2  ║ │   {B2}───────{B4}───────{B6}   │ ║",
        "   ║ │   │       │       │   │ ║",
        "3  ║ │   │   {C3}───{C4}───{C5}   │   │ ║",
        "   ║ │   │   │       │   │   │ ║",
        "4  ║ {D1}───{D2}───{D3}       {D5}───{D6}───{D7} ║",
        "   ║ │   │   │       │   │   │ ║",
        "5  ║ │   │   {E3}───{E4}───{E5}   │   │ ║",
        "   ║ │   │       │       │   │ ║",
        "6  ║ │   {F2}───────{F4}───────{F6}   │ ║",
        "   ║ │           │           │ ║",
        "7  ║ {G1}───────────{G4}───────────{G7} ║"
    };

            foreach (var line in template)
            {
                string formattedLine = line;
                foreach (var coord in board.Keys)
                {
                    if (line.Contains($"{{{coord}}}"))
                    {
                        char symbol = board[coord] switch
                        {
                            PieceState.White => 'W',
                            PieceState.Black => 'B',
                            _ => '○'
                        };
                        formattedLine = formattedLine.Replace($"{{{coord}}}", symbol.ToString());
                    }
                }
                Console.WriteLine(formattedLine);
            }

            Console.WriteLine("   ╚═══════════════════════════╝");
            Console.WriteLine("     A   B   C   D   E   F   G\n");
        }
    }
    }
