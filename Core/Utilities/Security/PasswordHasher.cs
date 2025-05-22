using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            using (var md5 = MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

    }
}
