namespace App.Core.Shared.Models.Entities
{
    using System;

    // Local Membership info is kept separate from Principal
    // as it has nothing to do with Principal or business.
    // Can't repeat this enough. Use an external 3rd party IdP.
    public class PrincipalMembershipInfo: IHasGuidId, IHasTimestamp, IHasRecordState
    {
        // If the info in your app is valuable to someone, 
        // it's never an issue of if. It's an issue of when.
        // So if you persist not using an IdP (AAD, B2C, whatever),
        // do *NOT* save user information in a non-encrypted state.
        // ie: Email and Phone info used for authentication purposes must be encrypted.

        public Guid Id { get; set; }
        public byte[] Timestamp { get; set; }
        public RecordPersistenceState RecordState { get; set; }

        public string UserName { get; set; }
        /* GOD I HATE DOING THIS WITHIN AN APP. USE AN IDP! */
        public string PasswordHash { get; set; }

        public string EncryptedEmailAddress { get; set; }
        public string EmailConfirmed { get; set; }

        public bool TFAEnabled { get; set; }
        public string TFAEncryptedDeviceNumber { get; set; }
        public string TFADeviceConfirmed { get; set; }

        // Used to count incorrect attempts, and lock out the Principal
        public int IncorrectAttemptCount { get; set; }
        public DateTime? LockedOutUntillUtc { get; set; }
    }
}
