﻿namespace TheCookieBakery
{
    class RaisinDecorator : CookieDecorator
    {
        public RaisinDecorator(ICookie original) : base(original){ }

        public override string GetDescription()
        {
            if (base.GetDescription().Contains("with"))
                return base.GetDescription() + " and raisin";
            return base.GetDescription() + " with raisin";
        }
    }
}