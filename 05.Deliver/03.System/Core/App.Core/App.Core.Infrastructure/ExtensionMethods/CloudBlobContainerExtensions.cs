using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.ExtensionMethods
{
    using System.IO;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Dependencies:
    /// * Nuget Packages:   
    ///   * WindowsAzure.Storage" version="8.6.0" 
    ///    * Microsoft.WindowsAzure.ConfigurationManager" version="3.2.3" 
    /// </summary>
    public static class CloudBlobContainerExtensions
    {

        public  static void EnsureContainer(this CloudBlobContainer cloudBlobContainer, BlobContainerPublicAccessType BlobContainerPublicAccessTypeIfNew = BlobContainerPublicAccessType.Blob)
        {
            if (cloudBlobContainer.Exists())
            {
                return;
            }
            // Create the container if it doesn't already exist.
            cloudBlobContainer.CreateIfNotExists();

            //Define permissions:
            cloudBlobContainer.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessTypeIfNew });
        }



        /// <summary>
        /// Returns Uri composed of Container + SharedAccessSignature token.
        /// If PolicyName is provided, will return SAS generated off of the policy,
        /// otherwise will develop SAS from provided SharedAccessBlobPolicy parameters.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="policyName"></param>
        /// <param name="duration"></param>
        /// <param name="sharedAccessBlobPermissions"></param>
        /// <returns></returns>
        public static string GetContainerSharedAccessSignatureUri(this CloudBlobContainer container, string policyName = null, TimeSpan? duration= null, SharedAccessBlobPermissions sharedAccessBlobPermissions = SharedAccessBlobPermissions.Read)
        {
            var sharedAccessBlobPolicy = BuildSharedAccessBlobPolicy(duration, sharedAccessBlobPermissions);

            //Generate the shared access signature on the container, setting the constraints directly on the signature.
            // Note token starts with ? for easy appending to blob Uri:
            string containerSharedAccessSignatureToken =
                (!string.IsNullOrWhiteSpace(policyName))
                ? container.GetSharedAccessSignature(null, policyName)
                : container.GetSharedAccessSignature(sharedAccessBlobPolicy);

            //Return the URI string for the container, including the SAS token.
            string result = container.Uri + containerSharedAccessSignatureToken;
            return result;

        }

        public static void SetContainerSharedAccessPolicy(this CloudBlobContainer container, string policyName, TimeSpan? duration = null, SharedAccessBlobPermissions sharedAccessBlobPermissions = SharedAccessBlobPermissions.Read)
        {
            var sharedAccessBlobPolicy = BuildSharedAccessBlobPolicy(duration, sharedAccessBlobPermissions);
            container.SetContainerSharedAccessPolicy(policyName, sharedAccessBlobPolicy);
        }

        /// <summary>
        /// Adds or replaces a Container's SharedAccessPolicy
        /// </summary>
        /// <param name="container"></param>
        /// <param name="policyName"></param>
        /// <param name="sharedAccessBlobPolicy"></param>
        public static void SetContainerSharedAccessPolicy(this CloudBlobContainer container, string policyName,
            SharedAccessBlobPolicy sharedAccessBlobPolicy)
        {
            //
            //Get the container's existing permissions.
            BlobContainerPermissions permissions = container.GetPermissions();

            if (permissions.SharedAccessPolicies.ContainsKey(policyName))
            {
                permissions.SharedAccessPolicies.Remove(policyName);
            }

            //Add the new policy to the container's permissions, and set the container's permissions.
            permissions.SharedAccessPolicies.Add(policyName, sharedAccessBlobPolicy);
            container.SetPermissions(permissions);
        }

        private static SharedAccessBlobPolicy BuildSharedAccessBlobPolicy(TimeSpan? duration=null,
            SharedAccessBlobPermissions sharedAccessBlobPermissions = SharedAccessBlobPermissions.Read)
        {
            if (!duration.HasValue)
            {
                duration = TimeSpan.FromMinutes(1);
            }
//Set the expiry time and permissions for the container.
            SharedAccessBlobPolicy sharedAccessBlobPolicy = new SharedAccessBlobPolicy();

            //In this case, the start time is specified as a few minutes in the past, to mitigate clock skew.
            sharedAccessBlobPolicy.SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            sharedAccessBlobPolicy.SharedAccessExpiryTime = DateTimeOffset.UtcNow.Add(duration.Value);

            // Read is the default, but there are lots of options to combine:
            sharedAccessBlobPolicy.Permissions = sharedAccessBlobPermissions;

            return sharedAccessBlobPolicy;
        }


        public static void UploadText(this CloudBlobContainer cloudBlobContainer, string remoteBlobName, string text)
        {
            //Note that this is a BlockBlob, nut just a blob:
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            blob.UploadText(text);
        }

        public static void UploadFile(this CloudBlobContainer cloudBlobContainer, string localFileName, string remoteBlobName=null)
        {

            if (string.IsNullOrEmpty(remoteBlobName))
            {
                remoteBlobName = Path.GetFileName(localFileName);
            }
            //Note that this is a BlockBlob, nut just a blob:
            CloudBlockBlob blob =
                cloudBlobContainer.GetBlockBlobReference(remoteBlobName);

            blob.UploadFromFile(localFileName);
        }

        public static void UploadBytes(this CloudBlobContainer cloudBlobContainer, string remoteBlobName, byte[] bytes)
        {
            //Note that this is a BlockBlob, nut just a blob:
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            blob.UploadFromByteArray(bytes,0,bytes.Length);
        }
        public static void UploadStream(this CloudBlobContainer cloudBlobContainer, string remoteBlobName, Stream stream )
        {
            //Note that this is a BlockBlob, nut just a blob:
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            stream.Position = 0;
            blob.UploadFromStream(stream);
        }

        public static byte[] DownloadStream(this CloudBlobContainer cloudBlobContainer, string remoteBlobName)
        {
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            blob.FetchAttributes();
            long fileByteLength = blob.Properties.Length;
            Byte[] result = new Byte[fileByteLength];
            int downloaded = blob.DownloadToByteArray(result, 0);
            return result;

        }

        public static Stream DownloadStream(this CloudBlobContainer cloudBlobContainer, string remoteBlobName, Stream stream = null)
        {
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            if (stream == null)
            {
                stream = new MemoryStream();
            }
            blob.DownloadToStream(stream);
            return stream;
        }
        public static bool DeleteBlob(this CloudBlobContainer cloudBlobContainer, string remoteBlobName)
        {

            string status = string.Empty;
            CloudBlockBlob blobSource = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
            bool blobExisted = blobSource.DeleteIfExists();
            return blobExisted;

        }

        public static string[] ListContainerContents(this CloudBlobContainer cloudBlobContainer, string pathPrefixFilter=null, bool removeContainerName=true)
        {

            var containerName = cloudBlobContainer.Name;

            string[] results = cloudBlobContainer.ListBlobs(pathPrefixFilter, true, BlobListingDetails.All)
                .Select(x => removeContainerName ? GetFileNameFromBlobURI(x.Uri, containerName) : x.Uri.ToString()).ToArray();

            return results;
        }




        //public static bool RenameABlob(this CloudBlobContainer cloudBlobContainer, string remoteBlobName, string newName)
        //{
        //    CloudBlockBlob blobSource = cloudBlobContainer.GetBlockBlobReference(remoteBlobName);
        //    if (blobSource.Exists())
        //    {
        //        CloudBlockBlob blobTarget = cloudBlobContainer.GetBlockBlobReference(newName);
        //        blobTarget.BeginStartCopy(blobSource,);
        //        blobSource.Delete();
        //    }
        //}

        private static string GetFileNameFromBlobURI(Uri theUri, string containerName)
        {
            string path = theUri.ToString();
            int dirIndex = path.IndexOf(containerName);

            string result = path.Substring(
                dirIndex + containerName.Length + 1,
                path.Length - (dirIndex + containerName.Length + 1));

            return result;
        }
    }
}
