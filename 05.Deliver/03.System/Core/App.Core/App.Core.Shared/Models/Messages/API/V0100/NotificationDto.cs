namespace App.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using App.Core.Shared.Models.Entities;

    public class NotificationDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasTenantFK //, IHasRecordState
    {
        public NotificationDto()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual NotificationType Type { get; set; }

        public virtual TraceLevel Level { get; set; }

        public virtual string From { get; set; }

        public virtual string ImageUrl { get; set; }

        public virtual string Class { get; set; }

        public virtual DateTime DateTimeCreatedUtc { get; set; }
        public virtual DateTime? DateTimeReadUtc { get; set; }

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
        public int Value { get; set; }

        public string Text { get; set; }

        public Guid Id { get; set; }

        public Guid TenantFK { get; set; }
    }
}