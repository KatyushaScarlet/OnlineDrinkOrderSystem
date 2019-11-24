using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Order_Detail
    {
        public int Order_ID;
        public int User_ID;
        public double Order_Sum;
        public int Delivery;
        public int Shipment;
        public string Address;
        public DateTime Order_Date; 
    }

     public class Order_List
    {
        public int Order_ID;
        public int Item_ID;
        public double Order_Price;
        public int Quantity;
    }
}
