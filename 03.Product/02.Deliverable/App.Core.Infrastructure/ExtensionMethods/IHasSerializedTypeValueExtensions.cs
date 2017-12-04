// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using App.Core.Shared.Models;

    public static class IHasSerializedTypeValueExtensions
    {
        public static object Deserialize(this IHasSerializedTypeValue source)
        {
            // TODO
            return null;
        }
    }
}