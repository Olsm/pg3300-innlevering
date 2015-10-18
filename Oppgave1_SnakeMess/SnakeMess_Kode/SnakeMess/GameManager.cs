using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace SnakeMess
{

    class GameManager
    {
        public GameState state;
        public Direction snakeDirection { get; set; }
        private Board board;
        public List<Coord> snakePosition;
        private Coord dollarPosition;
        private Random randomGenerator;
        private Stopwatch timer;

        internal enum Direction
        {
            Up, Down, Left, Right
        };

        public GameManager()
        {
            state = new GameState();
            snakePosition = new List<Coord>();
            snakeDirection = new Direction();
            dollarPosition = new Coord();
            randomGenerator = new Random();
            timer = new Stopwatch();
        }

        public void startTimer()
        {
            timer.Start();
        }

        // Add the game elements to console
        public void createGame()
        {
            // Setup gameboard options
            board = new Board();

            // Create snake element positions
            for (int i = 0; i < 5; i++)
                snakePosition.Add(new Coord(10, 10));

            // Add yellow snake elements
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
           
            // Spawn a dollar at random position on screen
            spawnDollar();

        }

        public void endGame()
        {
            Environment.Exit(0);
        }

        public void moveSnake(Direction direction)
        {
            snakeDirection = direction;

            int addX = 0;
            int addY = 0;

            if (direction == Direction.Down)
                addY = 1;
            else if (direction == Direction.Up)
                addY = -1;
            else if (direction == Direction.Left)
                addX = -1;
            else if (direction == Direction.Right)
                addX = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < snakePosition.Count; i++)
            {
                snakePosition.Insert(i, new Coord(snakePosition.ElementAt(i).X + addX, snakePosition.ElementAt(i).Y + addY));
                snakePosition.RemoveAt(i + 1);
                Console.SetCursorPosition(snakePosition.ElementAt(i).X, snakePosition.ElementAt(i).Y);
                Console.Write("@");

                Console.SetCursorPosition(snakePosition.ElementAt(snakePosition.Count - 1).X, snakePosition.ElementAt(snakePosition.Count - 1).X);
                Console.Write(" ");
            }

        }

        public void spawnDollar()
        {
            // Generate a random position for dollar
            dollarPosition.X = randomGenerator.Next(0, board.boardWidth);
            dollarPosition.Y = randomGenerator.Next(0, board.boardHeight);

            // Place green dollar at random position
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(dollarPosition.X, dollarPosition.Y);
            Console.Write("$");
        }
    }
}