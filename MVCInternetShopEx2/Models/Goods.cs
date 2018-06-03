using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class AllGoods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        //public int SelectCount { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
        public string Img6 { get; set; }
        public string GroupGoods { get; set; }

        public AllGoods(int id, string name, double price, int count, string img1, string img2, string img3, string img4, string img5, string img6, string groupGoods)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.Img1 = img1;
            this.Img2 = img2;
            this.Img3 = img3;
            this.Img4 = img4;
            this.Img5 = img5;
            this.Img6 = img6;
            this.GroupGoods = groupGoods;
        }

        public AllGoods()
        {

        }
    }
}