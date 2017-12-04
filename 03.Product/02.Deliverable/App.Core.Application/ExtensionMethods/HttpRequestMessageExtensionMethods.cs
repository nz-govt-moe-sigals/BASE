// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public static class HttpRequestMessageExtensionMethods
    {
        public static string RemoteIPChain(this HttpRequestMessage request)
        {
            // Retrieving the IP of the remote User Agent is not as simple as picking up "REMOTE_AGENT"
            // as it is complicated by Proxies (Load Balancers and Firewalls) in the middle (F5 et all).
            // It almost becomes more art than science.

            // The official (since 2004) way to determine source is the "Forwarded" header.
            // https://tools.ietf.org/html/rfc7239
            // But the defacto way that became common place before the above was defined was to
            // use (https://en.wikipedia.org/wiki/X-Forwarded-For) with a comma+space separated list of 
            // ips of clients and upstream proxies: eg "X-Forwarded-For": client, proxy1, proxy2
            // Note that the above does not have the current proxy in it, so you really a cleaned up version of:
            // "X-Forwarded-For" + ", " + "REMOTE_ADDR"
            // Unfortunately, because it was always a "defacto" convention, people have used other tags. Depending
            // on the quality of people who set up your proxies...what you see instead may be different.

#if DEBUG
            var check = request.Headers.Host;
            var check2 = request.Headers.UserAgent;
#endif
            IEnumerable<string> tlist;
            var key = request.Headers.TryGetValues("X-Forwarded-For", out tlist)
                ? tlist.FirstOrDefault()
                : string.Empty;
            var remoteAddr = request.Headers.TryGetValues("REMOTE_ADDR", out tlist)
                ? tlist.FirstOrDefault()
                : string.Empty;

            if (!string.IsNullOrEmpty(remoteAddr))
            {
                if (remoteAddr == "::1")
                {
                    //Just easier to comprehend:
                    remoteAddr = "127.0.0.1";
                }
                if (!string.IsNullOrEmpty(key))
                {
                    key = string.Concat(key, ", ");
                }
                key = string.Concat(key, remoteAddr);
            }
            //handle IP6 case abberations:
            return key.ToLower();
        }
    }
}