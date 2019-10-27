using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Common
{
    public class Common
    {
        private const string googleAppId = "503080678367-hc55im7qgftp6mrd9qbafdde29qq9fk2.apps.googleusercontent.com";
        private const string googleIss = "accounts.google.com";
        private const string googleCertsUrl = "https://www.googleapis.com/oauth2/v3/certs";


        public static bool GoogleJwtVerify(string jwtString)//验证jwt是否有效
        {
            //获取公钥
            GoogleCerts certs = JsonConvert.DeserializeObject<Models.GoogleCerts>(HttpGet(googleCertsUrl));

            List<SecurityKey> keys = new List<SecurityKey>();

            foreach (var item in certs.keys)
            {
                keys.Add(new JsonWebKey(JsonConvert.SerializeObject(item)));
            }

            try
            {
                //验证Token
                IdentityModelEventSource.ShowPII = true;
                var principal = new JwtSecurityTokenHandler()
                    .ValidateToken(jwtString, new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidIssuer = googleIss,
                        ValidateAudience = true,
                        ValidAudience = googleAppId,
                        ValidateLifetime = false,
                        IssuerSigningKeys = keys
                    }, out var rawValidatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static Jwt JwtConvertObject(string jwtString)//序列化jwt
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

        public static string HttpGet(string Url, string postDataStr="")
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
    }
}
