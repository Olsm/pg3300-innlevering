using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class GameState
    {
        // Create variables for states
        public bool pause { get; set; }
        public bool dollarFound { get; set; }
        public bool spawnDollar { get; set; }

        // Construct GameState and instantiate initial states
        public GameState ()
        {
            pause = false;
            dollarFound = false;
            spawnDollar = true;
        }
    }
}
