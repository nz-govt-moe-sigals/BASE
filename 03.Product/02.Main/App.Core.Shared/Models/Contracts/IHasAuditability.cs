namespace App.Core.Shared.Models
{
    using System;

    public interface IHasInRecordAuditability
    {
        /// <summary>
        ///     Gets or sets the created on.
        /// </summary>
        DateTime? CreatedOnUtc { get; set; }


        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        string CreatedByPrincipalId { get; set; }

        /// <summary>
        ///     Gets or sets the last modified on.
        /// </summary>
        DateTime? LastModifiedOnUtc { get; set; }

        /// <summary>
        ///     Gets or sets the last modified by.
        /// </summary>
        string LastModifiedByPrincipalId { get; set; }

        /// <summary>
        ///     Gets or sets the last modified on.
        /// </summary>
        DateTime? DeletedOnUtc { get; set; }

        /// <summary>
        ///     Gets or sets the last modified by.
        /// </summary>
        string DeletedByPrincipalId { get; set; }
    }
}