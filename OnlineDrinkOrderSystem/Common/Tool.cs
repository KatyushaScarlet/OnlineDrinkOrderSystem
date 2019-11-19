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
        //序列化token
        public static Jwt GoogleToken2Jwt(string jwtString)
        {
            Jwt jwt = new Jwt();

            //分割jwt
            string[] values = jwtString.Split(".");

            //序列化jwt
            jwt.jwtHeader = JsonConvert.DeserializeObject<Models.JwtHeader>(Base64UrlEncoder.Decode(values[0]));
            jwt.jwtPayload = JsonConvert.DeserializeObject<Models.JwtPayload>(Base64UrlEncoder.Decode(values[1]));
            jwt.jwtSignature = values[2];

            return jwt;
        }

        //public static string Base64Encode(string input)
        //{
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        //}

        //public static string Base64Decode(string input)
        //{
        //    Base64UrlEncoder.
        //    return Encoding.UTF8.GetString(Convert.FromBase64String(input));
        //}

        //Get
        public static string HttpGet(string Url, string postDataStr = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        //Post
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }

        //GoogleJwt转User类
        public static User GoogleJwt2User(Jwt jwt)
        {
            User user = new User();
            user.User_ID = -1;
            user.Google_ID = jwt.jwtPayload.sub;
            user.User_Name = jwt.jwtPayload.name;
            user.User_Avater = jwt.jwtPayload.picture;
            user.Given_Name = jwt.jwtPayload.given_name;
            user.Family_Name = jwt.jwtPayload.family_name;
            user.Address = "";
            user.Admin = false;
            return user;
        }

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

        ////读取Session
        //public static T getSessionObject<T>(ISession session, string key)
        //{
        //    if (session.TryGetValue(key, out byte[] value))
        //    {
        //        string json = System.Text.Encoding.UTF8.GetString(value);
        //        return JsonConvert.DeserializeObject<T>(json);
        //    }
        //    return default(T);
        //}

        ////设置Sessin
        //public static void setSessionObject(ISession session, string key, object value)
        //{
        //    string json = JsonConvert.SerializeObject(value);
        //    byte[] result = System.Text.Encoding.UTF8.GetBytes(json);
        //    session.Set(key, result);
        //}

        public static string GetRandomString(int n)//获取指定长度随机字符串
        {
            //string s = "0123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ~!@#$%^&*()_+`-=";
            string s = "0123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
            string value = "";
            Random rdm = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")).GetHashCode());//保证不重复
            while (value.Length < n)
            {
                string s1 = s[rdm.Next(0, s.Length)].ToString();
                value += s1;
            }
            return value;
        }
    }
}
