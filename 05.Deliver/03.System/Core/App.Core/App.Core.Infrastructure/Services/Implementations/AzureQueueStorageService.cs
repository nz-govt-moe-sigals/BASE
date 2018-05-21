using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Integration.Azure.Storage;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Queue;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IAzureQueueStorageService" />
    ///     Infrastructure Service Contract
    /// </summary>   
    public class AzureQueueStorageService : IAzureQueueStorageService
    {

        /// <summary>
        /// Use Service Locator to return specified context.
        /// </summary>
        /// <param name="storageAccountContextKey">The storage account context key.</param>
        /// <returns></returns>
        private IAzureStorageQueueContext GetStorageAccountContext(string storageAccountContextKey)
        {

            // If no name given, fall back to the default one:
            if (string.IsNullOrWhiteSpace(storageAccountContextKey))
            {
                storageAccountContextKey = Constants.Storage.StorageAccountNames.Default;
            }

            var result = AppDependencyLocator.Current.GetInstance<IAzureStorageQueueContext>(storageAccountContextKey);

            return result;

        }

        // Src: http://gauravmantri.com/2012/11/24/storage-client-library-2-0-migrating-queue-storage-code/



        private void foo()
        {
            //GetStorageAccountContext().Client.


            ////Create Queue

            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //queue.CreateIfNotExists();


            ////Delete Queue
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //queue.DeleteIfExists();

            ////List Queue
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //var queues = cloudQueueClient.ListQueues();

            ////Add Message
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //string messageContents = "This is a test message";
            //CloudQueueMessage message = new CloudQueueMessage(messageContents);
            //queue.AddMessage(message);

            ////Peek Messages
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //int numMessagesToFetch = 32;//Max messages which can be fetched at a time is 32
            //IEnumerable<CloudQueueMessage> messages = queue.PeekMessages(numMessagesToFetch);

            ////Peek Message
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //CloudQueueMessage message = queue.PeekMessage();

            ////Get Messages
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //int numMessagesToFetch = 32;//Max messages which can be fetched at a time is 32
            //TimeSpan visibilityTimeout = TimeSpan.FromSeconds(30);//Message will be invisible for 30 seconds.
            //IEnumerable<CloudQueueMessage> messages = queue.GetMessages(numMessagesToFetch, visibilityTimeout);

            ////Get Message
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //TimeSpan visibilityTimeout = TimeSpan.FromSeconds(30);//Message will be invisible for 30 seconds.
            //CloudQueueMessage message = queue.GetMessage(visibilityTimeout);

            ////Delete Message
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //CloudQueueMessage message = queue.GetMessage();
            //queue.DeleteMessage(message);
            ////Or you could use something like this
            ////queue.DeleteMessage(message.Id, message.PopReceipt);


            ////Get Approximate Message Count
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //queue.FetchAttributes();
            //int approximateMessagesCount = queue.ApproximateMessageCount.Value;


            ////Clear Queue
            //CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            //CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = cloudQueueClient.GetQueueReference(queueName);
            //queue.Clear();

        }



    }
}
