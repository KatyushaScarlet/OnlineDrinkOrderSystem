using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Trace
    {
        public int User_ID { get; set; }
        public int Item_ID { get; set; }
        public double Trace_Price { get; set; }
        public string Image_Url { get; set; }
        public string Item_Name { get; set; }
        public double Item_Price { get; set; }
        public int Discount { get; set; }
    }
}
