using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class Button
    {
        public string Name { get; set; }
        public bool PressBtn { get; set; }

        public Button() { }

        public Button(string name, bool pressButton)
        {
            this.Name = name;
            this.PressBtn = pressButton;
        }
    }
}