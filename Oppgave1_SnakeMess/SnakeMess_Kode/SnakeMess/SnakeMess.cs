using System;
using System.Linq;
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
            g.snakeDirection = Direction.Down;
            g.timer.Start ();

            while (true)
            {
                if (g.timer.ElapsedMilliseconds < 100)
                    continue;
                else
                    g.timer.Restart ();

                /* or use sleep
                System.Threading.Thread.Sleep (100);
                */
                
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
                        if (cki.Key == ConsoleKey.UpArrow && g.snakeDirection != Direction.Down)
                            g.moveSnake(Direction.Up);
                        else if (cki.Key == ConsoleKey.DownArrow && g.snakeDirection != Direction.Up)
                            g.moveSnake(Direction.Down);
                        else if (cki.Key == ConsoleKey.LeftArrow && g.snakeDirection != Direction.Right)
                            g.moveSnake(Direction.Left);
                        else if (cki.Key == ConsoleKey.RightArrow && g.snakeDirection != Direction.Left)
                            g.moveSnake(Direction.Right);
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

                Coord headPosition = g.snakePosition.ElementAt (0);

                // Game over if head hits border
                if (headPosition.x == -1
                    || headPosition.y == -1  
                    || headPosition.x == g.board.boardWidth
                    || headPosition.y == g.board.boardHeight)
                        g.endGame();

                // Game over if snake head hits body (cannibalism)
                foreach (Coord snakeElement in g.snakePosition) {
                    if (snakeElement != headPosition
                        && snakeElement.x == headPosition.x
                        && snakeElement.y == headPosition.y)
                            g.endGame ();
                }

                // Make snake larger if dollar hit
                if (headPosition.x == g.dollarPosition.x &&
                    headPosition.y == g.dollarPosition.y)
                        g.dollarHit();
            }
        }
	}
}
 
 