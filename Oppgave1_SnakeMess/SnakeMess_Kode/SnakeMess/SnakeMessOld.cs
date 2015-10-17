using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMessOld
{
    class Coord
    {
        public int X; public int Y;
        public Coord(int x = 0, int y = 0) { X = x; Y = y; }
        public Coord(Coord input) { X = input.X; Y = input.Y; }
    }

    class SnakeMessOld
    {
        public static void Main(string[] arguments)
        {
            bool gameOver = false, pause = false, spawnDollar = false;
            short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
            short last = newDir;
            Random rng = new Random();
            Coord dollarPosition = new Coord();
            List<Coord> snake = new List<Coord>();
            snake.Add(new Coord(10, 10)); snake.Add(new Coord(10, 10)); snake.Add(new Coord(10, 10)); snake.Add(new Coord(10, 10));
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");

            dollarPosition.X = rng.Next(0, boardWidth); dollarPosition.Y = rng.Next(0, boardHeigt);
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(dollarPosition.X, dollarPosition.Y); Console.Write("$");

            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                        gameOver = true;
                    else if (cki.Key == ConsoleKey.Spacebar)
                        pause = !pause;
                    else if (cki.Key == ConsoleKey.UpArrow && last != 2)
                        newDir = 0;
                    else if (cki.Key == ConsoleKey.RightArrow && last != 3)
                        newDir = 1;
                    else if (cki.Key == ConsoleKey.DownArrow && last != 0)
                        newDir = 2;
                    else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
                        newDir = 3;
                }
                if (!pause)
                {
                    if (timer.ElapsedMilliseconds < 100)
                        continue;
                    timer.Restart();
                    Coord tail = new Coord(snake.First());
                    Coord head = new Coord(snake.Last());
                    Coord newH = new Coord(head);
                    switch (newDir)
                    {
                        case 0:
                            newH.Y -= 1;
                            break;
                        case 1:
                            newH.X += 1;
                            break;
                        case 2:
                            newH.Y += 1;
                            break;
                        default:
                            newH.X -= 1;
                            break;
                    }
                    if (newH.X < 0 || newH.X >= boardWidth)
                        gameOver = true;
                    else if (newH.Y < 0 || newH.Y >= boardHeigt)
                        gameOver = true;
                    if (newH.X == dollarPosition.X && newH.Y == dollarPosition.Y)
                    {
                        if (snake.Count + 1 >= boardWidth * boardHeigt)
                            // No more room to place dollarPositionles -- game over.
                            gameOver = true;
                        else
                        {
                            while (true)
                            {
                                dollarPosition.X = rng.Next(0, boardWidth); dollarPosition.Y = rng.Next(0, boardHeigt);
                                bool dollarFound = true;
                                foreach (Coord i in snake)
                                    if (i.X == dollarPosition.X && i.Y == dollarPosition.Y)
                                    {
                                        dollarFound = false;
                                        break;
                                    }
                                if (dollarFound)
                                {
                                    spawnDollar = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!spawnDollar)
                    {
                        snake.RemoveAt(0);
                        foreach (Coord x in snake)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                gameOver = true;
                                break;
                            }
                    }
                    if (!gameOver)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
                        if (!spawnDollar)
                        {
                            Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(dollarPosition.X, dollarPosition.Y); Console.Write("$");
                            spawnDollar = false;
                        }
                        snake.Add(newH);
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.X, newH.Y); Console.Write("@");
                        last = newDir;
                    }
                }
            }

        }
    }
}