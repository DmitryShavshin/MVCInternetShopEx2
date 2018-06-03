using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class GoodsList
    {
        public List<AllGoods> AllGoods { get; set; }
        public List<Button> Buttons { get; set; }
        public RegistrUser RegUser { get; set; }

        public GoodsList(){}   

        public GoodsList(List<Button> buttons)
        {
            this.Buttons = buttons;
        }
    }
}