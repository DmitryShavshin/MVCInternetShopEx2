using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class Properties
    {

        public List<Button> Buttons { get; set; }

        public Properties() { }

        public Properties(List<Button> buttons)
        {
            this.Buttons = buttons;
        }
    }
}