using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;
using System.Data;

namespace OnlineDrinkOrderSystem.DAL
{
    public class ItemManager
    {
        //获取所有类别
        public static List<Category> GetCategoryList()
        {
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Category"));
            List<Category> categories = new List<Category>();
            //逐条取出
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Category category = new Category();
                category = Tool.DataRow2Entity<Category>(row);
                categories.Add(category);
            }
            return categories;
        }

        //修改类别

        //删除类别
        //修改该分类下的商品至默认分类

        //添加类别

        //获取商品（单个）
        public static Item GetItem(int id)
        {
            Item item = null;
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Item where Item_ID='{0}'", id));
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                item = Tool.DataRow2Entity<Item>(dataRow);
            }
            return item;
        }


        //获取商品（列表）
        //页数，每页大小
        //搜索 关键词
        //根据销量/价格（从低到高/从高到低）/新品 排序
        //根据 类别 筛选
        public static List<Item> GetItemList(out int totalPages,int page = 0, int pageSize = 20, string keyWord = "", int category_ID = 0, ItemOrder itemOrder = ItemOrder.none)
        {
            string queryString = "";
            //计算计算偏移，页数*页大小
            int offSet = pageSize * page;
            //如果查询字符串不为空，添加查询条件
            if (!string.IsNullOrEmpty(keyWord))
            {
                queryString += string.Format(" and (Item_Name like'%{0}%' or Description like'%{0}%') ", keyWord);
            }
            //如果分类id有效（>0），添加查询条件
            if (category_ID > 0)
            {
                queryString += string.Format(" and Category.Category_ID='{0}' ", category_ID);
            }
            //如果排序有效（非none），添加排序语句
            switch (itemOrder)
            {
                case ItemOrder.none:
                    break;
                case ItemOrder.sold:
                    queryString += " order by Sold desc ";
                    break;
                case ItemOrder.lastest:
                    queryString += " order by Date_added desc ";
                    break;
                case ItemOrder.price_low2high:
                    queryString += " order by Item_Price asc ";
                    break;
                case ItemOrder.price_high2low:
                    queryString += " order by Item_Price desc ";
                    break;
                default:
                    break;
            }
            //查询总条目数量
            var sql2 = string.Format("select count(*) from Item left join Category on Item.Category_ID=Category.Category_ID where 1=1 {0}", queryString);
            int itemCount = Convert.ToInt32(DbHelper.Read(sql2));
            //计算总页数
            totalPages = itemCount / pageSize;
            //开始查询
            var sql1 = string.Format("select * from Item left join Category on Item.Category_ID=Category.Category_ID where 1=1 {0} limit {1},{2}", queryString, offSet, pageSize);
            DataSet dataSet = DbHelper.ReadDataSet(sql1);
            List<Item> items = new List<Item>();
            //逐条取出
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Item item = new Item();
                item = Tool.DataRow2Entity<Item>(row);
                items.Add(item);
            }

            return items;
        }

        //添加商品
        public static bool AddItem(Item item)
        {
            return DbHelper.Action(string.Format("insert into Item values(null,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                item.Item_Name,
                item.Image_Url,
                item.Description,
                item.Item_Price,
                item.Category_ID,
                item.Click_Counts,
                item.Stock,
                item.Date_added,
                item.Cost,
                item.Sold,
                item.Discount
                )) == 1;
        }





        //修改商品信息

        //删除商品
        //将该商品评论删除
        //将购物车内的该商品删除
        //将用户追踪列表中该商品删除



        //获取购物车信息
        public static List<Cart> GetUserCart(int id)
        {
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Cart LEFT JOIN Item on Cart.Item_ID=Item.Item_ID WHERE User_ID='{0}'", id));
            List<Cart> carts = new List<Cart>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Cart cart = new Cart();
                cart = Tool.DataRow2Entity<Cart>(dataRow);
                carts.Add(cart);
            }

            return carts;
        }

        //将商品加入购物车
        public static void AddItemToCart(int userId,int itemId, int itemCount)
        {
            //查找该商品是否已存在购物车中
            bool exist = Convert.ToInt32(DbHelper.Read(string.Format("select count(*) from Cart where User_ID='{0}' and Item_ID='{1}'", userId, itemId))) != 0;
            if (exist)
            {
                //已存在，添加数量
                DbHelper.Action(string.Format("update Cart set Quantity=(Quantity+{2}) where User_ID='{0}' and Item_ID='{1}'", userId, itemId, itemCount));
            }
            else
            {
                //不存在，添加一条
                DbHelper.Action(string.Format("insert into Cart values(null,'{0}','{1}','{2}')", userId, itemId, itemCount));
            }
            //商品点击数加一
            DbHelper.Action(string.Format("update Item set Click_Counts=Click_Counts+1 where Item_ID='{0}'", itemId));
        }

        //更新购物车
        public static void UpdateCart(int id,List<Cart> carts)
        {
            //清空原有的购物车
            DbHelper.Action(string.Format("delete from Cart where User_ID='{0}'", id));

            if (carts.Count!=0)
            {
                foreach (Cart item in carts)
                {
                    //逐条添加
                    DbHelper.Action(string.Format("insert into Cart values(null,'{0}','{1}','{2}')", id, item.Item_ID, item.Quantity));
                }
            }
        }
    }
}