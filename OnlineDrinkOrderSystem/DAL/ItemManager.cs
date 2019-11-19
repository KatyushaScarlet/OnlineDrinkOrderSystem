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
            //如果查询结果行数不为0
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                //逐条取出
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Category category = new Category();
                    category = Tool.DataRow2Entity<Category>(row);
                    categories.Add(category);
                }
            }
            return categories;
        }

        //修改类别

        //删除类别
        //修改该分类下的商品至默认分类

        //添加类别

        //获取商品
        //页数，每页大小
        //搜索 关键词
        //根据销量/价格（从低到高/从高到低）/新品 排序
        //根据 类别 筛选

        public static List<Item> GetItemList(int page = 0, int pageSize = 20, string keyWord = "", ItemOrder itemOrder = ItemOrder.none, int category_ID = 0)
        {
            string queryString = "";
            //计算计算偏移，页数*页大小
            int offSet = pageSize * page;
            //如果分类id有效（>0），添加查询条件

            //如果排序有效（非none），添加排序语句
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
    }
}
