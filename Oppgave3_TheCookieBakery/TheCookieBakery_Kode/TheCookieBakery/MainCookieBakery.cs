﻿using System;
using System.Threading;

namespace TheCookieBakery
{
    class MainCookieBakery
    {
        private static Bakery bakery;
        private static Customer[] customers;
        private static Thread[] threads;
        private static int totalCustomers;

        static void Main (string[] args)
        {
            CreateGame();
            StartGame();
            Console.ReadKey();
        }

        // Setup bakery, customers and console
        private static void CreateGame ()
        {
            bakery = new Bakery();
            totalCustomers = 3;

            CreateCustomers();
            CreateThreads();

            // Set console width and height to half screen size to show all text
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
            Console.Title = "The Cookie Bakery";
        }

        // Create some customers
        private static void CreateCustomers()
        {
            customers = new Customer[totalCustomers];
            customers[0] = new Customer("Fred", bakery);
            customers[1] = new Customer("Ted", bakery);
            customers[2] = new Customer("Greg", bakery);
        }

        // Create a thread per customer for multi threading
        private static void CreateThreads()
        {
            threads = new Thread[totalCustomers];

            for (int i = 0; i < totalCustomers; i++) {
                threads[i] = new Thread(new ThreadStart(customers[i].BuyCookies));
            }
        }

        // Start customer threads and start baking cookies
        private static void StartGame()
        {
            for (int i = 0; i < totalCustomers; i++) {
                threads[i].Start();
            }

            bakery.BakeCookies();
        }
    }
}