using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class User
    {
        public int User_ID{ get; set; }
        public string Google_ID{ get; set; }
        public string User_Name{ get; set; }
        public string User_Avater{ get; set; }
        public string Given_Name{ get; set; }
        public string Family_Name{ get; set; }
        public string Address{ get; set; }
        public bool Admin{ get; set; }
    }
}
