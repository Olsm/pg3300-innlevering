using System;
using System.Threading;

namespace TheCookieBakery
{
    class Bakery
    {
        public ICookie[] cookies;
        public bool bakeryOpen;
        private int totalCookies;
        private int cookieIndex;
        internal readonly Object LockObject = new Object ();    // Create an object for using lock in multithreading

        // Open bakery, create basket and chose number of cookies to make
        public Bakery()
        {
            bakeryOpen = true;
            cookies = new ICookie[12];
            totalCookies = cookies.Length;
        }

        // Bake cookies, once per 667 milliseconds and write description to console
        public void BakeCookies()
        {
            ICookie newCookie;

            for (int i = 0; i < totalCookies; i++) {
                Thread.Sleep (667);
                newCookie = BakeCookie();
                Console.WriteLine("Bakery made " + newCookie.GetDescription() + " #" + (i + 1));
                cookies[i] = newCookie;
            }

            CloseBakery ();
        }
        
        // Sell cookie to customer by writing description to console and removing cookie from basket
        public void SellToCustomer(Customer customer)
        {
            // Use lock to prevent race condition for multi threading
            lock (LockObject)
            {
                // Make sure cookieIndex in array is there
                if (cookies[cookieIndex] != null) {
                    // Write description to console and remove cookie from basket
                    Console.WriteLine ("                                                   " 
                        + customer.Name + " recieved " + cookies[cookieIndex].GetDescription () + " #" + (cookieIndex + 1));
                    cookies[cookieIndex] = null;

                    if (cookieIndex < cookies.Length - 1)
                        cookieIndex++;
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
