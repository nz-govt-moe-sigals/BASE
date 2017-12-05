namespace App.Core.Shared.Models.Entities
{
    using System;

    public class Notification : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        public virtual NotificationType Type { get; set; }

        public virtual TraceLevel Level { get; set; }

        //For:
        public virtual Guid PrincipalFK { get; set; }

        public virtual DateTime DateTimeCreatedUtc { get; set; }
        public virtual DateTime? DateTimeReadUtc { get; set; }


//Source User or System identifier
        public virtual string From { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual string Class { get; set; }

        /// <summary>
        ///     Status whether Message has been read.
        /// </summary>
        public virtual bool IsRead
        {
            get => this.DateTimeReadUtc.HasValue;
            set
            {
                if (value == false)
                {
                    this.DateTimeReadUtc = null;
                }
                else
                {
                    if (!this.DateTimeReadUtc.HasValue)
                    {
                        this.DateTimeReadUtc = DateTime.UtcNow;
                    }
                }
            }
        }

        /// <summary>
        ///     1-100% complete.
        /// </summary>
        public virtual int Value { get; set; }

        public virtual string Text { get; set; }
    }
}