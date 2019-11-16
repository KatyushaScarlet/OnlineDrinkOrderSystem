using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Common
{
    public class AppSettings
    {
        public class GoogleOauthSetting
        {
            public string GoogleAppId { get; set; }
            public string GoogleIss { get; set; }
            public string GoogleCertUrl { get; set; }
        }

        public class ConnectionString
        {
            public string Server { get; set; }
            public string Database { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
    }
}
