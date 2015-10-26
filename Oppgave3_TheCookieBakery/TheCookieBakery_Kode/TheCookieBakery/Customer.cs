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
            this.name = name;
            this.bakery = bakery;
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
