namespace App.Module2.Shared.Models.Entities
{
    public enum BodyChannelType
    {
        // An error state.
        Undefined=0,
        Unknown = 1,
        //Undisclosed =2,
        // The original, archaic, multi-field protocol:
        Postal = 3,
        // The modern single field protocols:
        Mobile = 4,
        Landline =5,
        Email=6,
        Twitter=7,
        Instagram=8,
        // etc.
    }
}