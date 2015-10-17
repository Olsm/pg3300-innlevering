using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Coord
    {
        public int X, Y;
        public Coord(int x = 0, int y = 0) { X = x; Y = y; }
        public Coord(Coord input) { X = input.X; Y = input.Y; }
    }
}
