using System;
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

            // Wait for bakery to close
            while (bakery.bakeryOpen) {
                Thread.Sleep (1000);
            }

            // Print how many cookies the customers got, when bakery has closed
            Console.WriteLine ();
            Console.WriteLine ("Bakery has closed, customer results:");
            foreach (Customer customer in customers) {
                Console.WriteLine (customer.Name + " got " + customer.cookies.Count + " cookie(s)");
            }

            Console.ReadKey ();
        }

        // Setup bakery, customers and console
        private static void CreateGame ()
        {
            Random randomGenerator = new Random ();
            int cookiesToBake = randomGenerator.Next (12, 21);

            // Set console width and height to try and show all text
            int consoleColumns = 100;
            int consoleRows = cookiesToBake * 2 + 6;
            if (consoleRows > Console.LargestWindowHeight - 1)
                consoleRows = Console.LargestWindowHeight - 1;
            if (consoleColumns > Console.LargestWindowWidth)
                consoleColumns = Console.LargestWindowWidth;
            Console.SetWindowSize(consoleColumns, consoleRows);
            Console.Title = "The Cookie Bakery";

            bakery = new Bakery(cookiesToBake);
            totalCustomers = 3;

            CreateCustomers();
            CreateThreads();
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
