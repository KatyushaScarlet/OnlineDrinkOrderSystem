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
        public static Jwt GoogleToken2Jwt(string jwtString)//序列化token
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

        public static T DataRow2Entity<T>(DataRow r)
        {
            T t = default(T);
            t = Activator.CreateInstance<T>();
            PropertyInfo[] ps = t.GetType().GetProperties();
            foreach (var item in ps)
            {
                if (r.Table.Columns.Contains(item.Name))
                {
                    object v = r[item.Name];
                    if (v.GetType() == typeof(System.DBNull))
                        v = null;
                    item.SetValue(t, v, null);
                }
            }
            return t;
        }
    }
}
