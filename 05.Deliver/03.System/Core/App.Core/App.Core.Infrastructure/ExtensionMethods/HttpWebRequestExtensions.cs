using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.ExtensionMethods
{
    public static class HttpWebRequestExtensions
    {

        public static void AttachBearerToken(this HttpWebRequest httpWebRequest, string bearerToken)
        {
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + bearerToken);
        }

    }
}
