using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class Program
    {
        static void Main (string[] args)
        {
            var cookie = new ChocolateDecorator(new BaseCookie());
            Console.WriteLine(cookie.GetDescription());

            var cookie2 = new RaisinDecorator(cookie);
            Console.WriteLine(cookie2.GetDescription());

            Console.ReadKey();
        }
    }
}
