using System.Linq;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var _password = Encoding.UTF8.GetBytes(password);
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(_password);
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var computedHash = hmac.ComputeHash(passwordBytes);

                if (computedHash.Where((t, i) => t != passwordHash[i]).Any())
                {
                    return false;
                }
            }
            return true;
        }
    }
}