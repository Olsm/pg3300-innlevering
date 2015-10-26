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
            var bakery = new Bakery ();
            var fred = new Customer ("Fred", bakery);
            var ted = new Customer ("Ted", bakery);
            var greg = new Customer ("Greg", bakery);
            
            bakery.BakeCookies();

            Console.ReadKey();
        }
    }
}
