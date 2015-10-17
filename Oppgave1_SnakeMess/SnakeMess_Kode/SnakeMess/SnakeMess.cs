using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace SnakeMess
{

	class SnakeMess
	{
        private static GameManager g = new GameManager();

        // Main method for game
        public static void Main(string[] arguments)
		{
            g.createGame();
            g.startTimer();

            while (true)
            {
                
            }
        }
	}
}