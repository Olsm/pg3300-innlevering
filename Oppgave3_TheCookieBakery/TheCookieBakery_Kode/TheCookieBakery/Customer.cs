using System;
using System.Linq;
using System.Threading;

namespace TheCookieBakery
{
    class Customer
    {
        public string Name { get; set; }
        private readonly Bakery _bakery;

        // Set the customer name and bakery
        public Customer(String name, Bakery bakery) {
            Name = name;
            _bakery = bakery;
        }

        // Look for and buy cookie once per second while bakery is open
        public void BuyCookies() {
            while (_bakery.bakeryOpen) {
            Thread.Sleep (1000);

                // Use lock to prevent race condition for multi threading
                lock (_bakery.LockObject)
                {
                    // Count cookies in basket and buy one if there is 1 or more available
                    if (_bakery.cookies.Count(cookie => cookie != null) > 0)
                    {
                        _bakery.SellToCustomer(this);
                    }
                }
            }
        }
    }
}
