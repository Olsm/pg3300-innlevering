using System;
using System.Threading;

namespace TheCookieBakery
{
    class Bakery
    {
        public ICookie[] cookies;
        public bool bakeryOpen;
        private int totalCookies;
        public int cookieIndex { get; private set; }
        internal readonly Object LockObject = new Object ();    // Create an object for using lock in multithreading
        private int nextCookieID;

        // Open bakery, create basket and chose number of cookies to make
        public Bakery(int totalCookies = 12)
        {
            bakeryOpen = true;
            this.totalCookies = totalCookies;
            cookies = new ICookie[totalCookies];
            nextCookieID = 1;
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
        }
        
        // Sell cookie to customer by writing description to console and removing cookie from basket
        public ICookie SellToCustomer(Customer customer)
        {
            // Use lock to prevent race condition for multi threading
            lock (LockObject)
            {
                // Make sure cookieIndex in array is there
                if (cookies[cookieIndex] != null) {
                    // Remove cookie from basket and give to customer
                    ICookie cookie = cookies[cookieIndex];
                    cookies[cookieIndex] = null;

                    Console.WriteLine ("                                                   "
                            + customer.Name + " bought " + cookie.GetDescription () + " #" + cookie.GetID());

                    if (cookieIndex < totalCookies - 1)
                        cookieIndex++;
                    else
                        CloseBakery();  // Close bakery when all cookies have been sold
                    return cookie;
                }

                return null;
            }
        }

        // Bakes and returns a cookie with random filling
        private ICookie BakeCookie()
        {
            ICookie cookie = new BaseCookie (nextCookieID);

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

            nextCookieID++;
            return cookie;
        }

        // Close the bakery so that threads will stop looking for cookies
        public void CloseBakery ()
        {
            bakeryOpen = false;
        }
    }
}
