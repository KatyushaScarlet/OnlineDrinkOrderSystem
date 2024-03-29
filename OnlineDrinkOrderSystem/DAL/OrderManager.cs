﻿using System;
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

            //计算订单成本
            double totalCost = 0;

            //生成列表
            foreach (Cart cart in carts)
            {
                //减少商品库存
                ItemManager.ReduceStock(cart.Item_ID, cart.Quantity);
                //应用商品折扣
                double itemPrice = cart.Item_Price;
                if (cart.Discount != 0)
                {
                    //折扣价四舍五入
                    double calculate = itemPrice * ((100.0 - cart.Discount) / 100.0);
                    itemPrice = Tool.Rounde(calculate);
                }
                //商品成本
                double itemCost = ItemManager.GetItemCost(cart.Item_ID);
                //创建一条记录
                Order_List order_List = new Order_List();
                order_List.Order_ID = orderId;//生成的id
                order_List.Item_ID = cart.Item_ID;
                order_List.Order_Cost = itemCost;//商品进价
                order_List.Order_Price = itemPrice;//折扣价格
                order_List.Quantity = cart.Quantity;
                //计入总价（价格*数量）
                totalPrice += itemPrice * cart.Quantity;
                //记入成本（价格*数量）
                totalCost += itemCost * cart.Quantity;
                //添加到订单列表中
                list.Add(order_List);
            }


            //如果派送方式非自取，加配送费
            if (delivery == 1)
            {
                totalPrice += fee;
            }

            //总价四舍五入（保留两位）
            totalPrice = Tool.Rounde(totalPrice);

            //创建订单
            Order_Detail detail = new Order_Detail();
            detail.Order_ID = orderId;//生成的id
            detail.User_ID = user.User_ID;
            detail.Order_Sum = totalPrice;
            detail.Order_Cost = totalCost;
            detail.Delivery = delivery;
            detail.Shipment = 1;//默认未发货
            detail.Address = user.Address;
            detail.Order_Date = DateTime.Now;

            //写入订单详情
            DbHelper.Action(string.Format("insert into Order_Detail values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                detail.Order_ID,
                detail.User_ID,
                detail.Order_Sum,
                detail.Order_Cost,
                detail.Delivery,
                detail.Shipment,
                detail.Address,
                detail.Order_Date.ToString("yyyy-MM-ddTHH:mm:ss")
                ));

            //写入订单列表
            foreach (Order_List item in list)
            {
                DbHelper.Action(string.Format("insert into Order_List values('{0}','{1}','{2}','{3}','{4}')",
                    item.Order_ID,
                    item.Item_ID,
                    item.Order_Price,
                    item.Order_Cost,
                    item.Quantity
                    ));
            }

            //下单成功后清空原有的购物车
            DbHelper.Action(string.Format("delete from Cart where User_ID='{0}'", user.User_ID));

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

        //获取用户的所有订单，按时间排序，新的在前（desc）
        public static List<Order_Detail> GetUserOrders(int userId)
        {
            List<Order_Detail> order_Details = new List<Order_Detail>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_Detail where User_ID='{0}' order by Order_Date desc", userId));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Order_Detail detail = new Order_Detail();
                detail = Tool.DataRow2Entity<Order_Detail>(row);
                order_Details.Add(detail);
            }
            return order_Details;
        }

        //获取所有订单，按时间排序，新的在前（desc）
        public static List<Order_Detail> GetAllOrders()
        {
            List<Order_Detail> order_Details = new List<Order_Detail>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_Detail left join User on Order_Detail.User_ID=User.User_ID order by Order_Date desc"));
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
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_Detail left join User on Order_Detail.User_ID=User.User_ID where Order_ID='{0}'", orderId));
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                detail = Tool.DataRow2Entity<Order_Detail>(dataRow);
            }
            return detail;
        }

        //获取单个订单内商品列表，按商品id排序，小的在前（asc）
        public static List<Order_List> GetOrderList(int orderId)
        {
            List<Order_List> order_Lists = new List<Order_List>();
            DataSet dataSet = DbHelper.ReadDataSet(string.Format("select * from Order_List left join Item on Order_List.Item_ID=Item.Item_ID where Order_ID='{0}'  order by Item.Item_ID asc", orderId));
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Order_List list = new Order_List();
                list = Tool.DataRow2Entity<Order_List>(row);
                order_Lists.Add(list);
            }
            return order_Lists;
        }

        //设置订单发货状态
        public static bool SetOrderStatus(int orderId,int status)
        {
            return Convert.ToInt32(DbHelper.Action(string.Format("update Order_Detail set Shipment='{1}' where Order_ID='{0}'", orderId, status))) == 1;
        }

        //删除订单
        public static void DeleteOrder(int orderId)
        {
            //删除订单内商品列表
            DbHelper.Action(string.Format("delete from Order_List where Order_ID='{0}'", orderId));
            //删除订单
            DbHelper.Action(string.Format("delete from Order_Detail where Order_ID='{0}'", orderId));
        }
    }
}
