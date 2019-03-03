using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Constants.IDA;

namespace App
{
    public static class ClaimsIdentityExtensions
    {
        public static string GetIdp(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.IdpIdentifierId)?.Value;
        }

        public static string GetSub(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.SubjectIdentifierId)?.Value;
        }

        public static string GetIat(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.IssuedAtId)?.Value;
        }

        public static DateTime GetIssuedAtTime(this ClaimsIdentity identity)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(Convert.ToUInt64(GetIat(identity)));
        }

        public static string GetExp(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == TokenTitles.ExpiryId)?.Value;
        }

        public static DateTime GetExpiry(this ClaimsIdentity identity)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(Convert.ToUInt64(GetExp(identity)));
        }

        public static TimeSpan GetDurationToLive(this ClaimsIdentity identity)
        {
            return GetExpiry(identity) - GetIssuedAtTime(identity);
        }


        public static string GetSessionUniqueIdentifier(this ClaimsIdentity identity)
        {
            return identity.Claims.FirstOrDefault(x => x.Type == ClaimTitles.UniqueSessionIdentifier)?.Value;
        }
    }
}
