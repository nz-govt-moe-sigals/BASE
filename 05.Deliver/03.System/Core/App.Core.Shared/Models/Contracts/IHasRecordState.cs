namespace App.Core.Shared.Models
{
    using App.Core.Shared.Models.Entities;

    public interface IHasRecordState
    {
        RecordPersistenceState RecordState { get; set; }
    }
}