using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Board
    {
        // Create properties for console height and width
        public int boardHeight { get; private set; }
        public int boardWidth { get; private set; }

        // Construct board options
        public Board()
        {
            boardWidth = Console.WindowWidth;
            boardHeight = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
        }
    }
}
