using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    class Bakery
    {
        public ICookie[] cookies = new ICookie[12];
        public bool bakeryOpen;
        Object lockObject = new Object ();

        public Bakery()
        {
            bakeryOpen = true;
        }

        public void BakeCookies() {
            for (int i = 0; i < 12; i++) {
                Thread.Sleep (667);
                cookies[i] = CreateCookie ();
                Console.WriteLine ("Bakery made " + cookies[i].GetDescription () + " #" + (i + 1));
            }
            CloseBakery ();
        }
        
        public void SellToCustomer(Customer customer) {
            lock (lockObject) {
                for (int i = 0; i < 12; i++) {
                    if (cookies[i] != null) {
                        Console.WriteLine ("                                        " 
                            + customer.name + " recieved " + cookies[i].GetDescription () + " #" + (i + 1));
                        cookies[i] = null;
                    }
                }
            }
        }

        private ICookie CreateCookie()
        {
            ICookie cookie;

            Random randomGenerator = new Random ();
            int randomType = randomGenerator.Next (1, 4);

            cookie = new BaseCookie();

            if (randomType == 2)
                cookie = new ChocolateDecorator (cookie);
            else if (randomType == 3)
                cookie = new RaisinDecorator (cookie);
            else if (randomType == 4)
                new ChocolateDecorator (new RaisinDecorator(cookie));

            return cookie;
        }

        public void CloseBakery () {
            bakeryOpen = false;
        }
    }
}
