using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class CookieDecorator : IFood
    {
        private IFood original;

        public CookieDecorator(IFood original)
        {
            this.original = original;
        }

        public virtual string GetDescription()
        {
            return original.GetDescription();
        }
    }
}
