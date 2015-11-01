using System;
using System.Linq;
using System.Threading;

namespace SnakeMess
{
    abstract class GameController
    {
        private static GameManager g = GameManager.Instance;

        public static void PlayGame()
        {
            while (true)
            {
                // Each round should take minimum 100 ms
                Thread.Sleep(100);

                // Do stuff when key has been clicked
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    // End or pause game if escape / space clicked
                    if (key == ConsoleKey.Escape)
                        g.EndGame();
                    else if (key == ConsoleKey.Spacebar)
                        g.State.Pause = !g.State.Pause;

                    // Only change direction if game is not paused
                    if (!g.State.Pause)
                    {
                        // Only allow going up if not going down, and left if not going right etc...
                        if (key == ConsoleKey.UpArrow && g.SnakeDirection != GameManager.Direction.Down)
                            g.SnakeDirection = GameManager.Direction.Up;
                        else if (key == ConsoleKey.DownArrow && g.SnakeDirection != GameManager.Direction.Up)
                            g.SnakeDirection = GameManager.Direction.Down;
                        else if (key == ConsoleKey.LeftArrow && g.SnakeDirection != GameManager.Direction.Right)
                            g.SnakeDirection = GameManager.Direction.Left;
                        else if (key == ConsoleKey.RightArrow && g.SnakeDirection != GameManager.Direction.Left)
                            g.SnakeDirection = GameManager.Direction.Right;
                    }
                }

                // Restart loop if game is paused
                if (g.State.Pause)
                    continue;

                // Continue moving in current direction
                g.MoveSnake(g.SnakeDirection);

                Coord headPosition = g.SnakePosition.ElementAt(0);

                // Game over if head hits border
                if (headPosition.x == -1
                    || headPosition.y == -1
                    || headPosition.x == g.Board.BoardWidth
                    || headPosition.y == g.Board.BoardHeight)
                    g.EndGame();

                // Game over if snake head hits body (cannibalism)
                foreach (Coord snakeElement in g.SnakePosition)
                {
                    if (snakeElement != headPosition
                        && snakeElement.x == headPosition.x
                        && snakeElement.y == headPosition.y)
                        g.EndGame();
                }

                // Make snake larger if dollar hit
                if (headPosition.x == g.DollarPosition.x &&
                    headPosition.y == g.DollarPosition.y)
                    g.DollarHit();
            }
        }
    }
}
