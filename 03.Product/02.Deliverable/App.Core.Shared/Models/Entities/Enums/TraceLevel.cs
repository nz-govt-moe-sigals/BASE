namespace App.Core.Shared.Models.Entities
{
    // TODO: Enums are evil (offset issue of Interface Localization)
    public enum TraceLevel
    {
        Critical = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4,
        Verbose = 5
    }
}