using KCC.APPSLEAD.SSO.Helper.Core;
using KCC.APPSLEAD.SSO.Helper.Models;
using Newtonsoft.Json;
using System;

namespace KCC.APPSLEAD.SSO.Helper.Services
{
    public static class TokenEncoder
    {
        public static string Encode(string username, string password)
        {
            var token = new TokenModel
            {
                Username = username,
                Password = password,
                Timestamp = TimeUtil.NowUnix()
            };

            string json = JsonConvert.SerializeObject(token);

            string encrypted = AesEncryptor.Encrypt(
                json,
                SSOConfig.EncryptionKey,
                SSOConfig.EncryptionIV
            );

            return encrypted.Replace("+", "-")
                            .Replace("/", "_")
                            .TrimEnd('=');
        }
    }
}
