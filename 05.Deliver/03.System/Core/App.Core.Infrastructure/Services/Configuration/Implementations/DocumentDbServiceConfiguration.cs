using System;


namespace App.Core.Infrastructure.Services.Configuration.Implementations
{
    public class DocumentDbServiceConfiguration
    {
        public Uri EndpointUrl
        {
            get; set;
        }
        public string AuthorizationKey
        {
            get; set;
        }

        public int TimeoutMilliseconds
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDbServiceConfiguration" /> class.
        /// </summary>
        public DocumentDbServiceConfiguration()
        {
            this.TimeoutMilliseconds = 10 * 1000;
        }
    }
}
