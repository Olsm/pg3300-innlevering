using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class Program
    {
        Bakery bakery = new Bakery();

        static void Main (string[] args)
        {
            Bakery.CreateCookie();
            
            for (int i = 0; i < 12; i++)
                Console.WriteLine(Bakery.cookies[i].GetDescription());

            Console.ReadKey();
        }
    }
}
