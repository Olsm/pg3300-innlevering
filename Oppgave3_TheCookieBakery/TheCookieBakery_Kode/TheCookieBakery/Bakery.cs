using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class Bakery
    {
        public static ICookie[] cookies = new ICookie[12];

        public Bakery()
        {
            
        }

        public static void CreateCookie()
        {
            for (int i = 0; i < 4; i++)
                cookies[i] = new BaseCookie();
            for (int i = 4; i < 8; i++)
                cookies[i] = new ChocolateDecorator(new BaseCookie());
            for (int i = 9; i < 12; i++)
                cookies[i] = new RaisinDecorator(new BaseCookie());
        }
    }
}
