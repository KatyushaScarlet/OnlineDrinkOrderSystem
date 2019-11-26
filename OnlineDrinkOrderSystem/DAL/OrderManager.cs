using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineDrinkOrderSystem.Models;
using OnlineDrinkOrderSystem.Common;
using System.Data;

namespace OnlineDrinkOrderSystem.DAL
{
    public class OrderManager
    {
        //创建新订单
        public static bool NewOrder(User user, int delivery, int fee = 30)
        {
            //获取购物车信息
            List<Cart> carts = ItemManager.GetUserCart(user.User_ID);
            //创建订单列表
            List<Order_List> list = new List<Order_List>();
            //创建订单id
            int orderId = 0;
            //总价格
            double totalPrice = 0;
            //如果生成的id有重复，则一直取到无重复为止
            do
            {
                orderId = Tool.GetRandomNumber(1, 99999999);
            } while (CheckOrderIdExist(orderId));


            //检查库存
            foreach (Cart cart in carts)
            {
                int itemStock = ItemManager.GetItem(cart.Item_ID).Stock;
                if (itemStock < cart.Quantity)
                {
                    //商品无库存，创建订单失败
                    return false;
                }
            }

            //生成列表
            foreach (Cart cart in carts)
            {
                //减少商品库存
                ItemManager.ReduceStock(cart.Item_ID, cart.Quantity);
                //应用商品折扣
                double itemPrice = cart.Item_Price;
                if (cart.Discount != 0)
                {
                    //折扣价四舍五入到小数点后两位
                    double temp = itemPrice * ((100.0 - cart.Discount) / 100.0);
                    itemPrice = Math.Round(temp, 2);
                }
                //创建一条记录
                Order_List order_List = new Order_List();
                order_List.Order_ID = orderId;//生成的id
                order_List.Item_ID = cart.Item_ID;
                order_List.Order_Price = itemPrice;//折扣价格
                order_List.Quantity = cart.Quantity;
                //加入总价（价格*数量）
                totalPrice += itemPrice * cart.Quantity;
                //添加到订单列表中
                list.Add(order_List);
            }


            //如果派送方式非自取，加配送费
            if (delivery == 1)
            {
                totalPrice += fee;
            }

            //总价四舍五入到小数点后两位
            totalPrice = Math.Round(totalPrice, 2);

            //创建订单
            Order_Detail detail = new Order_Detail();
            detail.Order_ID = orderId;//生成的id
            detail.User_ID = user.User_ID;
            detail.Order_Sum = totalPrice;
            detail.Delivery = delivery;
            detail.Shipment = 1;//默认未发货
            detail.Address = user.Address;
            detail.Order_Date = DateTime.Now;

            //写入订单详情
            DbHelper.Action(string.Format("insert into Order_Detail values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                detail.Order_ID,
                detail.User_ID,
                detail.Order_Sum,
                detail.Delivery,
                detail.Shipment,
                detail.Address,
                detail.Order_Date
                ));

            //写入订单列表
            foreach (Order_List item in list)
            {
                DbHelper.Action(string.Format("insert into Order_List values('{0}','{1}','{2}','{3}')",
                    item.Order_ID,
                    item.Item_ID,
                    item.Order_Price,
                    item.Quantity
                    ));
            }

            return true;
        }

        //判断订单id是否已存在
        public static bool CheckOrderIdExist(int id)
        {
            return Convert.ToInt32(DbHelper.Read(string.Format("select count(*) from Order_Detail where Order_ID='{0}'", id))) != 0;
        }

        //判断用户是否拥有某个订单
        public static bool CheckUserOwnsOrder(int userId,int orderId)
        {
            var temp = DbHelper.Read(string.Format("select count(*) from Order_Detail where User_ID='{0}' and Order_ID='{1}'", userId, orderId));
            return Convert.ToInt32(temp) == 1;
        }

        //获取用户的所有订单
        public static List<Order_Detail> GetUserOrders(int userId)
        {
            List<Order_Detail> order_Details = new List<Order_Detail>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_Detail where User_ID='{0}'", userId));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Order_Detail detail = new Order_Detail();
                detail = Tool.DataRow2Entity<Order_Detail>(row);
                order_Details.Add(detail);
            }
            return order_Details;
        }

        //获取单个订单详情
        public static Order_Detail GetOrderDetail(int orderId)
        {
            Order_Detail detail = new Order_Detail();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_Detail where Order_ID='{0}'", orderId));
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                detail = Tool.DataRow2Entity<Order_Detail>(dataRow);
            }
            return detail;
        }

        //获取单个订单内商品列表
        public static List<Order_List> GetOrderList(int orderId)
        {
            List<Order_List> order_Lists = new List<Order_List>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_List left join Item on Order_List.Item_ID=Item.Item_ID where Order_ID='{0}'", orderId));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Order_List list = new Order_List();
                list = Tool.DataRow2Entity<Order_List>(row);
                order_Lists.Add(list);
            }
            return order_Lists;
        }
    }
}
