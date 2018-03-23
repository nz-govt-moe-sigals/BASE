using System;

namespace App.Core.Shared.Attributes
{
    public class KeyAttribute : Attribute
    {
        public KeyAttribute(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

    }
}
