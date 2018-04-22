//namespace App.Core.Infrastructure.Integration.Azure.Storage
//{
//    using System;
//    using System.Collections.Generic;
//    using App.Core.Shared.Attributes;
//    using Microsoft.WindowsAzure.Storage.Blob;
//    using Microsoft.WindowsAzure.Storage.Queue;

//    [Key(Constants.Storage.StorageAccountNames.Default)]
//    public class AppCoreAzureStorageDefaultQueueContext : IAzureStorageQueueContext
//    {
//        private readonly string ConnectionString;

//        private static object _lock = new Object();
//        private static Dictionary<string, CloudBlobContainer> ContainersCache = new Dictionary<string, CloudBlobContainer>();
//        private static bool ContainersInitialized;


//        public CloudQueueClient Client
//        {
//            get
//            {
//                return this._client ?? (this._client = Initialize());
//            }
//        }
//        private CloudBlobClient _client;

//    }
//}