using System;

namespace KCC.APPSLEAD.SSO.Helper.Core
{
    internal static class TimeUtil
    {
        public static long NowUnix()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
