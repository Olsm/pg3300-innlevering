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
        public Board board;
        public List<Coord> snakePosition;
        public Coord dollarPosition;
        private Random randomGenerator;

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
        }

        // Add the game elements to console
        public void createGame()
        {
            // Setup gameboard options
            board = new Board();

            // Create snake element positions
            for (int i = 0; i < 5; i++)
                snakePosition.Add(new Coord(10, 10 + i));

            // Add yellow snake elements
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(10, 10 + i);
                if (i > 0) Console.Write("0");
                else Console.Write("X");
            }

            // Spawn a dollar at random position on screen
            spawnDollar();

        }

        // End gaming using Environment.exit for closing console app
        public void endGame()
        {
            Environment.Exit(0);
        }

        public void moveSnake(Direction direction)
        {
            snakeDirection = direction;
            int addX = 0;
            int addY = 0;

            // Move position 1 pixel to direction
            if (direction == Direction.Down)
                addY = 1;
            else if (direction == Direction.Up)
                addY = -1;
            else if (direction == Direction.Left)
                addX = -1;
            else if (direction == Direction.Right)
                addX = 1;
            
            // Get position of head and add x or y pixel
            int newX = snakePosition.ElementAt(0).X + addX;
            int newY = snakePosition.ElementAt(0).Y + addY;

            // Get position of head to set first body element
            int bodyX = snakePosition.ElementAt(0).X;
            int bodyY = snakePosition.ElementAt(0).Y;

            // Get position of last element (tail) and remove it
            int tailX = snakePosition.ElementAt(snakePosition.Count - 1).X;
            int tailY = snakePosition.ElementAt(snakePosition.Count - 1).Y;
            Console.SetCursorPosition(tailX, tailY);
            Console.Write(" ");
            snakePosition.RemoveAt(snakePosition.Count - 1);

            // Add the new head to first element
            snakePosition.Insert(0, new Coord(newX, newY));
            Console.SetCursorPosition(newX, newY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("X");
            
            // Overwrite character of second element to body character
            Console.SetCursorPosition(bodyX, bodyY);
            Console.Write("0");
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

        public void dollarHit()
        {
            int addX = 0;
            int addY = 0;

            // Figure out where to add the head element according to movement
            if (snakeDirection == Direction.Up)
                addY = 1;
            else if (snakeDirection == Direction.Down)
                addY = -1;
            else if (snakeDirection == Direction.Left)
                addX = 1;
            else if (snakeDirection == Direction.Right)
                addX = -1;

            int newX = snakePosition.ElementAt(snakePosition.Count - 1).X + addX;
            int newY = snakePosition.ElementAt(snakePosition.Count - 1).Y + addY;

            // Add the new head element
            snakePosition.Add(new Coord(newX, newY));
            Console.SetCursorPosition(newX, newY);
            Console.Write("@");

            spawnDollar();
        }
    }
}