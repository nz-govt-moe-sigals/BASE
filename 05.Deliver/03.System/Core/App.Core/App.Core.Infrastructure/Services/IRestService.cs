using App.Core.Infrastructure.Services.Implementations;
using System;


namespace App.Core.Infrastructure.Services
{
    public interface IRestService
    {
        string Get(Uri uri, String bearerToken=null, params RestResponseHandler[] alternateResponseHandlers);
        T Get<T>(Uri uri, string bearerToken = null, params RestResponseHandler[] alternateResponseHandlers) where T : class;
        void Post(Uri uri,string body, String bearerToken = null, params RestResponseHandler[] alternateResponseHandlers);
        void Put(Uri uri, string body, String bearerToken = null, params RestResponseHandler[] alternateResponseHandlers);
    }
}
