namespace App.Core.Shared.Attributes
{
    using System;

    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}