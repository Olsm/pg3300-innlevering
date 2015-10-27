using System;
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
                //Console.WriteLine(_bakery.cookies.Count(i => i != null));
                if (_bakery.cookies.Length > 0) {
                    _bakery.SellToCustomer (this);
                }
            }
        }
    }
}
