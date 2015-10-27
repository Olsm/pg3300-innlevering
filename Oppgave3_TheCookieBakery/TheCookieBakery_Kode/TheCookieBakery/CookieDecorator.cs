namespace TheCookieBakery
{
    abstract class CookieDecorator : ICookie
    {
        private ICookie original;

        protected CookieDecorator(ICookie original)
        {
            this.original = original;
        }

        public virtual string GetDescription()
        {
            return original.GetDescription();
        }
    }
}
