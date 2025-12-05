using System;
using System.Security.Cryptography;
using System.Text;

namespace KCC.APPSLEAD.SSO.Helper.Services
{
    public static class AesDecryptor
    {
        public static string Decrypt(string cipherText, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var decryptor = aes.CreateDecryptor();
                byte[] bytes = Convert.FromBase64String(cipherText);
                byte[] dec = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                return Encoding.UTF8.GetString(dec);
            }
        }
    }
}
