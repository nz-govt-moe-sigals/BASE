namespace App.Module2.Shared.Models.Entities
{
    public enum BodyChannelType
    {
        // An error state.
        Undefined=0,
        // The original, archaic, multi-field protocol:
        Postal = 1,
        // The modern single field protocols:
        Mobile = 2,
        Landline =3,
        Email=4,
        Twitter=5,
        Instagram=6,
        // etc.
    }
}