namespace KCC.APPSLEAD.SSO.Helper.Models
{
    public class SSOResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TokenModel Token { get; set; }
    }
}
