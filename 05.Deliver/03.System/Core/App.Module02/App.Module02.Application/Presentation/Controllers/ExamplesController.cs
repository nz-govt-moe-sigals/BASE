////using Microsoft.Identity.Client;

////TODO: Get rid of direct reference to App.Module02.Shared

//namespace App.Module02.Application.Presentation.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Net;
//    using System.Net.Http;
//    using System.Threading.Tasks;
//    using System.Web.Mvc;
//    using App.Core.Infrastructure.IDA.Models;
//    using App.Core.Infrastructure.IDA.Services;
//    using App.Core.Infrastructure.Services;
//    using App.Core.Shared.Models.Messages;
//    using App.Module02.Shared.Configuration.Models;
//    using App.Module02.Shared.Models.Entities;
//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Linq;

//    // This is the MVC Controller -- not the API Controller that it invokes...
//    // Note that his is *Example(s)* (plural), calling an API that is *Example* single.
//    [Authorize]
//    public class ExamplesController : Controller
//    {
//        private const string _redirectUrl = "/Examples";
//        private static int _exampleNumber = 3;
//        private readonly ExampleApiConfiguration _apiConsumerConfiguration;
//        private readonly string _apiEndpoint;
//        private readonly IB2COidcConfidentialClientConfiguration _b2cOidcConfidentialClientConfiguration;
//        private readonly IOIDCAPIClientService _oidcApiClientService;

//        //private IOIDCConfidentialClientConfiguration confidentialClientConfiguration = null;

//        // Constructor
//        public ExamplesController(IHostSettingsService hostSettingsService, IOIDCAPIClientService oidcApiClientService)
//        {
//            _exampleNumber = hostSettingsService.Get("demo:ExampleApiSample", 1);

//            this._oidcApiClientService = oidcApiClientService;
//            // Get configuration (via Host Settings) specific to Consumers:
//            this._b2cOidcConfidentialClientConfiguration =
//                hostSettingsService.GetObject<B2COidcConfidentialClientConfiguration>("cookieAuth:");

//            // Retrieve consumer settings for the client/consumer of the API, that describe the remote API
//            // Service (Urls and scopes)

//            // This class needs the Api Configuration, primarily using only the following from it:
//            // * the Scopes (ServiceIdentifier + Scope suffix --- Same as for the the Startup helper class, really)
//            this._apiConsumerConfiguration = hostSettingsService.GetObject<ExampleApiConfiguration>("cookieAuth:");
//            // The actual service endpoint to invoke will be a little update of the above:
//            this._apiEndpoint = this._apiConsumerConfiguration.ServiceUrl + $"api/example{_exampleNumber}/";
//        }

//        // GET: Makes a call to the API and retrieves the list of tasks
//        public async Task<ActionResult> Index()
//        {
//            try
//            {
//                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
//                    this._apiEndpoint + "?$filter=contains(PublicText,'g')&$top=3");

//                var httpResponseMessage =
//                    await ExecuteRequest(httpRequestMessage, this._apiConsumerConfiguration.FQExampleReadScope);

//                // Handle the response
//                switch (httpResponseMessage.StatusCode)
//                {
//                    case HttpStatusCode.OK:
//                        var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

//                        var parsingOData = _exampleNumber >= 5;

//                        if (parsingOData)
//                        {
//                            // The result will look like:
//                            // {
//                            //   "@odata.context":"https://localhost:44311/api/$metadata#example5",
//                            //   "value":[{"Id":"4b77d915-d2e7-9565-2999-39e11664c25b","PublicText":"g","SensitiveText":null},{"Id":"bf0a3c19-b8e0-2805-8fff-39e11664cb91","PublicText":"h","SensitiveText":null},{"Id":"c5759e28-a019-a663-c168-39e118f96829","PublicText":"f","SensitiveText":null},{"Id":"dfcd87ae-9c04-294f-676f-39e1190a92ef","PublicText":"fasd","SensitiveText":null}]
//                            // }
//                            var tmp =
//                                JsonConvert.DeserializeObject<ODataResponse<dynamic>>(responseString);
//                            this.ViewBag.Items = tmp.Value;
//                        }
//                        else
//                        {
//                            var items = JArray.Parse(responseString);
//                            this.ViewBag.Items = items;
//                        }
//                        return View("Index");
//                    default:
//                        var responseString2 = await httpResponseMessage.Content.ReadAsStringAsync();
//                        return await DefaultProcessResponse(httpResponseMessage);
//                }
//            }
//            catch (Exception ex)
//            {
//                return ErrorAction("Error reading to do list: " + ex.Message);
//            }
//        }


