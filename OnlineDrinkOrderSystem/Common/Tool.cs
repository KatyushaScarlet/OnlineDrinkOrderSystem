using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Common
{
    public class Tool
    {
        //DataRow转实体
        public static T DataRow2Entity<T>(DataRow dataRow)
        {
            T t = Activator.CreateInstance<T>(); //创建实例           
            PropertyInfo[] pi = t.GetType().GetProperties();//取类的属性

            //属性赋值
            foreach (PropertyInfo p in pi)
            {
                if (dataRow.Table.Columns.Contains(p.Name) && !string.IsNullOrWhiteSpace(dataRow[p.Name].ToString()))
                {
                    p.SetValue(t, Convert.ChangeType(dataRow[p.Name], p.PropertyType), null);
                }
            }

            return t; //Return
        }

        //生成指定位数随机数
        static Random random = new Random(System.Environment.TickCount);
        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        //四舍五入（保留两位小数）
        public static double Rounde(double input)
        {
            return Convert.ToDouble(input.ToString("#0.00"));
        }
    }
}
