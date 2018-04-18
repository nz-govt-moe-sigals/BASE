using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Services.Implementations.Configuration
{
    public class ExtractDocumentDbServiceConfiguration
    {
        public Uri EndpointUrl { get; set; }

        public string AuthorizationKey{ get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
       
    }
}
