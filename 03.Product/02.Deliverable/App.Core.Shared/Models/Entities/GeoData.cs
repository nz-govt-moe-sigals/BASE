namespace App.Core.Shared.Models.Entities
{
    public class GeoData : TenantFKTimestampedAuditedRecordStatedGuidIdEntityBase
    {
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual GeoDataType Type { get; set; }
        public virtual decimal? Value { get; set; }
        public virtual string Color { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Draggable { get; set; }
    }
}