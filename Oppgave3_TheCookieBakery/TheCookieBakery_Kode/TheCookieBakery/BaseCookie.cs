namespace TheCookieBakery
{
    class BaseCookie : ICookie
    {
        private int cookieID;

        public BaseCookie(int cookieID) 
        {
            this.cookieID = cookieID;
        }

        public int GetID() 
        {
            return cookieID;
        }

        public string GetDescription()
        {
            return "Cookie";
        }
    }
}
