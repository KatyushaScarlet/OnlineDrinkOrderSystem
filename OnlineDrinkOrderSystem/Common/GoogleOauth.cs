using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnlineDrinkOrderSystem.Models;
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
    public class GoogleOauth
    {
        public static bool GoogleJwtVerify(string jwtString)//验证jwt是否有效
        {
            //设定Google认证
            string googleAppId = Models.GoogleOauthSettings.GoogleAppId;
            string googleIss = Models.GoogleOauthSettings.GoogleIss;
            string googleCertsUrl = Models.GoogleOauthSettings.GoogleCertUrl;

            //获取公钥
            GoogleCerts certs = JsonConvert.DeserializeObject<Models.GoogleCerts>(Tool.HttpGet(googleCertsUrl));

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
    }
}
