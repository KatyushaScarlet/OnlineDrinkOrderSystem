using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Jwt
    {
        public JwtHeader jwtHeader{ get; set; }
        public JwtPayload jwtPayload{ get; set; }
        public string jwtSignature{ get; set; }
    }

    public class JwtHeader
    {
        public string alg{ get; set; }
        public string kid{ get; set; }
        public string typ{ get; set; }
    }

    public class JwtPayload
    {
        public string iss{ get; set; }
        public string azp{ get; set; }
        public string aud{ get; set; }
        public string sub{ get; set; }
        public string email{ get; set; }
        public bool email_verified{ get; set; }
        public string at_hash{ get; set; }
        public string name{ get; set; }
        public string picture{ get; set; }
        public string given_name{ get; set; }
        public string family_name{ get; set; }
        public string locale{ get; set; }
        public string iat{ get; set; }
        public string exp{ get; set; }
        public string jti{ get; set; }
    }

    public class GoogleCerts
    {
        public List<JwtCert> keys{ get; set; }
    }

    public class JwtCert
    {
        public string alg{ get; set; }
        public string n{ get; set; }
        public string use{ get; set; }
        public string kid{ get; set; }
        public string e{ get; set; }
        public string kty{ get; set; }
    }
}