//        // POST: Makes a call to the API to store a new task
//        [HttpPost]
//        public async Task<ActionResult> Create(Example example)
//            //public async Task<ActionResult> Create(string publicText)
//        {
//            try
//            {
//                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, this._apiEndpoint);
//                //httpRequestMessage.Content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("Text", publicText) });
//                httpRequestMessage.Content = new FormUrlEncodedContent(new[]
//                    {new KeyValuePair<string, string>("PublicText", example.PublicText)});

//                var httpResponseMessage =
//                    await ExecuteRequest(
//                        httpRequestMessage, this._apiConsumerConfiguration.FQExampleWriteScope);

//                // Handle the response
//                switch (httpResponseMessage.StatusCode)
//                {
//                    case HttpStatusCode.OK:
//                    case HttpStatusCode.NoContent:
//                    case HttpStatusCode.Created:
//                        return new RedirectResult(_redirectUrl);
//                    default:
//                        var responseString2 = await httpResponseMessage.Content.ReadAsStringAsync();
//                        return await DefaultProcessResponse(httpResponseMessage);
//                }
//            }
//            catch (Exception ex)
//            {
//                return ErrorAction("Error writing to list: " + ex.Message);
//            }
//        }

//        // DELETE: Makes a call to the API to delete an existing task
//        [HttpPost]
//        public async Task<ActionResult> Delete(string id)
//        {
//            try
//            {
//                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, this._apiEndpoint + id);

//                var httpResponseMessage =
//                    await ExecuteRequest(
//                        httpRequestMessage, this._apiConsumerConfiguration.FQExampleWriteScope);

//                // Handle the response
//                switch (httpResponseMessage.StatusCode)
//                {
//                    case HttpStatusCode.OK:
//                    case HttpStatusCode.NoContent:
//                        return new RedirectResult(_redirectUrl);
//                    default:
//                        var responseString2 = await httpResponseMessage.Content.ReadAsStringAsync();
//                        return await DefaultProcessResponse(httpResponseMessage);
//                }
//            }
//            catch (Exception ex)
//            {
//                return ErrorAction("Error deleting from list: " + ex.Message);
//            }
//        }

//        private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage httpRequestMessage,
//            params string[] fqScopes)
//        {
//            var response =
//                await this._oidcApiClientService.MakeRequestAsync(this._b2cOidcConfidentialClientConfiguration,
//                    this._b2cOidcConfidentialClientConfiguration.AuthorityCookieConfigurationPolicyUri,
//                    this.HttpContext,
//                    fqScopes,
//                    httpRequestMessage
//                );
//            return response;
//        }

//        private async Task<ActionResult> DefaultProcessResponse(HttpResponseMessage httpResponseMessage)
//        {
//            // Handle the response
//            var responseString2 = await httpResponseMessage.Content.ReadAsStringAsync();
//            switch (httpResponseMessage.StatusCode)
//            {
//                case HttpStatusCode.Unauthorized:
//                    return ErrorAction("Please sign in again. " + httpResponseMessage.ReasonPhrase);
//                default:
//                    return ErrorAction("Error. Status code = " + httpResponseMessage.StatusCode);
//            }
//        }

//        private ActionResult ErrorAction(string message)
//        {
//            return new RedirectResult("/Error?message=" + message);
//        }
//    }
//}

