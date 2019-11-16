using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDrinkOrderSystem.Models
{
    public class Jwt
    {
        public JwtHeader jwtHeader;
        public JwtPayload jwtPayload;
        public string jwtSignature;
    }

    public class JwtHeader
    {
        public string alg;
        public string kid;
        public string typ;
    }

    public class JwtPayload
    {
        public string iss;
        public string azp;
        public string aud;
        public string sub;
        public string email;
        public bool email_verified;
        public string at_hash;
        public string name;
        public string picture;
        public string given_name;
        public string family_name;
        public string locale;
        public string iat;
        public string exp;
        public string jti;
    }

    public class GoogleCerts
    {
        public List<JwtCert> keys;
    }

    public class JwtCert
    {
        public string alg;
        public string n;
        public string use;
        public string kid;
        public string e;
        public string kty;
    }
}
