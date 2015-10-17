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
        private List<Coord> snakePosition;
        private Coord dollarPosition;
        private Random randomGenerator;
        private Stopwatch timer { get; set; }

        private enum Direction
        {
            Up, Down, Left, Right
        };

        public GameManager()
        {
            snakePosition = new List<Coord>();
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
            var board = new Board();

            // Create snake element positions
            for (int i = 0; i < 5; i++)
                snakePosition.Add(new Coord(10, 10));

            // Add yellow snake elements
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
           
            // Generate a random position for dollar
            dollarPosition.X = randomGenerator.Next(0, board.boardWidth);
            dollarPosition.Y = randomGenerator.Next(0, board.boardHeight);

            // Place green dollar at random position
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(dollarPosition.X, dollarPosition.Y);
            Console.Write("$");
        }

        public void endGame()
        {
            Environment.Exit(0);
        }

        public void moveSnake()
        {

        }

        public void spawnDollar()
        {

        }
    }
}