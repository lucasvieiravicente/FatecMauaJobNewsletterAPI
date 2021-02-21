using System.Security.Cryptography;
using System.Text;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class HashUtil
    {
        public static byte[] HashPassword(string password)
        {
            byte[] encodedPassword = Encoding.UTF8.GetBytes(password);
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(encodedPassword);
            return sha1data;
        }
    }
}
