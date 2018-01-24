
namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration needed to 
    /// access the
    /// Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountConfiguration
    {
        private string _publicBlobContainerName;
        private string _privateBlobContainerName;

        /// <summary>
        /// A secure app should not be using Access Keys directly
        /// (a key vault could do that, but ...why?!
        /// </summary>
        [Alias("App:Core:Integration:Azure:StorageAccount:UseAccessKeys")]
        public bool UseAccessKeys
        {
            get; set;
        }


        [Alias("App:Core:Integration:Azure:StorageAccount:EnsureContainers")]
        public bool EnsureContainers
        {
            get; set;
        }

        [Alias("App:Core:Integration:Azure:StorageAccount:Name")]
        public string Name
        {
            get; set;
        }
        [Alias("App:Core:Integration:Azure:StorageAccount:Url")]
        public string Url
        {
            get; set;
        }
        [Alias("App:Core:Integration:Azure:StorageAccount:ConnectionString")]
        public string ConnectionString
        {
            get; set;
        }
        

            [Alias("App:Core:Integration:Azure:StorageAccount:SASToken")]
        public string AccountSharedAccessSignatureToken
        {
            get; set;
        }

        [Alias("App:Core:Integration:Azure:StorageAccount:SASTokenUrl")]
        public string AccountSharedAccessSignatureUrl { get; set; }

        [Alias("App:Core:Integration:Azure:StorageAccount:PublicBloContainerName")]
        public string PublicBlobContainerName
        {
            get { return this._publicBlobContainerName ?? "public"; }
            set { this._publicBlobContainerName  = value; }
        }

        [Alias("App:Core:Integration:Azure:StorageAccount:PrivateBlobContainerName")]
        public string PrivateBlobContainerName
        {
            get { return this._privateBlobContainerName ?? "private"; }
            set { this._privateBlobContainerName = value; }
        }
    }
}
