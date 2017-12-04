namespace App.Core.Shared.Models.Entities
{
    // TODO: Enums are evil (offset issue of Interface Localization)
    public enum RecordPersistenceState
    {
        Active = 0,

        //Pretty sure this is invalid for a Record State -- ok for an EntityState, but that's different: Disabled=true,
        Archived = 1,
        Superceded = 2,
        Merged = 4,
        ToDispose = 8 /*Garbage*/,
        Disposed = 16
    }
}