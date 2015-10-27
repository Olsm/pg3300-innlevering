using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);

            var bakery = new Bakery ();
            
            Customer[] customers = new Customer[3];
            customers[0] = new Customer ("Fred", bakery);
            customers[1] = new Customer ("Ted", bakery);
            customers[2] = new Customer ("Greg", bakery);

            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++) {
                threads[i] = new Thread (new ThreadStart (customers[i].BuyCookies));
            }

            for (int i = 0; i < 3; i++) {
                threads[i].Start ();
            }

            bakery.BakeCookies();

            Console.ReadKey();
        }
    }
}
