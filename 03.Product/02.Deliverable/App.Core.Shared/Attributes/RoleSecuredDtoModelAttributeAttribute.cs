namespace App.Core.Shared.Attributes
{
    using System;

    public class RoleSecuredDtoModelAttributeAttribute : Attribute
    {
        public RoleSecuredDtoModelAttributeAttribute(string roles)
        {
            this.Roles = roles;
        }

        public string Roles { get; set; }
    }
}