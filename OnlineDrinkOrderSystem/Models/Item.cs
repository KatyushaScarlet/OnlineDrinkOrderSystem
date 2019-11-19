using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    /*
    CREATE TABLE Item(
    Item_ID INT NOT NULL AUTO_INCREMENT,-- 商品id
    Item_Name VARCHAR(255) NOT NULL,-- 商品名称
    Image_Url VARCHAR(255),-- 商品图片链接
    Description VARCHAR(255) NOT NULL,-- 商品描述
    Item_Price DOUBLE NOT NULL,-- 价格
    Category_ID INT NOT NULL,-- 类型id
    Click_Counts INT NOT NULL,-- 点击次数
    Stock INT NOT NULL,-- 库存
    Date_added DATETIME NOT NULL,-- 上架时间
    Cost DOUBLE NOT NULL,-- 进价/成本
    Sold INT NOT NULL,-- 已售出
    Discount INT,-- 商品折扣（10 -> -10%）
    primary key(Item_ID),-- 主键 商品id
    foreign key(Category_ID) REFERENCES Category(Category_ID)-- 外键 类型id
    );
    */
    public class Item
    {
        public int Item_ID{get;set;}
        public string Item_Name{get;set;}
        public string Image_Url{get;set;}
        public string Description{get;set;}
        public double Item_Price{get;set;}
        public int Category_ID{get;set;}
        public int Click_Counts{get;set;}
        public int Stock{get;set;}
        public DateTime Date_added{get;set;}
        public double Cost{get;set;}
        public int Sold{get;set;}
        public int Discount{get;set;}
    }

    public enum ItemOrder
    {
        none,
        sold,
        price_low2high,
        price_high2low,
        lastest
    }
}
