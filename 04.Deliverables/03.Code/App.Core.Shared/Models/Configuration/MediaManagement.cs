namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class MediaManagementConfiguration
    {
        private string _hashType;

        [Alias("System:Media:HashType")]
        public string HashType
        {
            get { return this._hashType?? "SHA-256"; }
            set { this._hashType = value; }
        }
    }
}