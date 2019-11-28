using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Order_Detail
    {
        public int Order_ID{ get; set; }
        public int User_ID{ get; set; }
        public double Order_Sum{ get; set; }
        public double Order_Cost { get; set; }
        public int Delivery{ get; set; }
        public int Shipment{ get; set; }
        public string Address{ get; set; }
        public DateTime Order_Date{ get; set; } 

        public string User_Name { get; set; }
    }

     public class Order_List
    {
        public int Order_ID{ get; set; }
        public int Item_ID{ get; set; }
        public double Order_Price{ get; set; }
        public double Order_Cost { get; set; }
        public int Quantity{ get; set; }
        public string Item_Name { get; set; }
        public string Image_Url { get; set; }
    }
}
