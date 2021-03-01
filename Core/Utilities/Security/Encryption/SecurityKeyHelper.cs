using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            var securityKeyBytes = Encoding.UTF8.GetBytes(securityKey);
            return new SymmetricSecurityKey(securityKeyBytes);
        }
    }
}