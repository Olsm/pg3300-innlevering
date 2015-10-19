﻿using System;
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

            // Add snake element position for head
            snakePosition.Add(new Coord(10, 10));

            // Add yellow snake head
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 10);
            Console.Write("X");

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