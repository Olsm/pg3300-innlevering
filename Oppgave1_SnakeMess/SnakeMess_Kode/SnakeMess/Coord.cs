namespace SnakeMess
{
    class Coord
    {
        public int x, y;
        
        public Coord (Coord input) {
            x = input.x;
            y = input.y;
        }

        public Coord(int x = 0, int y = 0) {
            this.x = x;
            this.y = y;
        }
    }
}
