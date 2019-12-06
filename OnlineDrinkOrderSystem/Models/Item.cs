using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Item
    {
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public string Image_Url { get; set; }
        public string Description { get; set; }
        public double Item_Price { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Click_Counts { get; set; }
        public int Stock { get; set; }
        public DateTime Date_added { get; set; }
        public double Cost { get; set; }
        public int Sold { get; set; }
        public int Discount { get; set; }
    }
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
    }

    public enum ItemOrder
    {
        none,
        sold,
        lastest,
        price_low2high,
        price_high2low
    }
}
