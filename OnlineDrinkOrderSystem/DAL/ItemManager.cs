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
        public static List<Category> GetCategories()
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

        //添加类别
    }
}
