// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using App.Core.Shared.Factories;

    public static class GuidExtensions
    {
        public static Guid Generate(this Guid guid)
        {
            return GuidFactory.NewGuid();
        }
    }
}