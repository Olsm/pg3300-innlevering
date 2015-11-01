using System;
using System.Diagnostics;
using System.Linq;

namespace SnakeMess
{
    abstract class GameController
    {
        private static GameManager g = GameManager.Instance;

        public static void PlayGame()
        {
            GameManager.Direction nextSnakeDirection = g.SnakeDirection;
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (true)
            {
                // Do stuff when key has been clicked and snake has moved one step since last direction change
                if (Console.KeyAvailable && nextSnakeDirection == g.SnakeDirection)
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
                            nextSnakeDirection = GameManager.Direction.Up;
                        else if (key == ConsoleKey.DownArrow && g.SnakeDirection != GameManager.Direction.Up)
                            nextSnakeDirection = GameManager.Direction.Down;
                        else if (key == ConsoleKey.LeftArrow && g.SnakeDirection != GameManager.Direction.Right)
                            nextSnakeDirection = GameManager.Direction.Left;
                        else if (key == ConsoleKey.RightArrow && g.SnakeDirection != GameManager.Direction.Left)
                            nextSnakeDirection = GameManager.Direction.Right;
                    }
                }

                // Restart loop if game paused or there is less than 100 ms since last round
                if (g.State.Pause || timer.ElapsedMilliseconds < 100)
                    continue;
                timer.Restart();

                // Continue moving in current direction
                g.MoveSnake(nextSnakeDirection);

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
