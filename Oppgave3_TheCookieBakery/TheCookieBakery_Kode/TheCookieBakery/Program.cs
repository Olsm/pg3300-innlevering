using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCookieType cookieChocolate = new CookieWithChocolate();
            CreateCookieType cookieRaisins = new CookieWithRaisins();
            CreateCookieType cookieAll = new CookieWithAll();

            Console.WriteLine(cookieChocolate.getCookieType());
            Console.WriteLine(cookieRaisins.getCookieType());
            Console.WriteLine(cookieAll.getCookieType());
            Console.ReadKey();

        }
    }
}
