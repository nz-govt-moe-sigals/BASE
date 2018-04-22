namespace App.Core.Infrastructure.Integration.Azure.Storage
{
    using Microsoft.WindowsAzure.Storage.Queue;

    public interface IAzureStorageQueueContext
    {
        CloudQueueClient Client
        {
            get;
        }

    }
}