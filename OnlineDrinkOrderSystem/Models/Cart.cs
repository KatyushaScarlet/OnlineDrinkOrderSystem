using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Cart
    {
        public int Cart_ID { get; set; }
        public int User_ID { get; set; }
        public int Item_ID { get; set; }
        public int Quantity { get; set; }
        public string Item_Name { get; set; }
        public string Image_Url { get; set; }
        public double Item_Price { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
    }

    public class CartPost
    {
        public int name { get; set; }
        public int value { get; set; }
    }
}
