using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Board
    {
        // Create properties for console height and width
        public int BoardHeight { get; private set; }
        public int BoardWidth { get; private set; }

        // Construct board options
        public Board()
        {
            BoardWidth = Console.WindowWidth;
            BoardHeight = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
        }
    }
}
