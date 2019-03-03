namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    ///     Decorates any WebAPI route that needs to have client requests limited by time.
    /// </summary>
    /// <remarks>
    ///     Uses the current System.Web.Caching.Cache to store each client request to the decorated route.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ThrottleWebApiActionFilterAttribute : ActionFilterAttribute
    {
        private string _message;


        public ThrottleWebApiActionFilterAttribute(string cacheKeyPrefix = null, TimeSpan duration = default(TimeSpan))
        {
            if (cacheKeyPrefix == null)
            {
                cacheKeyPrefix = string.Empty;
            }
            this.Name = cacheKeyPrefix;

            if (duration == default(TimeSpan))
            {
                duration = TimeSpan.FromSeconds(1);
            }
            this.Duration = duration;
        }


        /// <summary>
        ///     A optional unique Prefix for this throttle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The Duration clients must wait before executing this operation again (default is 1 second).
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        ///     A text message that will be sent to the client upon throttling.
        /// </summary>
        public string Message
        {
            get => this._message;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "Request throttled.";
                }
                this._message = value;
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionDescriptor.ActionName;

            var key = string.Concat(this.Name,
                RemoteIPChain(actionContext.Request.Headers),
                ": ",
                controllerName, "/",
                actionName);

   
            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    true, // is this the smallest data we can have?
                    null, // no dependencies
                    DateTime.Now.Add(this.Duration), // absolute expiration
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null); // no callback
            }
            else
            {
                actionContext.Response.Content =
                    new StringContent(this.Message.Replace("{n}", this.Duration.Seconds.ToString()));
                // see 409 - http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html
                actionContext.Response.StatusCode = HttpStatusCode.Conflict;
            }
        }

        private string RemoteIPChain(HttpRequestHeaders headers)
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

            IEnumerable<string> values = new List<string>();

            headers.TryGetValues("X-Forwarded-For", out values);
            var key = values != null ? values.FirstOrDefault() : null;
            if (key == null)
            {
                key = string.Empty;
            }

            headers.TryGetValues("REMOTE_ADDR", out values);
            var remoteAddr = values != null ? values.FirstOrDefault() : null;
            if (remoteAddr == null)
            {
                remoteAddr = string.Empty;
            }

            if (!string.IsNullOrEmpty(remoteAddr))
            {
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