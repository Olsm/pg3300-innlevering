using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    class Customer
    {
        public string name { get; set; }
        Bakery bakery;

        public Customer(String name, Bakery bakery) {
            Thread thread = new Thread (new ThreadStart(BuyCookies));
            this.name = name;
            this.bakery = bakery;
            thread.Start ();
        }

        public void BuyCookies() {
            while (bakery.bakeryOpen) {
            Thread.Sleep (1000);
                if (bakery.cookies.Length > 0) {
                    bakery.SellToCustomer (this);
                }
            }
        }
    }
}
