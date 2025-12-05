using KCC.APPSLEAD.SSO.Helper.Models;
using KCC.APPSLEAD.SSO.Helper.Services;
using System;

namespace KCC.APPSLEAD.SSO.Helper.Core
{
    public static class SSOHelper
    {
        public static SSOResult TryAutoLogin(string encrypted)
        {
            try
            {
                TokenModel token = TokenDecoder.Decode(encrypted);

                long now = TimeUtil.NowUnix();
                long diff = now - token.Timestamp;

                if (diff > SSOConfig.TokenExpirySeconds)
                {
                    return new SSOResult
                    {
                        Success = false,
                        Message = "Expired token"
                    };
                }

                return new SSOResult
                {
                    Success = true,
                    Token = token,
                    Message = "OK"
                };
            }
            catch
            {
                return new SSOResult
                {
                    Success = false,
                    Message = "Invalid or corrupted token"
                };
            }
        }
    }
}
