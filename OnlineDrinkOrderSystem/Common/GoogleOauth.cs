using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
using OnlineDrinkOrderSystem.Models;

namespace OnlineDrinkOrderSystem.Common
{
    public class GoogleOauth
    {
        private IOptions<GoogleOauthSettings> _configuration;
        public GoogleOauth(IOptions<GoogleOauthSettings> configuration)
        {
            _configuration = configuration;
        }

        public bool GoogleJwtVerify(string jwtString)//验证jwt是否有效
        {
            //string googleAppId = "503080678367-hc55im7qgftp6mrd9qbafdde29qq9fk2.apps.googleusercontent.com";
            //string googleIss = "accounts.google.com";
            //string googleCertsUrl = "https://www.googleapis.com/oauth2/v3/certs";

            //设定Google认证
            string googleAppId = _configuration.Value.GoogleAppId;
            string googleIss = _configuration.Value.GoogleIss;
            string googleCertsUrl = _configuration.Value.GoogleCertUrl;

            //获取公钥
            GoogleCerts certs = JsonConvert.DeserializeObject<Models.GoogleCerts>(Common.HttpGet(googleCertsUrl));

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
