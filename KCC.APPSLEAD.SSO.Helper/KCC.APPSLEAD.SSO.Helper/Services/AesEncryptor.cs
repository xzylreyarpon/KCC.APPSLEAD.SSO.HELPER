using System;
using System.Security.Cryptography;
using System.Text;

namespace KCC.APPSLEAD.SSO.Helper.Services
{
    public static class AesEncryptor
    {
        public static string Encrypt(string plainText, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var encryptor = aes.CreateEncryptor();
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                byte[] enc = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                return Convert.ToBase64String(enc);
            }
        }
    }
}
