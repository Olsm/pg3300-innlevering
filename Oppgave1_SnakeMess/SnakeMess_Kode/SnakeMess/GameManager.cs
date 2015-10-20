using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
    internal class GameManager
    {
        // Make class singleton using System.Lazy<T>
        private static readonly Lazy<GameManager> instance =
            new Lazy<GameManager>(() => new GameManager());
        public static GameManager Instance {get { return instance.Value; } } 

        public GameState State { get; private set; }
        public Direction SnakeDirection { get; set; }
        public Board Board { get; private set; }
        public List<Coord> SnakePosition { get; private set; }
        public Coord DollarPosition { get; private set; }
        private readonly Random randomGenerator;

        internal enum Direction
        {
            Up, Down, Left, Right
        };

        // Private to prevent user from creating instance (singleton)
        private GameManager()
        {
            State = new GameState();
            SnakePosition = new List<Coord>();
            SnakeDirection = new Direction();
            DollarPosition = new Coord();
            randomGenerator = new Random();
        }

        // Add the game elements to console
        public void CreateGame()
        {
            // Setup gameboard options
            Board = new Board();

            // Add snake element position for head
            SnakePosition.Add(new Coord(10, 10));

            // Add Yellow snake head
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

            // Spawn a dollar at random position on screen
            SpawnDollar();

        }

        // End game using Environment.exit for closing console app
        public void EndGame()
        {
            Environment.Exit(0);
        }

        // Move snake 1 step on x or y axis
        public void MoveSnake(Direction direction)
        {
            // Add 4 snake elements when game has been started
            if (SnakePosition.Count < 4)
                AddSnakeElement();

            SnakeDirection = direction;
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
            Coord headPosition = SnakePosition.ElementAt(0);
            Coord tailPosition = SnakePosition.ElementAt(SnakePosition.Count - 1);

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
            SnakePosition.RemoveAt(SnakePosition.Count - 1);

            // Add the new head to first element
            SnakePosition.Insert(0, new Coord(newX, newY));
            if (newX >= 0 && newY >= 0
                && newX < Board.BoardWidth
                && newY < Board.BoardHeight)
            {
                Console.SetCursorPosition(newX, newY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");
                // Overwrite character of second element to body character
                Console.SetCursorPosition(bodyX, bodyY);
                Console.Write("0");
            }
        }

        public void SpawnDollar()
        {
            // Generate a random position for dollar
            DollarPosition.x = randomGenerator.Next(0, Board.BoardWidth);
            DollarPosition.y = randomGenerator.Next(0, Board.BoardHeight);

            // Spawn new dollar if spawned on snake body
            foreach (Coord snakeElement in SnakePosition)
            {
                if (DollarPosition == snakeElement)
                    SpawnDollar();
            }

            // Place green dollar at random position
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(DollarPosition.x, DollarPosition.y);
            Console.Write("$");
        }

        public void DollarHit()
        {
            // Add the new head element and spawn a dollar
            AddSnakeElement();
            SpawnDollar();
        }

        private void AddSnakeElement()
        {
            // Add snake element to last position
            Coord snake = SnakePosition.ElementAt(SnakePosition.Count - 1);
            SnakePosition.Add(snake);
        }

        public void StartGame()
        {
            GameController.PlayGame();
        }
    }
}