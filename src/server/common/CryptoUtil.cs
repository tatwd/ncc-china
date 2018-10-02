using System;

namespace Ncc.China.Common
{
    public class CryptoUtil
    {
        public static string CreateSalt(int size)
        {
            using(var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var buffer = new byte[size];
                rng.GetBytes(buffer);
                return System.Convert.ToBase64String(buffer);
            }
        }

        public static string Encrypt(string password, string salt)
        {
            using (var sha256Managed = new System.Security.Cryptography.SHA256Managed())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes($"{password}{salt}");
                var hashing = sha256Managed.ComputeHash(bytes);
                return  ByteArrayToString(hashing);
            }
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            var result = new System.Text.StringBuilder();
            foreach (var number in bytes)
            {
                result.Append(Hexadecimalize(number, false, false));
            }
            return result.ToString();
        }

        public static string Hexadecimalize(int number, bool hex = true, bool isUpper = true)
        {
            var result = new System.Text.StringBuilder();
            if (hex)
            {
                result.AppendFormat("0X{0:X}", number);
            }
            else
            {
                result.AppendFormat("{0:X}", number);
            }
            if (!isUpper)
            {
                return result.ToString().ToLowerInvariant();
            }
            return result.ToString();
        }
    }
}
