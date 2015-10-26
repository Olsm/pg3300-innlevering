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
                Thread.Sleep (700);
                cookies[i] = CreateCookie ();
                Console.WriteLine ("Bakery made " + cookies[i].GetDescription () + " #" + i);
            }
            CloseBakery ();
        }
        
        public void SellToCustomer(Customer customer) {
            lock (lockObject) {
                for (int i = 0; i < 12; i++) {
                    if (cookies[i] != null) {
                        Console.WriteLine ("                                 " +
                            customer.name + " recieved " + cookies[i].GetDescription () + " " + i);
                        cookies[i] = null;
                    }
                }
            }
        }

        private ICookie CreateCookie()
        {
            
            //private static Random randomGenerator = new Random ();
            //private int randomType = randomGenerator.Next (1, 4);
            /*
            for (int i = 0; i < 4; i++) {
                cookies[i] = new BaseCookie ();
            }
            for (int i = 4; i < 8; i++) {
                cookies[i] = new ChocolateDecorator(new BaseCookie());
            }
                
            for (int i = 8; i < 12; i++) {
                cookies[i] = new RaisinDecorator(new BaseCookie());
            }
            */
               
            return new BaseCookie ();
        }

        public void CloseBakery () {
            bakeryOpen = false;
        }
    }
}
