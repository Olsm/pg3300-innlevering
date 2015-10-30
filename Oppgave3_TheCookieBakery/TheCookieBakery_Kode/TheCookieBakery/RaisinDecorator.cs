namespace TheCookieBakery
{
    class RaisinDecorator : CookieDecorator
    {
        public RaisinDecorator(ICookie original) : base(original){ }

        public override string GetDescription()
        {
            return base.GetDescription() + "raisin";
        }
    }
}