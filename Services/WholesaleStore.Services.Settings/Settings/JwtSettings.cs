using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholesaleStore.Services.Settings.Settings
{
    public class JwtSettings
    {
        public string SignatureAccess { get; set; }
        public string SignatureRefresh { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenAge { get; set; }
        public string RefreshTokenAge { get; set; }
    }
}
