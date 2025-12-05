using KCC.APPSLEAD.SSO.Helper.Core;
using KCC.APPSLEAD.SSO.Helper.Models;
using Newtonsoft.Json;
using System;

namespace KCC.APPSLEAD.SSO.Helper.Services
{
    public static class TokenDecoder
    {
        public static TokenModel Decode(string encryptedToken)
        {
            if (string.IsNullOrWhiteSpace(encryptedToken))
                throw new Exception("Empty token");

            string base64 = encryptedToken.Replace("-", "+").Replace("_", "/");

            // Fix padding for .NET 4.5
            while (base64.Length % 4 != 0)
                base64 += "=";

            string json = AesDecryptor.Decrypt(
                base64,
                SSOConfig.EncryptionKey,
                SSOConfig.EncryptionIV
            );

            return JsonConvert.DeserializeObject<TokenModel>(json);
        }
    }
}
