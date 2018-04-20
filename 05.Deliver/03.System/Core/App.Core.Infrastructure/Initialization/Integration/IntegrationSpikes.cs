using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.Integration
{
    using App.Core.Infrastructure.Services;

    public class IntegrationSpikes : IHasAppCoreInitializer
    {
        private readonly IAzureStorageAccountMedia1Service _media1Service;

        public IntegrationSpikes(IAzureStorageAccountMedia1Service media1Service)
        {
            this._media1Service = media1Service;
        }


        public void Initialize()
        {
            var containerName = "pubTest";
            var fileName = "foo.txt";

            this._media1Service.UploadAText(containerName,fileName,"bar",true);

            this._media1Service.DownloadAText(containerName, fileName);
        }

    }
}
