namespace App.Core.Application
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Web;
    using System.Web.Caching;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //RoleEnvironment.Changed += RoleEnvironment_Changed;
            
            //Must be the very first thing the application does because ServicePointManager will initialize only once. 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // SETUP STEP: Move Everything to begining of Startup:Configuration method.
            // See https://stackoverflow.com/questions/20168978/do-i-need-a-global-asax-cs-file-at-all-if-im-using-an-owin-startup-cs-class-and
        }


        protected void Application_BeginRequest()
        {
            // As RAMMFAR=true, this will be invoked for 
            // all MVC, WebAPI and Static file requests.
            // This is the older,pre-OWIN place
            // to log the requests made.
            // For further info regarding the IIS based request lifecycle:
            // http://blog.thedigitalgroup.com/chetanv/2015/06/30/a-detailed-walkthrough-of-asp-net-mvc-request-life-cycle/

            // Throttle -- if needed -- even before ensuring the request came over SSL:
            RequestThrottler.ThrottleRequests(this);
            EnsureUsingTransportLayerSecurity();
        }

        protected void Application_LogRequest()
        {
            // As RAMMFAR=true, this will be invoked for 
            // all MVC, WebAPI and Static file requests.
            // This is the older,pre-OWIN place
            // to log the requests made.
            // For further info regarding the IIS based request lifecycle:
            // http://blog.thedigitalgroup.com/chetanv/2015/06/30/a-detailed-walkthrough-of-asp-net-mvc-request-life-cycle/
        }

        protected void Application_EndRequest()
        {
            // As RAMMFAR=true, this will be invoked for 
            // all MVC, WebAPI and Static file requests.
            // This is the older,pre-OWIN place
            // to commit db record changes.
            // For further info regarding the IIS based request lifecycle:
            // http://blog.thedigitalgroup.com/chetanv/2015/06/30/a-detailed-walkthrough-of-asp-net-mvc-request-life-cycle/
        }


        private void EnsureUsingTransportLayerSecurity()
        {
            if (!this.Context.Request.IsSecureConnection)
            {
                this.Response.Clear();
                var portNumber = this.Context.Request.Url.Port.ToString();
                var newUrl = this.Context.Request.Url.ToString().Insert(4, "s");
                if (true)
                {
                    //Edge case: Handle redirection in IIS Express -- assuming 
                    // using well known dev prefixes and they are aligned
                    // such as 60011 and https port is 43311:
                    if (portNumber.Length == 5 && portNumber.StartsWith("600"))
                    {
                        var devPortNumber = portNumber.Replace("600", "443");
                        newUrl = newUrl.Replace(portNumber, devPortNumber);
                    }
                }
                // But this causes havoc to Dev Browsers requyiring cache clearing: "301 Moved Permanently"
                // (see https://stackoverflow.com/questions/9130422/how-long-do-browsers-cache-http-301s)
                // Compromise between performance and dev requirements is to use 
                // "307 Temporary Redirect" or "302 Found" -- and 
                // "307 Temporary Redirect" is slightly more accurate/current.
                this.Response.Status = "301 Moved Permanently";
                this.Response.AddHeader("Cache-Control", "no-cache");
                this.Response.AddHeader("Location", newUrl);
                this.Response.End();
            }
        }

        protected void Application_PreSendRequestHeaders()
        {
            this.Response.Headers.Set("Server", ""); //cannot remove
            this.Response.Headers.Remove("X-AspNet-Version");
            this.Response.Headers.Remove("X-AspNetMvc-Version");
        }
    }

    internal static class RequestThrottler
    {
        /// <summary>
        ///     Some Urls (eg: Static 'static/images/person.png') may be allowed to be
        ///     requested up to 20 times before throttling kicks in.
        /// </summary>
        private static readonly Dictionary<string, int> _knownUrlMaxAllowed = new Dictionary<string, int>();

        public static void ThrottleRequests(HttpApplication httpApplication)
        {
            var context = httpApplication.Context;
            // IMPORTANT: 
            // Only MVC and WebAPI requests will go through this (not static file requests)
            // until configuration/system.webServer/modules@runAllManagedModulesForAllRequests="true"

            var url = httpApplication.Context.Request.RawUrl.ToLower();

            // The default MaxAllowed /Interval is not a lot (eg: 4) but 
            // if maybe some files (eg: 'static/images/default.png') may have a higher
            // count (eg: 20)
            var m = 4;
            var maxCount = _knownUrlMaxAllowed.ContainsKey(url) ? _knownUrlMaxAllowed[url] : m;
            if (maxCount < 0)
            {
                maxCount = m;
            }
            // The duration over which to check is:
            var delay = TimeSpan.FromMilliseconds(1000);

            var cacheKey = string.Concat(
                context.Request.HttpMethod,
                " " +
                context.Request.RemoteIPChain() /*use our extension method*/,
                ": ",
                url);
            // Find existing or start a new counter and increment it:
            var counter = ((int?) HttpRuntime.Cache[cacheKey] ?? 0) + 1;
            // Cache it
            HttpRuntime.Cache.Insert(cacheKey,
                counter, // is this the smallest data we can have?
                null, // no dependencies
                DateTime.Now.Add(delay), // absolute expiration
                Cache.NoSlidingExpiration,
                CacheItemPriority.Low,
                null); // no callback

            // If still hit our 4 (or 20), we're ok:
            if (counter <= maxCount)
            {
                return;
            }
            // Or not, in which case we throttle:
            context.Response.Clear();
            // See: https://tools.ietf.org/html/rfc6585
            context.Response.Status = "409 Conflict";
            context.Response.AddHeader("Retry-After", delay.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            context.Response.AddHeader("Cache-Control", "no-cache");
            //Do not use Response.End or Response.Close ( https://stackoverflow.com/a/3917180/8354791 )
            // Sends the response buffer
            context.Response.Write("DoS Interception enabled.");
            //Response.Flush();
            // Prevents any other content from being sent to the browser
            context.Response.SuppressContent = true;

            httpApplication.CompleteRequest();
        }
    }
}