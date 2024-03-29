﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TheCookieBakery
{
    class Customer
    {
        public string Name { get; set; }
        private readonly Bakery _bakery;
        public List<ICookie> Cookies { get; private set; }

        // Set the customer name and bakery
        public Customer(String name, Bakery bakery) {
            Name = name;
            _bakery = bakery;
            Cookies = new List<ICookie>();
        }

        // Look for and buy cookie once per second while bakery is open
        // Do not use lock so customers try to buy the same cookie
        public void BuyCookies() {
            while (_bakery.BakeryOpen) {
                Thread.Sleep (1000);
                
                // Count cookies in basket and try to buy one if there is 1 or more available
                if (_bakery.Cookies.Count(cookie => cookie != null) > 0) {
                    ICookie cookie = _bakery.SellToCustomer (this);

                    // Add cookie to the customer cookie list if he got one
                    if (cookie != null) {
                        Cookies.Add (cookie);
                    }
                }
            }
        }
    }
}
