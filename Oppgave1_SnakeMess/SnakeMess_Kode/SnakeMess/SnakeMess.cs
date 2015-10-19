﻿using System;
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
            g.snakeDirection = Down;

            while (true)
            {
                System.Threading.Thread.Sleep(100);

                // Do stuff when key has been clicked
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    // End or pause game if escape / space clicked
                    if (cki.Key == ConsoleKey.Escape)
                        g.endGame();
                    else if (cki.Key == ConsoleKey.Spacebar)
                        g.state.pause = !g.state.pause;

                    // Only change direction if game is not paused
                    if (!g.state.pause) {
                        // Only allow going up if not going down, and left if not going right etc...
                        if (cki.Key == ConsoleKey.UpArrow && g.snakeDirection != Down)
                            g.moveSnake(Up);
                        else if (cki.Key == ConsoleKey.DownArrow && g.snakeDirection != Up)
                            g.moveSnake(Down);
                        else if (cki.Key == ConsoleKey.LeftArrow && g.snakeDirection != Right)
                            g.moveSnake(Left);
                        else if (cki.Key == ConsoleKey.RightArrow && g.snakeDirection != Left)
                            g.moveSnake(Right);
                    }
                }

                // pause game or move snake if no button was clicked
                else {

                    // Restart loop if pause game is true
                    if (g.state.pause)
                        continue;

                    // Continue moving in same direction
                    g.moveSnake (g.snakeDirection);
                }

                // Game over if head hits border
                if (g.snakePosition.ElementAt(0).X == 0
                        || g.snakePosition.ElementAt(0).Y == 0
                        || g.snakePosition.ElementAt(0).X == g.board.boardWidth - 1
                        || g.snakePosition.ElementAt(0).Y == g.board.boardHeight - 1)
                    g.endGame();

                // Game over if snake head hits body (cannibalism)
                Coord headPosition = g.snakePosition.ElementAt (0);
                foreach (Coord snakeElement in g.snakePosition) {
                    if (snakeElement != headPosition
                        && snakeElement.X == headPosition.X
                        && snakeElement.Y == headPosition.Y)
                        g.endGame ();
                }

                // Make snake larger if dollar hit
                if (g.snakePosition.ElementAt(0).X == g.dollarPosition.X &&
                    g.snakePosition.ElementAt(0).Y == g.dollarPosition.Y)
                        g.dollarHit();
            }
        }
	}
}