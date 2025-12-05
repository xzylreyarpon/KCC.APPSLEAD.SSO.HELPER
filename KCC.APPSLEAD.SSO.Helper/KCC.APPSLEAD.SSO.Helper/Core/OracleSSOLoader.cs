using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace KCC.APPSLEAD.SSO.Helper.Core
{
    internal static class OracleSSOLoader
    {
        private static string ConnString =>
            ConfigurationManager.ConnectionStrings["SSO_DB"]?.ConnectionString;

        public static string Load(string key)
        {
            if (string.IsNullOrWhiteSpace(ConnString))
                return "";

            try
            {
                using (var conn = new OracleConnection(ConnString))
                {
                    conn.Open();

                    using (var cmd = new OracleCommand(
                        "SELECT CONFIG_VALUE FROM KCC_SSO_CONFIG WHERE CONFIG_KEY = :p",
                        conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("p", key));
                        return (cmd.ExecuteScalar() ?? "").ToString();
                    }
                }
            }
            catch
            {
                return ""; // fallback safe
            }
        }
    }
}
