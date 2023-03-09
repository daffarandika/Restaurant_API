using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Utils
{
    public class Helper
    {
        public static string Hash(string input)
        {
            using (var hasher = SHA256.Create())
            {
                byte[] res = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder(); 
                foreach (byte b in res) 
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
