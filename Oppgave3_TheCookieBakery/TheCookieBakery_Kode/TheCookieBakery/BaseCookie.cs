﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class BaseCookie : IFood
    {
        public string GetDescription()
        {
            return "Cookie";
        }
    }
}
