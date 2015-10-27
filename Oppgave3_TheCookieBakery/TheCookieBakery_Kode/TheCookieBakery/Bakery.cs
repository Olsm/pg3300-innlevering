using System;
using System.Threading;

namespace TheCookieBakery
{
    class Bakery
    {
        public ICookie[] cookies;
        public bool bakeryOpen;
        private int totalCookies;
        readonly Object _lockObject = new Object ();    // Create an object for using lock in multithreading

        // Open bakery, create basket and chose number of cookies to make
        public Bakery()
        {
            bakeryOpen = true;
            cookies = new ICookie[12];
            totalCookies = cookies.Length;
        }

        // Bakes cookies, once per 667 milliseconds
        public void BakeCookies()
        {
            for (int i = 0; i < totalCookies; i++) {
                Thread.Sleep (667);
                cookies[i] = BakeCookie ();
                Console.WriteLine ("Bakery made " + cookies[i].GetDescription () + " #" + (i + 1));
            }

            CloseBakery ();
        }
        
        // Sell cookie to customer by writing description to console and removing cookie from basket
        public void SellToCustomer(Customer customer)
        {
            // Use lock to prevent race condition for multi threading
            lock (_lockObject)
            {
                // Find the first available cookie in basket
                for (int i = 0; i < totalCookies; i++) {
                    if (cookies[i] != null) {
                        // Write description to console and remove cookie from basket
                        Console.WriteLine ("                                                   " 
                            + customer.Name + " recieved " + cookies[i].GetDescription () + " #" + (i + 1));
                        cookies[i] = null;
                    }
                }
            }
        }

        // Bakes and returns a cookie with random filling
        private ICookie BakeCookie()
        {
            ICookie cookie = new BaseCookie ();

            Random randomGenerator = new Random ();
            int randomType = randomGenerator.Next (0, 4);

            /* add random filling to cookie 
            * 0 = no filling
            * 1 = Cookie with chocolate
            * 2 = cookie with raisin
            * 3 = cookie with chocolate and raisin */
            switch (randomType)
            {
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

        // Close the bakery so that threads will stop looking for cookies
        public void CloseBakery ()
        {
            bakeryOpen = false;
        }
    }
}
