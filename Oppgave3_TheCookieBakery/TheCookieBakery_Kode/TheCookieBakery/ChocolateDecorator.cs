namespace TheCookieBakery
{
    class ChocolateDecorator : CookieDecorator
    {
        public ChocolateDecorator(ICookie original) : base(original){ }

        public override string GetDescription()
        {
            if (base.GetDescription().Contains("with"))
                return base.GetDescription() + " and chocolate";
            return base.GetDescription() + " with chocolate";
        }
    }
}
