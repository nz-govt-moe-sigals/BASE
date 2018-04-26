using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Constants.Storage
{
    using App.Core.Infrastructure.Integration.Azure.Storage;

    /// <summary>
    /// Names of QueueStorage Containers,
    /// usually within the default StorageAccount
    /// (see <see cref="StorageAccountNames"/>).
    /// <para>
    /// These known Containers are automatically 
    /// created the first time 
    /// <see cref="AppCoreAzureStorageDefaultQueueContext"/>
    /// is invoked.  
    /// </para>
    /// </summary>
    public class QueueStorageContainers
    {
    }


    /// <summary>
    /// Names of BlobStorage Containers,
    /// usually within the default StorageAccount
    /// (see <see cref="StorageAccountNames"/>).
    /// <para>
    /// These known Containers are automatically 
    /// created the first time 
    /// <see cref="AppCoreAzureStorageDefaultBlobContext"/>
    /// is invoked.  
    /// </para>
    /// </summary>
    public static class BlobStorageContainers
    {

        public static string Testing = "testing";
        /// <summary>
        /// Publicly accessible (Blob, not Container) storage.
        /// <para>
        /// Container names become parts of case sensitive urls.
        /// So make them lowercase.
        /// </para>
        /// <para>
        /// This Container is accessed via the 
        /// <see cref="StorageAccountNames.Default"/>
        /// service account.
        /// </para>
        /// </summary>
        public static string Public = "public";

        /// <summary>
        /// AAD RBAC controlled access Container.
        /// <para>
        /// ie, whereas the 'public' blob can be accessed directly from the web
        /// this blob can only be accessed by the System.
        /// </para>
        /// <para>
        /// Container names become parts of case sensitive urls.
        /// So make them lowercase.
        /// </para>
        /// <para>
        /// This Container is accessed via the 
        /// <see cref="StorageAccountNames.Default"/>
        /// service account.
        /// </para>
        /// </summary>
        public static string Private = "private";
    }
}
