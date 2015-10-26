using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    public abstract class CreateCookieType
    {
        public String type;
        //public String accessory;

        public void setCookieType(String type)
        {
            this.type = type;
        }
        public string getCookieType()
        {
            return type;
        }

        /* public void setCookieAccessory(String accessory)
         {
             this.accessory = accessory;
         }
         public String getCookieAccessory()
         {

             return accessory;
         }*/
    }
}
