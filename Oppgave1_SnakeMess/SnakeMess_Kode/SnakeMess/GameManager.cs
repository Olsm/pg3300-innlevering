using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class GameManager
    {
        public GameState state { get; }
        public Direction snakeDirection { get; set; }
        public Board board { get; set; }
        public List<Coord> snakePosition { get; }
        public Coord dollarPosition {get; }
        public Stopwatch timer { get; }
        private Random randomGenerator;

        public GameManager()
        {
            state = new GameState();
            snakePosition = new List<Coord>();
            snakeDirection = new Direction();
            dollarPosition = new Coord();
            randomGenerator = new Random();
            timer = new Stopwatch ();
        }

        // Add the game elements to console
        public void createGame()
        {
            // Setup gameboard options
            board = new Board();

            // Add snake element position for head
            snakePosition.Add(new Coord(10, 10));

            // Add Yellow snake head
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

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
            if (snakePosition.Count < 4)
                addSnakeElement();

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

            // Get position of head and tail
            Coord headPosition = snakePosition.ElementAt (0);
            Coord tailPosition = snakePosition.ElementAt (snakePosition.Count - 1);

            // Add x or y pixel to head
            int newX = headPosition.x + addX;
            int newY = headPosition.y + addY;

            // Set first body element position
            int bodyX = headPosition.x;
            int bodyY = headPosition.y;
            
            // Remove last element (tail)
            int tailX = tailPosition.x;
            int tailY = tailPosition.y;
            Console.SetCursorPosition(tailX, tailY);
            Console.Write(" ");
            snakePosition.RemoveAt(snakePosition.Count - 1);

            // Add the new head to first element
            snakePosition.Insert(0, new Coord(newX, newY));
            if (newX >= 0 && newY >= 0 
                    && newX < board.boardWidth 
                    && newY < board.boardHeight) {
                Console.SetCursorPosition (newX, newY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write ("@");
                // Overwrite character of second element to body character
                Console.SetCursorPosition (bodyX, bodyY);
                Console.Write ("0");
            }
        }

        public void spawnDollar()
        {
            // Generate a random position for dollar
            dollarPosition.x = randomGenerator.Next(0, board.boardWidth);
            dollarPosition.y = randomGenerator.Next(0, board.boardHeight);
            
            // Spawn new dollar if spawned on snake body
            foreach (Coord snakeElement in snakePosition) {
                if (dollarPosition == snakeElement)
                    spawnDollar ();
            }

            // Place green dollar at random position
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(dollarPosition.x, dollarPosition.y);
            Console.Write("$");
        }

        public void dollarHit()
        {
            // Add the new head element and spawn a dollar
            addSnakeElement();
            spawnDollar();
        }

        private void addSnakeElement()
        {
            // Add snake element to last position
            Coord snake = snakePosition.ElementAt(snakePosition.Count -1);
            snakePosition.Add(snake);
        }
    }
}