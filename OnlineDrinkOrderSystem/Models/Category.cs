using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    /*
    CREATE TABLE Category(
    Category_ID INT NOT NULL AUTO_INCREMENT,-- 类型id
    Category_Name VARCHAR(255) NOT NULL,-- 类型名称
    primary key(Category_ID)-- 主键 类型id
    );
    */
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
    }
}
