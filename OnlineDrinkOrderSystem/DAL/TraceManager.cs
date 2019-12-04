using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;
using System.Data;

namespace OnlineDrinkOrderSystem.DAL
{
    public class TraceManager
    {
        //获取用户追踪列表
        public static List<Trace> GetTraceList(int userId)
        {
            List<Trace> traces = new List<Trace>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Trace_List inner join Item on Trace_List.Item_ID=Item.Item_ID where Trace_List.User_ID='{0}'", userId));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Trace trace = new Trace();
                trace = Tool.DataRow2Entity<Trace>(row);
                traces.Add(trace);
            }
            return traces;
        }

        //添加到追踪列表
        public static void AddItemToList(int userId, int itemId)
        {
            DbHelper.Action(string.Format("replace into Trace_List " +
                "VALUES('{0}','{1}'," +
                "(select Item_Price from Item where Item_ID='{1}')" +
                ")", userId, itemId));
        }

        //从追踪列表中移除
        public static void RemoveItemFromList(int userId, int itemId)
        {
            DbHelper.Action(string.Format("delete from Trace_List " +
                "where User_ID='{0}' and Item_ID='{1}'", userId, itemId));
        }

        //判断商品是否存在于用户的追踪列表中
        public static bool CheckItemInTraceList(int userId, int itemId)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select count(*) from Trace_List where User_ID='{0}' and Item_ID='{1}'", userId, itemId))) != 0;
        }
    }
}
