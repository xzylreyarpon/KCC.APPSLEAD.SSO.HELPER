using System.Configuration;

namespace KCC.APPSLEAD.SSO.Helper.Core
{
    public static class SSOConfig
    {
        public static string EncryptionKey
        {
            get
            {
                // 1) Prefer Oracle DB
                string key = OracleSSOLoader.Load("SSO_KEY");
                if (!string.IsNullOrWhiteSpace(key))
                    return key;

                // 2) Fallback to Web.config if DB is empty
                return ConfigurationManager.AppSettings["SSO:Key"] ?? "";
            }
        }

        public static string EncryptionIV
        {
            get
            {
                string iv = OracleSSOLoader.Load("SSO_IV");
                if (!string.IsNullOrWhiteSpace(iv))
                    return iv;

                return ConfigurationManager.AppSettings["SSO:IV"] ?? "";
            }
        }

        public static int TokenExpirySeconds
        {
            get
            {
                // 1) From DB
                string dbExp = OracleSSOLoader.Load("TOKEN_EXPIRY");
                if (int.TryParse(dbExp, out int exp))
                    return exp;

                // 2) From config
                if (int.TryParse(ConfigurationManager.AppSettings["SSO_TokenExpirySeconds"], out int cfgExp))
                    return cfgExp;

                return 300;
            }
        }
    }
}
