namespace TheCookieBakery
{
    abstract class CookieDecorator : ICookie
    {
        private ICookie original;

        protected CookieDecorator(ICookie original)
        {
            this.original = original;
        }

        public virtual int GetID() 
        {
            return original.GetID ();
        }

        public virtual string GetDescription()
        {
            if (original.GetDescription ().Contains ("with"))
                return original.GetDescription () + " and ";
            return original.GetDescription () + " with ";
        }
    }
}
