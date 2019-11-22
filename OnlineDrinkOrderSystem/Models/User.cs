using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Admin { get; set; }
    }
}
