﻿using System;
using System.Threading;

namespace TheCookieBakery
{
    class Bakery
    {
        public ICookie[] cookies = new ICookie[12];
        public bool bakeryOpen;
        readonly Object _lockObject = new Object ();
        private int totalCookies;

        public Bakery()
        {
            bakeryOpen = true;
            totalCookies = 12;
        }

        // Bakes 12 cookies
        public void BakeCookies() {
            for (int i = 0; i < totalCookies; i++) {
                Thread.Sleep (667);
                cookies[i] = CreateCookie ();
                Console.WriteLine ("Bakery made " + cookies[i].GetDescription () + " #" + (i + 1));
            }
            CloseBakery ();
        }
        
        public void SellToCustomer(Customer customer) {
            lock (_lockObject) {
                for (int i = 0; i < totalCookies; i++) {
                    if (cookies[i] != null) {
                        Console.WriteLine ("                                                   " 
                            + customer.name + " recieved " + cookies[i].GetDescription () + " #" + (i + 1));
                        cookies[i] = null;
                    }
                }
            }
        }

        private ICookie CreateCookie()
        {
            ICookie cookie = new BaseCookie ();

            Random randomGenerator = new Random ();
            int randomType = randomGenerator.Next (0, 4);

            /* add random filling to cookie 
            * 0 = no filling
            * 1 = Cookie with chocolate
            * 2 = cookie with raisin
            * 3 = cookie with chocolate and raisin */
            switch (randomType) {
                case 1:
                    cookie = new ChocolateDecorator (cookie);
                    break;
                case 2:
                    cookie = new RaisinDecorator (cookie);
                    break;
                case 3:
                    cookie = new ChocolateDecorator (
                        new RaisinDecorator(cookie));
                    break;
            }

            return cookie;
        }

        public void CloseBakery () {
            bakeryOpen = false;
        }
    }
}
