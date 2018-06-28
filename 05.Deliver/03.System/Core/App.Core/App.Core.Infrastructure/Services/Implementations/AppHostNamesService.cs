using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class AppHostNamesService : IAppHostNamesService
    {

        public string GetAppHostNames()
        {
            return Environment.GetEnvironmentVariable("websiteUrl");
        }

    }
}
