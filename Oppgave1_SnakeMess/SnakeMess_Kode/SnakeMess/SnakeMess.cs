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
        private static GameManager.Direction Up = GameManager.Direction.Up ;
        private static GameManager.Direction Down = GameManager.Direction.Down;
        private static GameManager.Direction Left = GameManager.Direction.Left;
        private static GameManager.Direction Right = GameManager.Direction.Right;

        // Main method for game
        public static void Main(string[] arguments)
		{
            g.createGame();
            g.startTimer();

            while (true)
            {
                System.Threading.Thread.Sleep(100);

                // Do stuff when buttons are clicked
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Escape)
                        g.endGame();
                    else if (cki.Key == ConsoleKey.Spacebar)
                        g.state.pause = !g.state.pause;

                    // Only allow going up if not going down, and left if not going right etc...
                    else if (cki.Key == ConsoleKey.UpArrow && g.snakeDirection != Down)
                        g.moveSnake(Up);
                    else if (cki.Key == ConsoleKey.DownArrow && g.snakeDirection != Up)
                        g.moveSnake(Down);
                    else if (cki.Key == ConsoleKey.LeftArrow && g.snakeDirection != Right)
                        g.moveSnake(Left);
                    else if (cki.Key == ConsoleKey.RightArrow && g.snakeDirection != Left)
                        g.moveSnake(Right);
                }

                // Restart loop if pause game is true
                if (g.state.pause)
                    continue;

                if (g.snakePosition.ElementAt(0).X == 0 || g.snakePosition.ElementAt(0).Y == 0)
                    g.endGame();

                g.moveSnake(g.snakeDirection);
            }
        }
	}
}