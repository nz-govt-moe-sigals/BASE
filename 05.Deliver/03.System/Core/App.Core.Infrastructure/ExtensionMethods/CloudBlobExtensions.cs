using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class CloudBlobExtensions
    {

        /// <summary>
        /// Returns Uri composed of Container + SharedAccessSignature token.
        /// If PolicyName is provided, will return SAS generated off of the policy,
        /// otherwise will develop SAS from provided SharedAccessBlobPolicy parameters.
        /// </summary>
        /// <param name="cloudBlob"></param>
        /// <param name="policyName"></param>
        /// <param name="duration"></param>
        /// <param name="sharedAccessBlobPermissions"></param>
        /// <returns></returns>
        public static string GetBlobSharedAccessSignatureUri(this CloudBlob cloudBlob, string policyName = null, TimeSpan? duration = null, SharedAccessBlobPermissions sharedAccessBlobPermissions = SharedAccessBlobPermissions.Read)
        {

            var sharedAccessBlobPolicy = BuildSharedAccessBlobPolicy(duration, sharedAccessBlobPermissions);

            //Generate the shared access signature on the blob, setting the constraints directly on the signature.
            // Note token starts with ? for easy appending to container Uri:
            string blobSharedAccessSignatureToken =
                (!string.IsNullOrWhiteSpace(policyName))
                    ? cloudBlob.GetSharedAccessSignature(null, policyName)
                    : cloudBlob.GetSharedAccessSignature(sharedAccessBlobPolicy);

            //Return the URI string for the container, including the SAS token.
            return cloudBlob.Uri + blobSharedAccessSignatureToken;
        }




        private static SharedAccessBlobPolicy BuildSharedAccessBlobPolicy(TimeSpan? duration = null,
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


    }
}
