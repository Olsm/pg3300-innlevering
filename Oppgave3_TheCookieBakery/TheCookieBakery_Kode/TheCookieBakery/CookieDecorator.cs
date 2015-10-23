using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class CookieDecorator : ICookie
    {
        private ICookie original;

        public CookieDecorator(ICookie original)
        {
            this.original = original;
        }

        public virtual string GetDescription()
        {
            return original.GetDescription();
        }
    }
}
