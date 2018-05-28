using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{

    public class RestResponseHandler {
        public int ResponseCode { get; set; }
        public Action<string> Handler { get; set; }
        public RestResponseHandler() { }
        public RestResponseHandler(int responseCode, Action<string> responseHandler) { ResponseCode = responseCode; Handler = responseHandler; }
    }

    public class RestService : AppCoreServiceBase, IRestService
    {
        private readonly IJsonService _jsonService;

        public RestService(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public string Get(Uri uri, String bearerToken=null, params RestResponseHandler[] alternateResponseHandlers)
        {
            var httpWebRequest = CreateHttpWebRequest("GET", uri, bearerToken);

            string result=null;

            List<RestResponseHandler> handlers = new List<RestResponseHandler>();
            handlers.Add(new RestResponseHandler(200, (x) => { result = x; }));
            if (alternateResponseHandlers != null) { handlers.AddRange(alternateResponseHandlers); }


            HandleResponse(httpWebRequest, handlers);

            return result;
        }

        public T Get<T>(Uri uri, string bearerToken = null, params RestResponseHandler[] alternateResponseHandlers)
            where T:class
        {
            var httpWebRequest = CreateHttpWebRequest("GET", uri, bearerToken);

            T result = null;
            List<RestResponseHandler> handlers = new List<RestResponseHandler>();
            handlers.Add(new RestResponseHandler(200, (x) =>  _jsonService.Parse<T>(x)));
            if (alternateResponseHandlers != null) { handlers.AddRange(alternateResponseHandlers); }

            HandleResponse(httpWebRequest, handlers);

            return result;
        }

        public void Put(Uri uri, string body, String bearerToken = null, params RestResponseHandler[] alternateResponseHandlers)
        {
            var httpWebRequest = CreateHttpWebRequest("PUT", uri, bearerToken);
            WriteRequestBody(body, httpWebRequest);

            string result = null;
            List<RestResponseHandler> handlers = new List<RestResponseHandler>();
            handlers.Add(new RestResponseHandler(200, (x) => result = x));
            if (alternateResponseHandlers != null) { handlers.AddRange(alternateResponseHandlers); }
            HandleResponse(httpWebRequest, handlers);
        }



        public void Post(Uri uri, string body, String bearerToken = null, params RestResponseHandler[] alternateResponseHandlers)
        {
            var httpWebRequest = CreateHttpWebRequest("PUT", uri, bearerToken);

            string result = null;
            List<RestResponseHandler> handlers = new List<RestResponseHandler>();
            handlers.Add(new RestResponseHandler(200, (x) => result = x));
            if (alternateResponseHandlers != null) { handlers.AddRange(alternateResponseHandlers); }
            HandleResponse(httpWebRequest, handlers);
        }



        private static HttpWebRequest CreateHttpWebRequest(string verb, Uri uri, string bearerToken = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            AttachBearerToken(httpWebRequest, bearerToken);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = verb;

            return httpWebRequest;
        }

        private static void AttachBearerToken(HttpWebRequest httpWebRequest, string bearerToken)
        {
            if (!string.IsNullOrWhiteSpace(bearerToken))
            {
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + bearerToken);
            }
        }

        private static void WriteRequestBody(string body, HttpWebRequest httpWebRequest)
        {
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(body);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }
        }

        private static HttpWebResponse GetResponse(HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpResponse = null;
            httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse;
        }

        private static string GetStringResponse(HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpResponse = GetResponse(httpWebRequest);

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }
        }

            private static void HandleResponse(HttpWebRequest httpWebRequest, IEnumerable<RestResponseHandler> alternateResponseHandlers)
        {
            HttpWebResponse httpResponse = GetResponse(httpWebRequest);

            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }


            if (alternateResponseHandlers!= null)
            {
                var handler = alternateResponseHandlers.FirstOrDefault(x => x.ResponseCode == (int)httpResponse.StatusCode);
                if (handler != null)
                {
                    handler.Handler.Invoke(result);
                    return;
                }
            }


        }

    }
}
